using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

public class ShootLantern : MonoBehaviour
{
    private bool playing;
    private float currentTime;
    public List<GameObject> fwList = new List<GameObject>();
    private LampKick lampKick;

    // Update is called once per frame
    void Update()
    {
        #region VRController
        // Get the currently active VR device
        var vrDevice = VRDevice.Device;
        if (vrDevice == null)
            return;

        // Get the primary input device (the controller)
        var inputDevice = vrDevice.PrimaryInputDevice;
        if (inputDevice == null)
            return;
        #endregion

        if (inputDevice.GetButtonDown(VRButton.One))
        {
            Shoot();
        }

        currentTime += 1 * Time.deltaTime;
    }

    // Checks if VR controller is pointing at a lantern and calls the Boom 
    private void Shoot()
    {
        var hitResult = VRDevice.Device.PrimaryInputDevice.Pointer.CurrentRaycastResult;
        if (hitResult.gameObject != null)
        {
            if (hitResult.gameObject.GetComponent<LampKick>())
            {
                lampKick = hitResult.gameObject.GetComponent<LampKick>();
                if (lampKick.shootable == true)
                {
                    Boom(hitResult.gameObject);
                }
            }
        }
    }

    // Checks current time and spawns a firework from a different list depending on how much time has passed
    private void Boom(GameObject lamp)
    {
        if (currentTime < 60f)
        {
            Instantiate(fwList[Random.Range(0, 3)], lamp.transform.position, lamp.transform.rotation);
        }
        else if (currentTime >= 60f && currentTime < 120f)
        {
            Instantiate(fwList[Random.Range(0, 7)], lamp.transform.position, lamp.transform.rotation);
        }
        else
        {
            Instantiate(fwList[Random.Range(4, fwList.Count)], lamp.transform.position, lamp.transform.rotation);
        }
        DestroyImmediate(lamp, true);
    }
}