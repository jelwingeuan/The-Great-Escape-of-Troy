using UnityEngine;

public class DoorOpenOnTasks : MonoBehaviour
{
    public GameObject doorObject;
    public Collider blockerCollider;

    public void Open()
    {
        if (doorObject != null) doorObject.SetActive(false);
        if (blockerCollider != null) blockerCollider.enabled = false;
    }
}
