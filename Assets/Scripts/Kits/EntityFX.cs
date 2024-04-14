using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    private SpriteRenderer theSR;
    [Header("Flash FX")]
    public Material hitMaterial;
    private Material originalMaterial;
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        originalMaterial = theSR.material;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FlashFX(float time = 0.1f)
    {
        Debug.Log("flash");
        StartCoroutine(FlashFXCo(time));
    }
    IEnumerator FlashFXCo(float time = 0.001f)
    {
        if (time <= 0.001f)
        {
            theSR.material = hitMaterial;
            yield return new WaitForSeconds(.1f);
            theSR.material = originalMaterial;
        }
        for (int i = 0; i < time * 2; i++)
        {
            theSR.material = hitMaterial;
            // Debug.Log("切换后");
            yield return new WaitForSeconds(.25f);
            theSR.material = originalMaterial;
            // Debug.Log("切换前");
            yield return new WaitForSeconds(.25f);

        }

    }
}
