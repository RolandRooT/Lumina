using System.Collections;
using UnityEngine;

public class LampSpawn : MonoBehaviour
{

    public GameObject lampSpawner;
    public GameObject lamp;
    private bool spawning;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        spawning = true;
        StartCoroutine(SpawnLamp());
        Invoke("Stop", 200);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
    }

    private IEnumerator SpawnLamp()
    {
        while (spawning)
        {
            Instantiate(lamp, lampSpawner.transform.position, lampSpawner.transform.rotation);
            if (currentTime < 60)
            {
                yield return new WaitForSeconds(8);
            }
            else if (currentTime > 60 && currentTime < 120)
            {
                yield return new WaitForSeconds(5);
            }
            else
            {
                yield return new WaitForSeconds(2);
            }
        }
    }
    private void Stop()
    {
        spawning = false;
    }

}