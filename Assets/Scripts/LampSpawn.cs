using System.Collections;
using UnityEngine;

public class LampSpawn : MonoBehaviour
{

    public GameObject lampSpawner;
    private GameObject lamp;
    public GameObject[] colouredLanterns = new GameObject[6];
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
        currentTime += Time.deltaTime;
    }

    private IEnumerator SpawnLamp()
    {
        while (spawning)
        {
            if (currentTime < 60)
            {
                lamp = colouredLanterns[Random.Range(0, colouredLanterns.Length)];
                Instantiate(lamp, lampSpawner.transform.position, lampSpawner.transform.rotation);
                yield return new WaitForSeconds(8);
            }
            else if (currentTime > 60 && currentTime < 120)
            {
                lamp = colouredLanterns[Random.Range(0, colouredLanterns.Length)];
                Instantiate(lamp, lampSpawner.transform.position, lampSpawner.transform.rotation);
                yield return new WaitForSeconds(5);
            }
            else
            {
                lamp = colouredLanterns[Random.Range(0, colouredLanterns.Length)];
                Instantiate(lamp, lampSpawner.transform.position, lampSpawner.transform.rotation);
                yield return new WaitForSeconds(2);
            }
        }
    }

}