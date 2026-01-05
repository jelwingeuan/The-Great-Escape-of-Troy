using UnityEngine;

public class ArcherLaneHazard : MonoBehaviour
{
    public Transform[] impactPoints;
    public float impactInterval = 0.6f;
    public AudioSource sfx;
    public ParticleSystem impactFX;

    private bool active;
    private float t;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        active = true;
        GameBootstrapper.Instance.subtitleManager.Say("Archer: Loose!", 1.3f);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        active = false;
    }

    void Update()
    {
        if (!active || impactPoints.Length == 0) return;

        t += Time.deltaTime;
        if (t >= impactInterval)
        {
            t = 0f;
            int i = Random.Range(0, impactPoints.Length);
            var p = impactPoints[i];

            if (impactFX != null)
            {
                impactFX.transform.position = p.position;
                impactFX.Play();
            }
            if (sfx != null) sfx.Play();
        }
    }
}
