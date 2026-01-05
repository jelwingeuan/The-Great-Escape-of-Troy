using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        other.gameObject.layer = LayerMask.NameToLayer("HiddenPlayer");
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        other.gameObject.layer = LayerMask.NameToLayer("Player");
    }
}
