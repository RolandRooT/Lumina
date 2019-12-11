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
            if (currentTime < 60)
            {
                Instantiate(lamp, lampSpawner.transform.position, lampSpawner.transform.rotation);
                yield return new WaitForSeconds(8);
            }
            else if (currentTime > 60 && currentTime < 120)
            {
                Instantiate(lamp, lampSpawner.transform.position, lampSpawner.transform.rotation);
                yield return new WaitForSeconds(5);
            }
            else
            {
                Instantiate(lamp, lampSpawner.transform.position, lampSpawner.transform.rotation);
                yield return new WaitForSeconds(2);
            }
        }
    }

}