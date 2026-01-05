using UnityEngine;
using TMPro;

public class ReadableUI : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text titleText;
    public TMP_Text bodyText;

    void Start() => Close();

    public void Open(string title, string body)
    {
        panel.SetActive(true);
        titleText.text = title;
        bodyText.text = body;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Close()
    {
        panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (panel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            Close();
    }
}
