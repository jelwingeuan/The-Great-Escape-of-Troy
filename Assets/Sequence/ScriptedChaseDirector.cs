using UnityEngine;

public class ScriptedChaseDirector : MonoBehaviour
{
    public AudioSource chaseAudio; // loop ambience
    public GameObject[] collapseBehind; // blockers you activate
    public string subtitleStart = "Footsteps... they're close.";
    public string subtitleEnd = "If the city must die… its memory will not.";

    private bool running;

    public void StartChase()
    {
        if (running) return;
        running = true;

        if (chaseAudio != null) chaseAudio.Play();
        GameBootstrapper.Instance.subtitleManager.Say(subtitleStart, 2.5f);
    }

    public void TriggerCollapse(int index)
    {
        if (index < 0 || index >= collapseBehind.Length) return;
        if (collapseBehind[index] != null) collapseBehind[index].SetActive(true);
    }

    public void EndChase()
    {
        if (chaseAudio != null) chaseAudio.Stop();
        GameBootstrapper.Instance.subtitleManager.Say(subtitleEnd, 3f);
        running = false;
    }
}
