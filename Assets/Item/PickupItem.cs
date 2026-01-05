using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractable
{
    public string prompt = "Pick up";
    public ItemId itemId = ItemId.Scroll;

    public string Prompt => prompt;

    public void Interact(PlayerInteractor interactor)
    {
        var inv = interactor.GetComponentInParent<Inventory>();
        if (inv != null)
        {
            inv.Add(itemId);
        }

        // Optional subtitle feedback
        if (GameBootstrapper.Instance.subtitleManager != null)
            GameBootstrapper.Instance.subtitleManager.Say($"Picked up: {itemId}", 1.2f);

        Destroy(gameObject);
    }
}
