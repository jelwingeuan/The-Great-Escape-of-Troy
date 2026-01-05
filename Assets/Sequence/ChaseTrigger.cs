using UnityEngine;

public class ChaseTrigger : MonoBehaviour
{
    public ScriptedChaseDirector director;
    public enum Mode { Start, Collapse, End }
    public Mode mode = Mode.Start;
    public int collapseIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (mode == Mode.Start) director.StartChase();
        if (mode == Mode.Collapse) director.TriggerCollapse(collapseIndex);
        if (mode == Mode.End) director.EndChase();

        gameObject.SetActive(false);
    }
}
