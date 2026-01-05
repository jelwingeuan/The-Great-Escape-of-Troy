using UnityEngine;

public class AttackSequenceController : MonoBehaviour
{
    [Header("Enable/Disable sets")]
    public GameObject[] enableOnAttack;
    public GameObject[] disableOnAttack;

    [Header("Objective")]
    [TextArea] public string newObjective = "Escape the district. Reach the palace route. Find the tunnels below.";

    [Header("Key Item Spawn")]
    public GameObject scrollBundlePickup; // place in scene disabled

    public void StartAttack()
    {
        foreach (var go in disableOnAttack) if (go != null) go.SetActive(false);
        foreach (var go in enableOnAttack) if (go != null) go.SetActive(true);

        if (scrollBundlePickup != null) scrollBundlePickup.SetActive(true);

        GameBootstrapper.Instance.objectiveManager.SetObjective(newObjective);
        GameBootstrapper.Instance.subtitleManager.Say("The Greeks are inside the walls… We were deceived.", 3f);
    }
}
