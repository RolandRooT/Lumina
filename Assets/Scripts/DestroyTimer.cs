using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    // Destroys a firework effect once it has run its course.
    void Start()
    {
        Invoke("Timer", 9);
    }
    private void Timer()
    {
        DestroyImmediate(gameObject, true);
    }
}
