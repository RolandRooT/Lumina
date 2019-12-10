using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSpawn : MonoBehaviour
{

    public GameObject lampSpawner;
    public GameObject lamp;
    private bool cooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (cooldown == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(lamp, lampSpawner.transform.position, lampSpawner.transform.rotation);
                Debug.Log("Lantern spawned");
                cooldown = true;
                StartCoroutine(CoolTimer());
            }
        }
        else
            Debug.Log("Fuck you");
    }

    private IEnumerator CoolTimer()
    {
        yield return new WaitForSeconds(2);
        cooldown = false;
    }
}
