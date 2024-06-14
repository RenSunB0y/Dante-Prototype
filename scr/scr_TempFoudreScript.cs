using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TempFoudreScript : MonoBehaviour
{
    public GameObject asset;

    IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(asset);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRoutine()
    {

        StartCoroutine(DestroyRoutine());
    }
}
