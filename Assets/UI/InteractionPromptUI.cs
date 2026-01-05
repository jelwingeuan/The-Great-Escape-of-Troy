using UnityEngine;
using TMPro;

public class InteractionPromptUI : MonoBehaviour
{
    public TMP_Text text;
    public PlayerInteractor interactor;

    void Start()
    {
        interactor.OnPromptChanged += SetPrompt;
        SetPrompt("");
    }

    void SetPrompt(string p)
    {
        if (text == null) return;
        text.text = string.IsNullOrEmpty(p) ? "" : $"[E] {p}";
    }
}
