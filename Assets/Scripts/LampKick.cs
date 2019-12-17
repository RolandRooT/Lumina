using System.Collections;
using UnityEngine;

public class LampKick : MonoBehaviour
{
    private Rigidbody rb;

    private float kickForce = 300f;
    public bool pushing = false;
    public bool shootable = false;
    Vector3 pushForce;

    // Start is called before the first frame update
    private void Awake()
    {
        pushForce = new Vector3(UnityEngine.Random.Range(-0.5f, 0.7f), UnityEngine.Random.Range(0f, 0.5f), UnityEngine.Random.Range(0f, 0.6f));
    }

    // Kicks the lantern and starts pushing it slowly over time
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.AddRelativeForce(UnityEngine.Random.Range(-50f, 50f), UnityEngine.Random.Range(0f, 50f), kickForce);
        rb.AddForce(UnityEngine.Random.Range(-50f, 50f), UnityEngine.Random.Range(0f, 50f), kickForce);
        shootable = false;
        pushing = true;
        StartCoroutine(PushTimer());
        Invoke("Shootable", 5);
        Invoke("Stop", 10);
    }

    // Pushes the lantern slowly over time until pushing is stopped
    private IEnumerator PushTimer()
    {
        while (pushing)
        {
            rb.AddForce(pushForce);
            yield return new WaitForEndOfFrame();
        }
    }

    // Stops pushing
    private void Stop()
    {
        pushing = false;
    }

    // Sets the lantern as shootable after a certain amount of time
    private void Shootable()
    {
        shootable = true;
    }
}