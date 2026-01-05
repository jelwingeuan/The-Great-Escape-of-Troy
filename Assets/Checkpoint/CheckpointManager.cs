using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Transform currentCheckpoint;

    public void SetCheckpoint(Transform cp) => currentCheckpoint = cp;

    public void Respawn(GameObject player)
    {
        if (currentCheckpoint == null) return;
        var cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;
        player.transform.position = currentCheckpoint.position;
        player.transform.rotation = currentCheckpoint.rotation;
        if (cc != null) cc.enabled = true;
    }
}
