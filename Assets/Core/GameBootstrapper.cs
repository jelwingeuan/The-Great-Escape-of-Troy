using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    public static GameBootstrapper Instance { get; private set; }

    [Header("Managers")]
    public ObjectiveManager objectiveManager;
    public SubtitleManager subtitleManager;
    public ReadableUI readableUI;
    public CheckpointManager checkpointManager;

    private void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
