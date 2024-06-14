using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ElementsRemanentsLogic : MonoBehaviour
{
    public int elementActuel;

    public enemyScript eScriptAttached;

    public int bleedDamage;
    public float bleedTimer;
    public float bleedFireRate;
    public float bloodTimer;
    public float bloodFireRate;
    public GameObject blood;

    public float paralysisTimer;
    public float paralysisFireRate;

    public float fireTimer;
    public float fireRate;
    public GameObject cercleDeFeu;

    public float waterTimer;
    public float waterFireRate;
    public GameObject water;

    public bool isCouroutineStarted = false;

    public int puissanceDeVulnerabilite;

    IEnumerator SetOffCoroutine()
    {
        yield return  new WaitForSeconds (8f);

        eScriptAttached.sprRenderer.color = eScriptAttached.defaultColor;

        if (elementActuel == 1)
        {
            eScriptAttached.damageDealt = eScriptAttached.baseDamage;
        }
        if (elementActuel == 4)
        {
            eScriptAttached.vulneFlag = false;
        }
        
        elementActuel = 0;
        isCouroutineStarted = false;
    }

    IEnumerator SetVulneState()
    {
        yield return new WaitForSeconds(.1f);
        eScriptAttached.vulneFlag = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        eScriptAttached = gameObject.GetComponent<enemyScript>();
        //elementActuel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();
    }

    //Different States --------------------------------

    void FireState()
    {

        eScriptAttached.sprRenderer.color = Color.red;

        if (fireTimer >= fireRate)
        {
            Instantiate(cercleDeFeu, transform.position, transform.rotation);
            fireTimer = 0;
        }
        else
        {
            fireTimer += Time.deltaTime;
        }
        if (!isCouroutineStarted)
        {
            StartCoroutine(SetOffCoroutine());
            isCouroutineStarted = true;
        }
    }

    void WaterState()
    {
        if (!isCouroutineStarted)
        {
            StartCoroutine(SetOffCoroutine());
            isCouroutineStarted = true;
        }
        eScriptAttached.damageDealt = Mathf.RoundToInt(eScriptAttached.damageDealt / 2);

        if (waterTimer >= waterFireRate)
        {
            Instantiate(water, transform.position, transform.rotation);
            waterTimer = 0;
        }
        else { waterTimer += Time.deltaTime; }

    }

    void ElectricState()
    {
        if (!isCouroutineStarted)
        {
            StartCoroutine(SetOffCoroutine());
            isCouroutineStarted = true;
        }

        eScriptAttached.sprRenderer.color = Color.yellow;
        if (paralysisTimer >= paralysisFireRate)
        {
            eScriptAttached.Paralysis();
            paralysisTimer = 0;
        }
        else { paralysisTimer += Time.deltaTime; }
    }

    void BleedingState()
    {
        if (!isCouroutineStarted)
        {
            StartCoroutine(SetOffCoroutine());
            isCouroutineStarted = true;
        }

        if (bleedTimer >= bleedFireRate)
        {
            eScriptAttached.damageReceived = bleedDamage;
            bleedTimer = 0;
        }
        else { bleedTimer += Time.deltaTime; }

        if (bloodTimer >= bloodFireRate)
        {
            Instantiate(blood, transform.position, transform.rotation);
            bloodTimer = 0;
        }
        else { bloodTimer += Time.deltaTime; }
    }

    void VulnerableState()
    {
        if (!isCouroutineStarted)
        {
            StartCoroutine(SetOffCoroutine());
            isCouroutineStarted = true;
        }
        if (!eScriptAttached.vulneFlag)
        { StartCoroutine(SetVulneState()); }
    }

    void SnowedState()
    {
        if (!isCouroutineStarted)
        {
            StartCoroutine(SetOffCoroutine());
            isCouroutineStarted = true;
        }
        eScriptAttached.eSpeed = 1f;
    }

    void CheckState()
    {
        switch (elementActuel)
        {
            
            case 1:
                WaterState();
                break;
            case 2:
                ElectricState();
                break;
            case 3:
                BleedingState();
                break;
            case 4:
                VulnerableState();
                break;
            case 5:
                SnowedState();
                break;
            case 6:
                FireState();
                break;
        }
    }

}
