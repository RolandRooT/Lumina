using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Timer", 9);
    }
    private void Timer()
    {
        DestroyImmediate(gameObject, true);
    }
}
