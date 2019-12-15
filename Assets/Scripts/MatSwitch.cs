using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatSwitch : MonoBehaviour
{
    private Shader shader;
    private ParticleSystem ps;
    private ParticleSystemRenderer psR;
    public Texture noShoot;
    public Texture shoot;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        psR = ps.GetComponent<ParticleSystemRenderer>();
        psR.material.EnableKeyword("_EMISSION");
        StartCoroutine(SwitchTest());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(psR.material.GetTexture("_EMISSION"));
    }

    private IEnumerator SwitchTest()
    {
        yield return new WaitForSeconds(2);
        psR.material.SetTexture("_EMISSION", shoot);
        yield return new WaitForSeconds(2);
        psR.material.SetTexture("_EMISSION", noShoot);
    }
}
