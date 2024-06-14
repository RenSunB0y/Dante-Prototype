using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_FlaqueBehaviour : MonoBehaviour
{
    public SpriteRenderer sprRenderer;

    public scr_ElementsRemanentsLogic elemScript;

    public Collider2D[] results;

    public scr_FlaqueBehaviour flaqueCollidedScript;

    public enemyScript eScript;

    IEnumerator FlaqueDisappear()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }

    IEnumerator FlaqueDisappearFaster()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    public float elecTimer;
    public float elecFireRate;

    public bool isElec;
    public bool isNova;

    public bool checkFlag;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlaqueDisappear());
        sprRenderer = gameObject.GetComponent<SpriteRenderer>();
        checkFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isElec || isNova)
        {
            Coroutine();
        }
    }

    public void BecomingElec()
    {
        sprRenderer.color = Color.yellow;
    }

    public void BecomingNova()
    {
        sprRenderer.color = Color.cyan;
    }

    void Coroutine()
    {
        StartCoroutine(FlaqueDisappearFaster());
    }

    void CheckAround()
    {

        checkFlag = false;

        results = Physics2D.OverlapCircleAll(gameObject.transform.position, .5f, LayerMask.GetMask("flaque"), -1f, 10f);
        for(int i = 0; i< results.Length; i++)
        {
            flaqueCollidedScript = results[i].gameObject.GetComponent<scr_FlaqueBehaviour>();

            if (isElec)
            {
                flaqueCollidedScript.isElec = true;
                flaqueCollidedScript.BecomingElec();

                if (flaqueCollidedScript.checkFlag)
                {
                    flaqueCollidedScript.CheckAround();
                }
            }

            if (isNova)
            {
                flaqueCollidedScript.isNova = true;
                flaqueCollidedScript.BecomingNova();

                if (flaqueCollidedScript.checkFlag)
                {
                    flaqueCollidedScript.CheckAround();
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if  (collision.gameObject.layer == 6)
        {
            elemScript = collision.gameObject.GetComponent<scr_ElementsRemanentsLogic>();

            if (!isElec && !isNova)
            {
                if (elemScript.elementActuel == 2)
                {
                    isElec = true;
                    BecomingElec();

                    if (checkFlag)
                    {
                        CheckAround();
                    }

                }
                if (elemScript.elementActuel == 5)
                {
                    isNova = true;
                    BecomingNova();

                    if (checkFlag)
                    {
                        CheckAround();
                    }
                }
            }
            else if (isNova)
            {
                if (elemScript.elementActuel != 6)
                {
                    eScript = collision.gameObject.GetComponent<enemyScript>();
                    eScript.BecomingFroze(false);
                }

            }
            else if (isElec)
            {
                if (elemScript.elementActuel !=0)
                { }
                else
                {
                    elemScript.elementActuel = 2;
                }
            }
        }
    }
}
