using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaScript : MonoBehaviour
{
    public float novaFireTimer;
    public float novaFireRate;

    public Vector3 vectorRange;
    public float damageMultiplier;

    public GameObject player;
    public GameObject novaH;
    public novaHScript hitboxScript;

    public scr_NovaLevelLogic logicScript;
    public scr_armeLevelUp armeScript;

    // Start is called before the first frame update
    void Start()
    {
        armeScript = gameObject.GetComponent<scr_armeLevelUp>();
        logicScript = gameObject.GetComponent<scr_NovaLevelLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (armeScript.isActive == true)
        {
            NovaActive();
        }
    }

    void NovaActive()
    {
        if (novaFireTimer > novaFireRate)
        {

            logicScript.CheckLevel(armeScript, this);
            Nova();
            novaFireTimer = 0;
        }
        else
        {
            novaFireTimer += 1 * Time.deltaTime;
        }
    }

    void Nova()
    {
        GameObject instantiatedNova;

        instantiatedNova = Instantiate(novaH, player.transform.position, player.transform.rotation);
        hitboxScript = instantiatedNova.gameObject.GetComponent<novaHScript>();
        hitboxScript.nScript = this;
    }
}
