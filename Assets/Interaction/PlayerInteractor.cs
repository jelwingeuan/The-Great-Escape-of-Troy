using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public Camera cam;
    public float range = 2.3f;
    public LayerMask interactMask;

    public System.Action<string> OnPromptChanged;

    private IInteractable current;

    void Update()
    {
        Scan();
        if (current != null && Input.GetKeyDown(KeyCode.E))
            current.Interact(this);
    }

    void Scan()
    {
        current = null;
        string prompt = "";

        if (cam == null) return;

        Ray r = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(r, out RaycastHit hit, range, interactMask))
        {
            var interactable = hit.collider.GetComponentInParent<IInteractable>();
            if (interactable != null)
            {
                current = interactable;
                prompt = interactable.Prompt;
            }
        }

        OnPromptChanged?.Invoke(prompt);
    }
}
