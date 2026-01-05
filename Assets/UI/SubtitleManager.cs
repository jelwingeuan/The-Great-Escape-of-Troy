using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitleManager : MonoBehaviour
{
    public TMP_Text subtitleText;
    public float defaultDuration = 2.5f;

    Coroutine running;

    public void Say(string line, float duration = -1f)
    {
        if (running != null) StopCoroutine(running);
        running = StartCoroutine(Run(line, duration <= 0 ? defaultDuration : duration));
    }

    IEnumerator Run(string line, float dur)
    {
        subtitleText.text = line;
        yield return new WaitForSeconds(dur);
        subtitleText.text = "";
        running = null;
    }
}
