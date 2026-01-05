using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool triggerOnce = true;

    [TextArea(1, 3)]
    public string subtitleLine;

    public float duration = 2.5f;

    private bool used;

    private void OnTriggerEnter(Collider other)
    {
        if (used && triggerOnce) return;
        if (!other.CompareTag("Player")) return;

        used = true;
        GameBootstrapper.Instance.subtitleManager.Say(subtitleLine, duration);
    }
}
