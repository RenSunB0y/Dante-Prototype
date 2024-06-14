using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Scie : MonoBehaviour
{
    public float scieTimer;
    public float scieFireRate;
    public float yOffset;

    public int damage;
    public int nombreDeScies;
    public int temp;

    public GameObject ScieH;
    public GameObject ScieInstanciated;

    public scr_ScieBehaviour scieHitboxScipt;
    public scr_ScieLevelLogic logicScript;
    public scr_armeLevelUp armeScript;

    public IEnumerator RestartScieRoutine()
    {
        yield return new WaitForSeconds(.1f);
        Scie(temp + 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        logicScript = gameObject.GetComponent<scr_ScieLevelLogic>();
        armeScript = gameObject.GetComponent<scr_armeLevelUp>();

        yOffset = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (armeScript.isActive)
        {
            ScieActive();
        }
    }

    void ScieActive()
    {
        if (scieTimer >= scieFireRate)
        {
            logicScript.CheckLevel(armeScript, this);
            Scie(1);
            scieTimer = 0;
        }
        else
        {
            scieTimer += 1 * Time.deltaTime;
        }
    }

    void Scie(int ScieNumero)
    {
        temp = ScieNumero;
        ScieInstanciated = Instantiate(ScieH, new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z), transform.rotation);
        ScieInstanciated.transform.parent = gameObject.transform;

        scieHitboxScipt = ScieInstanciated.gameObject.GetComponent<scr_ScieBehaviour>();
        scieHitboxScipt.scieScript = this;

        scieHitboxScipt.vectorDirection = Vector3.forward;
        if (ScieNumero == 2)
        {
            scieHitboxScipt.vectorDirection = Vector3.back;
        }

        nombreDeScies -= 1;

        if (nombreDeScies >= 1)
        {
            yOffset *= 1.6f;
            StartCoroutine(RestartScieRoutine());
        }
        else { yOffset = 2; }
    }
}
