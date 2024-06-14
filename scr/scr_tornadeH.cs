using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_tornadeH : MonoBehaviour
{
    public Vector3 tornadeDirection;
    public playerScript pScript;

    public enemyScript actualCollidedEnemyScript;
    public scr_ElementsRemanentsLogic elemScript;

    public scr_Tornade tScript;

    public PolygonCollider2D thisCol;
    public SpriteRenderer sprRenderer;
    public Color actualColor;

    public float tornadeSpeed;

    public int elementPropage;
    public bool openFlag;

    public float fireTimer;
    public float fireRate;
    public float warpSpeed;
    public GameObject cercleDeFeu;

    public float waterTimer;
    public float waterRate;
    public GameObject flaqueEau;

    IEnumerator TornadeDisappearRoutine()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        actualColor = sprRenderer.color;
        elementPropage = 0;
        actualCollidedEnemyScript = null;
        elemScript = null;
        openFlag = true;
        StartCoroutine(TornadeDisappearRoutine());
        thisCol = GetComponent<PolygonCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += tornadeDirection * tornadeSpeed * Time.deltaTime;
        CheckElement();

        
    }

    void FireBehaviour()
    {
        if (fireTimer >= fireRate)
        {
            Instantiate(cercleDeFeu, transform.position, transform.rotation);
            fireTimer = 0;
        }
        else
        {
            fireTimer += Time.deltaTime;
        }


    }

    void WaterBehaviour()
    {
        if (waterTimer >= waterRate)
        {
            Instantiate(flaqueEau, transform.position, transform.rotation);
            waterTimer = 0;
        }
        else
        {
            waterTimer += Time.deltaTime;
        }
    }

    void CheckElement()
    {
        switch (elementPropage)
        {
            
            case 1:
                FireBehaviour();
                break;

            case 3:
                WaterBehaviour();
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            elemScript = collision.gameObject.GetComponent<scr_ElementsRemanentsLogic>();

            actualCollidedEnemyScript = collision.gameObject.GetComponent<enemyScript>();
            if (elementPropage == 1)
            {
                Vector3 centreDuTornade;
                float eSpeed = 1.2f;
                if (actualCollidedEnemyScript != null)
                {
                    actualCollidedEnemyScript.tornaded = true;
                    centreDuTornade = actualCollidedEnemyScript.transform.position - this.gameObject.transform.position;
                    actualCollidedEnemyScript.transform.position -= centreDuTornade.normalized * eSpeed * Time.deltaTime;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        elemScript = collision.gameObject.GetComponent<scr_ElementsRemanentsLogic>();

        actualCollidedEnemyScript = collision.gameObject.GetComponent<enemyScript>();
        if (collision.gameObject.layer == 6)
        {
            if (elementPropage == 1)
            {
                actualCollidedEnemyScript.tornaded = false;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 6)
        {
            elemScript = collision.gameObject.GetComponent<scr_ElementsRemanentsLogic>();

            actualCollidedEnemyScript = collision.gameObject.GetComponent<enemyScript>();

            if (openFlag)
            {

                if (elemScript.elementActuel == 6)
                {
                    sprRenderer.color = Color.red;
                    actualColor = sprRenderer.color;
                    actualColor.a = .65f;
                    sprRenderer.color = actualColor;

                    transform.localScale *= 1.3f;
                    //thisCol.isTrigger = true; //pareil qu'en dessous
                    actualCollidedEnemyScript.damageReceived = tScript.damage;
                    actualCollidedEnemyScript.colorToPass = 1;

                    elementPropage = 1;
                    openFlag = false;
                }

                else if (elemScript.elementActuel == 5)
                {
                    sprRenderer.color = Color.cyan;
                    actualColor = sprRenderer.color;
                    actualColor.a = .65f;
                    sprRenderer.color = actualColor;

                    //thisCol.isTrigger = true; // Decider si mettre en trigger ou pas
                    transform.localScale *= 1.3f;
                    actualCollidedEnemyScript.damageReceived = tScript.damage;
                    actualCollidedEnemyScript.colorToPass = 4;

                    elementPropage = 2;
                    openFlag = false;
                }

                else if (elemScript.elementActuel == 1)
                {
                    sprRenderer.color = Color.blue;
                    actualColor = sprRenderer.color;
                    actualColor.a = .65f;
                    sprRenderer.color = actualColor;

                    tornadeSpeed = 8;
                    transform.localScale *= 1.5f;
                    actualCollidedEnemyScript.damageReceived = tScript.damage;
                    actualCollidedEnemyScript.colorToPass = 3;

                    elementPropage = 3;
                    openFlag = false;
                }
                else
                {
                    actualCollidedEnemyScript.damageReceived = tScript.damage;
                    actualCollidedEnemyScript.colorToPass = 5;
                    actualCollidedEnemyScript.GetVulnerability();
                }
            }
            else
            {
                actualCollidedEnemyScript.damageReceived = tScript.damage;
                

                if (elementPropage == 3)
                {
                    actualCollidedEnemyScript.colorToPass = 3;
                    if (elemScript.elementActuel != 0)
                    {

                    }
                    else
                    {
                        elemScript.elementActuel = 1;
                    }
                }

                if (elementPropage == 1)
                {
                    actualCollidedEnemyScript.colorToPass = 1;
                    if (elemScript.elementActuel != 0)
                    {

                    }
                    else
                    {
                        elemScript.elementActuel = 6;
                    }

                }

                if (elementPropage == 2)
                {
                    actualCollidedEnemyScript.BecomingFroze(false);
                    actualCollidedEnemyScript.colorToPass = 4;
                }
            }

        }
    }
}
