using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlord : MonoBehaviour
{
    private float currentTime;
    private LampKick lampKick;
    private ShootLantern ShootLantern;

    public GameObject[] lamps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        
        if (currentTime >= 18)
        {
            TheEnd();
        }
    }

    private void TheEnd()
    {
        Debug.Log("Reached end");
        lamps = GameObject.FindGameObjectsWithTag("Lamp");
        Debug.Log("Finding lamps");
        foreach (GameObject lamp in lamps)
        {
            lampKick = lamp.gameObject.GetComponent<LampKick>();
            Debug.Log("grabbing scripts in lamps");
            lampKick.shootable = false;
            Debug.Log("Lamps invincible");
        }
    }
}
