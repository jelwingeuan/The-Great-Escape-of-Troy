using UnityEngine;

public class EndExitTrigger : MonoBehaviour
{
    [TextArea] public string finalLine = "If the city must die… its memory will not.";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        GameBootstrapper.Instance.subtitleManager.Say(finalLine, 3f);
        // Optional: fade + load credits scene
    }
}
