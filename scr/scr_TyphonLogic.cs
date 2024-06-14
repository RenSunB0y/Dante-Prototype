using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TyphonLogic : MonoBehaviour
{
    public float typhonTimer;
    public float typhonFireRate;

    public int damage;
    public int nombreDeTyphon;
    public float rangeMultiplier;

    public GameObject typhonCree;
    public scr_TyphonBehaviour behavScript;

    public scr_TyphonLevelLogic logicScript;
    public scr_armeLevelUp armeScript;
    public GameObject typhon;

    // Start is called before the first frame update
    void Start()
    {
        armeScript = gameObject.GetComponent<scr_armeLevelUp>();
        logicScript = gameObject.GetComponent<scr_TyphonLevelLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (armeScript.isActive)
        {
            TyphonActive();
        }
    }

    void TyphonActive()
    {
        if (typhonTimer >= typhonFireRate)
        {
            logicScript.CheckLevel(armeScript, this) ;
            Typhon();
            typhonTimer = 0;
        }
        else
        {
            typhonTimer += 1 * Time.deltaTime;
        }
    }

    void Typhon()
    {
        float randomX = Random.Range( -20 , 20 );
        float randomY = Random.Range( -10 , 10 );

        Vector3 instantiatedPos;

        instantiatedPos = new Vector3( transform.position.x + randomX, transform.position.y + randomY, transform.position.z);
        typhonCree = Instantiate(typhon, instantiatedPos, gameObject.transform.rotation);
        behavScript = typhonCree.gameObject.GetComponent<scr_TyphonBehaviour>();
        behavScript.tScript = this;

        nombreDeTyphon -= 1;
        if(nombreDeTyphon >= 1)
        { Typhon(); }
    }
}
