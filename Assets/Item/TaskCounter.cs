using UnityEngine;
using UnityEngine.Events;

public class TaskCounter : MonoBehaviour
{
    public int target = 3;
    public UnityEvent onCompleted;

    private int current;

    public void AddProgress(int amount)
    {
        current += amount;
        if (current >= target)
            onCompleted?.Invoke();
    }
}
