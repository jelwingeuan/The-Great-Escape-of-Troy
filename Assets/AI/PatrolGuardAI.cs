using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PatrolGuardAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float waitAtPoint = 1.2f;

    [Header("Detection")]
    public VisionSensor vision;
    public float timeToCatch = 1.2f;

    [Header("Fail")]
    public GameObject playerRoot; // assign Player object in inspector

    private NavMeshAgent agent;
    private int index;
    private float waitTimer;
    private float seenTimer;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        if (patrolPoints.Length > 0)
            agent.SetDestination(patrolPoints[0].position);
    }

    void Update()
    {
        Patrol();

        if (playerRoot == null || vision == null) return;

        Transform player = playerRoot.transform;

        if (vision.CanSeePlayer(player))
        {
            seenTimer += Time.deltaTime;

            if (seenTimer > 0.2f)
                GameBootstrapper.Instance.subtitleManager.Say("Spartan: There! In the smoke!", 1.5f);

            if (seenTimer >= timeToCatch)
            {
                GameBootstrapper.Instance.subtitleManager.Say("Captured!", 1.5f);
                GameBootstrapper.Instance.checkpointManager.Respawn(playerRoot);
                seenTimer = 0f;
            }
        }
        else
        {
            seenTimer = Mathf.Max(0f, seenTimer - Time.deltaTime * 1.5f);
        }
    }

    void Patrol()
    {
        if (patrolPoints == null || patrolPoints.Length == 0) return;

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitAtPoint)
            {
                index = (index + 1) % patrolPoints.Length;
                agent.SetDestination(patrolPoints[index].position);
                waitTimer = 0f;
            }
        }
    }
}
