using UnityEngine;

public class Readable : MonoBehaviour, IInteractable
{
    public string prompt = "Read";
    public string title;
    [TextArea(4, 12)] public string body;

    public string Prompt => prompt;

    public void Interact(PlayerInteractor interactor)
    {
        GameBootstrapper.Instance.readableUI.Open(title, body);
    }
}
