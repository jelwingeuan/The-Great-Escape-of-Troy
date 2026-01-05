using UnityEngine;

public class SlideToZone : MonoBehaviour, IInteractable
{
    public string prompt = "Move";
    public Transform targetSnap;
    public float snapSpeed = 6f;
    public bool lockAfterSnap = true;

    private bool snapped;
    private Rigidbody rb;

    public string Prompt => snapped ? "" : prompt;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Interact(PlayerInteractor interactor)
    {
        if (snapped) return;
        StartCoroutine(SnapRoutine());
    }

    System.Collections.IEnumerator SnapRoutine()
    {
        snapped = true;
        if (rb != null) rb.isKinematic = true;

        while (Vector3.Distance(transform.position, targetSnap.position) > 0.02f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetSnap.position, snapSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetSnap.rotation, snapSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetSnap.position;
        transform.rotation = targetSnap.rotation;

        if (!lockAfterSnap && rb != null) rb.isKinematic = false;
    }
}
