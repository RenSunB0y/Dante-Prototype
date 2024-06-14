using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Tornade : MonoBehaviour
{
    public float tornadeTimer;
    public float tornadeFireRate;

    public int damage;
    public int nombreDeTornades;

    public playerScript pScript;

    public GameObject tornade;
    public GameObject instantiatedTornade;
    public scr_tornadeH hitboxScript;

    public scr_TornadeLevelLogic logicScript;
    public scr_armeLevelUp armeScript;

    public int temp;

    public IEnumerator RestartTornadeRoutine()
    {
        yield return new WaitForSeconds(.2f);
        Tornade(temp + 1);
    }

    void Start()
    {
        armeScript = gameObject.GetComponent<scr_armeLevelUp>();
        logicScript = gameObject.GetComponent<scr_TornadeLevelLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (armeScript.isActive)
        {
            TornadeActive();
        }
    }

    void TornadeActive()
    {
        if (tornadeTimer >= tornadeFireRate)
        {
            logicScript.CheckLevel(armeScript, this);
            Tornade(1);
            tornadeTimer = 0;
        }
        else
        {
            tornadeTimer += 1 * Time.deltaTime;
        }
    }

    void Tornade(int tornadeNumero)
    {
        temp = tornadeNumero;
        instantiatedTornade = Instantiate(tornade, transform.position, transform.rotation);
        hitboxScript = instantiatedTornade.gameObject.GetComponent<scr_tornadeH>();
        hitboxScript.tScript = this;

        pScript = GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<playerScript>();

        if (tornadeNumero == 1)
        { hitboxScript.tornadeDirection = pScript.passedPlayerDirection.normalized; }

        if (tornadeNumero == 2)
        {
            hitboxScript.tornadeDirection = -pScript.passedPlayerDirection.normalized;
        }

        if (tornadeNumero == 3)
        {
            if (pScript.passedPlayerDirection.y != 0 && pScript.passedPlayerDirection.x != 0)
            { hitboxScript.tornadeDirection = new Vector3(pScript.passedPlayerDirection.x, -pScript.passedPlayerDirection.y).normalized; }
            
            else { hitboxScript.tornadeDirection = new Vector3(pScript.passedPlayerDirection.y,pScript.passedPlayerDirection.x).normalized; }
        }

        if (tornadeNumero == 4)
        {
            if (pScript.passedPlayerDirection.x != 0 && pScript.passedPlayerDirection.y != 0)
            { hitboxScript.tornadeDirection = new Vector3(-pScript.passedPlayerDirection.x, pScript.passedPlayerDirection.y).normalized; }
            
            else { hitboxScript.tornadeDirection = new Vector3(-pScript.passedPlayerDirection.y, -pScript.passedPlayerDirection.x).normalized; }
        }
            nombreDeTornades -= 1;

        if (nombreDeTornades >= 1)
        {
            Tornade(tornadeNumero +1);
        }
    }
}
