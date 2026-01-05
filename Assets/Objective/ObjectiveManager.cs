using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    public TMP_Text objectiveText;

    public void SetObjective(string text)
    {
        if (objectiveText != null) objectiveText.text = text;
    }
}
