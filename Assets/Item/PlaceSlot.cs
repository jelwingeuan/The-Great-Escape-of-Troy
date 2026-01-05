using UnityEngine;

public class PlaceSlot : MonoBehaviour, IInteractable
{
    public ItemId requiredItem = ItemId.Scroll;
    public string prompt = "Place item";

    [Header("Progress Hook")]
    public TaskCounter taskCounter;

    private bool filled;

    public string Prompt => filled ? "" : prompt;

    public void Interact(PlayerInteractor interactor)
    {
        if (filled) return;

        var inv = interactor.GetComponentInParent<Inventory>();
        if (inv == null || !inv.Has(requiredItem))
        {
            GameBootstrapper.Instance.subtitleManager.Say("I don't have the right item.", 1.6f);
            return;
        }

        filled = true;
        taskCounter?.AddProgress(1);

        GameBootstrapper.Instance.subtitleManager.Say("Placed.", 1.0f);

        // Optional: visual change (disable placeholder / enable filled mesh)
        // e.g. transform.GetChild(0).gameObject.SetActive(true);
    }
}
