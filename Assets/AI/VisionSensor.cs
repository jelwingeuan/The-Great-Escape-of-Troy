using UnityEngine;

public class VisionSensor : MonoBehaviour
{
    public Transform eyePoint;
    public float viewDistance = 8f;
    public float viewAngle = 60f;
    public LayerMask obstacleMask;
    public LayerMask playerMask;

    public bool CanSeePlayer(Transform player)
    {
        Vector3 dir = (player.position - eyePoint.position);
        float dist = dir.magnitude;
        if (dist > viewDistance) return false;

        dir.Normalize();
        float angle = Vector3.Angle(eyePoint.forward, dir);
        if (angle > viewAngle * 0.5f) return false;

        if (Physics.Raycast(eyePoint.position, dir, dist, obstacleMask))
            return false;

        return true;
    }
}
