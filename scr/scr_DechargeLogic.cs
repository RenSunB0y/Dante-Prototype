using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DechargeLogic: MonoBehaviour
{
    public float dechargeTimer;
    public float dechargeFireRate;

    public int cerclesActuels;
    public int cerclesMax;

    public int damage;
    public int damagePropagation;

    public Collider2D[] results;
    public enemyScript eScriptChoisi;

    public GameObject foudreInstanciee;
    public GameObject foudreCentre;

    public scr_ElementsRemanentsLogic elemScript;

    public scr_armeLevelUp armeScript;
    public scr_DechargeLevelLogic logicScript;

    public enemyScript eScript;

    public enemyScript eScriptReinitialize;

    // Start is called before the first frame update
    void Start()
    {
        cerclesActuels = 1;

        logicScript = gameObject.GetComponent<scr_DechargeLevelLogic>();
        armeScript = gameObject.GetComponent<scr_armeLevelUp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (armeScript.isActive)
        {
            DechargeActive();
        }
    }

    void DechargeActive()
    {
        if (dechargeTimer >= dechargeFireRate)
        {
            logicScript.CheckLevel(armeScript, this);
            for(int i =0; i < GameObject.FindGameObjectsWithTag("mechant").Length; i++)
            {
                eScriptReinitialize = GameObject.FindGameObjectsWithTag("mechant")[i].GetComponent<enemyScript>();
                eScriptReinitialize.dechargeImmune = false;
            }
            Decharge();
            dechargeTimer = 0;
            cerclesActuels = 1;
        }
        else
        {
            dechargeTimer += Time.deltaTime;
        }
    }

    void ApplyParalysis()
    {
        elemScript = eScript.gameObject.GetComponent<scr_ElementsRemanentsLogic>();
        if (elemScript.elementActuel != 0)
        {
            //
        }
        else { elemScript.elementActuel = 2; }
    }

    void Decharge()
    {
        cerclesActuels += 1;

        results = Physics2D.OverlapCircleAll(gameObject.transform.position, 3f, LayerMask.GetMask("enemies"), -1f, 100f);
        int nombreEnemy = results.Length;
        int enemyChoisi = Random.Range(0, nombreEnemy);

        if (nombreEnemy > 0)
        {
            eScript = results[enemyChoisi].GetComponent<enemyScript>();
            foudreInstanciee = Instantiate(foudreCentre, eScript.gameObject.transform.position, transform.rotation);
            foudreInstanciee.GetComponent<scr_TempFoudreScript>().StartRoutine();

            ApplyParalysis();

            eScript.damageReceived = damage;
            eScript.dechargeImmune = true;
            eScript.colorToPass = 2;

            if (armeScript.armeLevel >= 2)
            {
                Invoke("Propagation", .2f);
            }
        }
    }

    void Propagation()
    {
        cerclesActuels += 1;
            
        results = Physics2D.OverlapCircleAll(foudreInstanciee.transform.position, 2f, LayerMask.GetMask("enemies"), -1f, 100f);

        //décider pour la prochaine cible
        if (results.Length > 0)
        {
            eScriptChoisi = results[Random.Range(0, results.Length)].gameObject.GetComponent<enemyScript>();
            Vector3 ePos = eScriptChoisi.gameObject.transform.position;
            foudreInstanciee = Instantiate(foudreCentre, ePos, transform.rotation); ;
            foudreInstanciee.GetComponent<scr_TempFoudreScript>().StartRoutine();
            
        }

        //appliuqqer les damages de la premiere decharge
        for (int i = 0;  i < results.Length; i ++)
        {
            eScript = results[i].GetComponent<enemyScript>();
            if (!eScript.dechargeImmune)
            {
                eScript.damageReceived = damagePropagation;
                eScript.dechargeImmune = true;
                eScript.colorToPass = 2;
            }
            

            //provoquer la paralysie
            ApplyParalysis();
        }
        eScriptChoisi.damageReceived = damage;
        eScriptChoisi.colorToPass = 2;


        //verifier que le nombre max n'a pas été atteint
        if (cerclesActuels < cerclesMax)
        {
            Invoke("Propagation", .2f);
        }
    }

}
