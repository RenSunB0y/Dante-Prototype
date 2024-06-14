using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public static int nombreEnemyTue;

    public GameObject fumee;
    public Sprite sZombie;
    public Sprite sFantome;
    public Sprite sSquelette;

    public GameObject player;
    public GameObject playerParent;
    public GameObject xp;
    public SpriteRenderer sprRenderer;
    public float disappearSpeed;
    public bool deathFlag;

    public GameObject explosionHitbox;
    public GameObject instantiatedExplosion;
    public scr_ExplosionLogic eLogic;
    public bool explosedOne;
    public bool tornaded;

    public float eSpeed;
    public int baseDamage;
    public int damageDealt;
    public int hp;
    public bool freezed = false;
    public bool paralyzed = false;
    public bool dechargeImmune;
    public bool vulneFlag = false;
    public bool waitForExplosion;

    public int damageReceived;

    public scr_TyphonBehaviour typhonActiveScript;
    public scr_ElementsRemanentsLogic elemScript;

    public bool DotFlagged;
    public bool typhoned;
    public bool dotTyphonFlagged;

    public float immuneTimer;
    public float immuneMax;

    public Vector3 pPos;
    public Vector3 newLocalScale;

    public Color defaultColor;

    public novaHScript novaH;
    public enemyScript eScript;

    public GameObject damageText;
    public damageTextScript actualDamageTextScript;
    public int colorToPass;

    public float secondsBeforeDisappear;

    public Material flashMaterial;
    private Material materialSpritesDefault;

    IEnumerator ReturnNormalRoutine()
    {
        yield return new WaitForSeconds(.2f);
        sprRenderer.material = materialSpritesDefault;
        sprRenderer.color = Color.white;
    }

    public IEnumerator FreezeRoutine(bool isNovaH)
    {
        yield return new WaitForSeconds(secondsBeforeDisappear);
        freezed = false;
        sprRenderer.color = defaultColor;
        if (isNovaH)
        {
            novaH.CheckElementActive(this.GetComponent<scr_ElementsRemanentsLogic>());
        }
    }

    public IEnumerator ParalysisRoutine()
    {
        yield return new WaitForSeconds(1f);
        paralyzed = false;
    }

    public IEnumerator ExplosionRoutine()
    {
        yield return new WaitForSeconds(3f);
        
        instantiatedExplosion = Instantiate(explosionHitbox, transform.position, transform.rotation);
        eLogic = instantiatedExplosion.GetComponent<scr_ExplosionLogic>();
        sprRenderer.color = defaultColor;
        damageReceived = eLogic.explosionDamage;
        colorToPass = 2;
        waitForExplosion = false;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        newLocalScale = transform.localScale;

        damageDealt = baseDamage;

        damageReceived = 0;

        defaultColor = sprRenderer.color;

        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerParent = GameObject.FindGameObjectsWithTag("PlayerParent")[0];

        eScript = gameObject.GetComponent<enemyScript>();
        elemScript = gameObject.GetComponent<scr_ElementsRemanentsLogic>();

        materialSpritesDefault = sprRenderer.material;

        if (spawnLogicScript.nombreDeVagues >= 30 && spawnLogicScript.nombreDeVagues < 75)
        {
            //transform.localScale *= 1.5f;
            //newLocalScale = transform.localScale;
            hp = 20;
            //sprRenderer.sprite = sFantome;

        }

        else if (spawnLogicScript.nombreDeVagues >= 75)
        {
            //transform.localScale *= 3f;
            //newLocalScale = transform.localScale;
            hp = 30;
            //sprRenderer.sprite = sSquelette;
        }
        /*else {
            sprRenderer.sprite = sZombie;
            transform.localScale = new Vector3 (.15f, .15f, .15f);
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!deathFlag)
        {
            Move();
            CheckDmg();
            CheckTooFar();
            CheckRotation();
            if (elemScript.elementActuel != 1)
            {

                secondsBeforeDisappear = 2.5f;
            }
            else { secondsBeforeDisappear = 3.5f; }

            if (vulneFlag)
            { sprRenderer.color = Color.grey; }

            if (eSpeed < 1.5 && !freezed && elemScript.elementActuel != 6 && !typhoned && !paralyzed)
            {

                eSpeed = 1.5f;
            }

            if (DotFlagged || dotTyphonFlagged)
            {
                DotImmune();
            }

            if (transform.rotation.z != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0); ;
            }
        }
        if (deathFlag)
        {
            if (defaultColor.a > 0)
            {
                defaultColor.a -= disappearSpeed * Time.deltaTime;
                sprRenderer.color = defaultColor;
            }
            else
            { Death(); }
        }
    }

    void BecomeWhite()
    {
        sprRenderer.material = flashMaterial;
        sprRenderer.color = Color.white;

        StartCoroutine(ReturnNormalRoutine());
    }

    void CheckDmg()
    {
        if (damageReceived != 0)
        {

            if (!vulneFlag)
            { DamageApplication(); }
            else
            { GetVulnerabilityDamage(damageReceived);}
        }
    }

    void DamageApplication()
    {
        if (hp > damageReceived)
        {
            BecomeWhite();
            DisplayTextDamage(damageReceived);

            hp -= damageReceived;

            damageReceived = 0;
        }

        else
        {
            DisplayTextDamage(damageReceived);
            BecomeWhite();
            DisappearBeforeDeath();
        }
    }

    void CheckRotation()
    {
        if (pPos.x > 0)
        {
            if (newLocalScale.x > 0)
            {
                Vector3 negativeLocalScale = new Vector3(-newLocalScale.x, transform.localScale.y, transform.localScale.z);
                newLocalScale = negativeLocalScale;
            }
        }
        else
        {
            if (newLocalScale.x < 0)
            {
                Vector3 positiveLocalScale = new Vector3(-newLocalScale.x, transform.localScale.y, transform.localScale.z);
                newLocalScale = positiveLocalScale;
            }
        }

        transform.localScale = newLocalScale;
    }

    void DisappearBeforeDeath()
    {
        Instantiate(xp, transform.position, transform.rotation);
        Destroy(gameObject.GetComponent<PolygonCollider2D>());
        //Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject.GetComponent<scr_ElementsRemanentsLogic>());

        Instantiate(fumee, transform.position, transform.rotation);
        deathFlag = true;
    }

    void DotImmune()
    {
        if (immuneTimer >= immuneMax)
        {
            if (DotFlagged)
            { DotFlagged = false; }

            if (dotTyphonFlagged)
            { dotTyphonFlagged = false; }

            immuneTimer = 0;
        }
        else
        {
            immuneTimer += 1 * Time.deltaTime;
        }
    }


    void Move()
    {
        if (!tornaded)
        {
            if (playerParent.activeSelf && !freezed && !typhoned && !waitForExplosion && !tornaded)
            {
                GetPlayerPosition();
                GoToPlayerPosition();
            }

            else if (playerParent.activeSelf && !freezed && !waitForExplosion && typhoned)
            {
                
                if (typhonActiveScript != null)
                {
                    Vector3 centreDuTyphon;
                    GetPlayerPosition();
                    eSpeed = 1.2f;
                    centreDuTyphon = transform.position - typhonActiveScript.gameObject.transform.position;
                    Vector3 typhonDirection = pPos.normalized + centreDuTyphon.normalized;
                    transform.position -= typhonDirection.normalized * eSpeed * Time.deltaTime;

                    transform.RotateAround(typhonActiveScript.gameObject.transform.position, Vector3.forward, 90 * Time.deltaTime);
                }
            }
            else if (!playerParent.activeSelf)
            {
                transform.position += Vector3.zero;
            }
        }

    }

    public void GetPlayerPosition()
    {
        pPos = transform.position - player.transform.position;
    }

    void GoToPlayerPosition()
    {
        transform.position -= pPos.normalized * eSpeed * Time.deltaTime;
    }

    void CheckTooFar()
    {
        if (transform.position.x > player.transform.position.x + 30)
        {
            transform.position = new Vector3(player.transform.position.x - 25, transform.position.y + Random.Range(-15, 15));
        }

        if (transform.position.x < player.transform.position.x - 30)
        {
            transform.position = new Vector3(player.transform.position.x + 25, transform.position.y + Random.Range(-15, 15));
        }

        if (transform.position.y > player.transform.position.y + 20)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - 17);
        }

        if (transform.position.y < player.transform.position.y - 20)
        {
            transform.position = new Vector3(transform.position.x + Random.Range(-25, 25), player.transform.position.y + 17);
        }
    }

    public void Death()
    {
        nombreEnemyTue++;
        Destroy(gameObject);
    }

    void DisplayTextDamage(int damageToDisplay)
    {
        GameObject textI;
        damageTextScript actTScript;
        actualDamageTextScript = damageText.GetComponent<damageTextScript>();
        actualDamageTextScript.ApplyTextDamage(damageToDisplay);
        textI = Instantiate(damageText, gameObject.transform.position, transform.rotation);
        actTScript = textI.gameObject.GetComponent<damageTextScript>();
        actTScript.damageType = colorToPass;
        colorToPass = 0;
    }

    public void Paralysis()
    {
        paralyzed = true;
        eSpeed = 0;
        StartCoroutine(ParalysisRoutine());
    }

    public void GetVulnerability()
    {
        if (elemScript.elementActuel != 0)
        {

        }
        else
        {

            elemScript.elementActuel = 4;
        }
    }

    public void GetVulnerabilityDamage(int baseDamage)
    {
        int damageToAdd;
        damageToAdd = Mathf.RoundToInt(baseDamage * (elemScript.puissanceDeVulnerabilite / 100));

        if (baseDamage + damageToAdd == baseDamage)
        {
            damageToAdd += 1;
        }

        damageReceived += damageToAdd;

        DamageApplication();
    }

    public void BecomingFroze(bool isNovaH)
    {
        bool novaCheck;

        freezed = true;
        sprRenderer.color = Color.cyan;
        if(isNovaH)
        {
            novaCheck = true;
        }
        else { novaCheck = false; }
        StartCoroutine(FreezeRoutine(novaCheck));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if (explosedOne)
            {
                explosedOne = false;
            }

            novaH = collision.gameObject.GetComponent<novaHScript>();

            novaH.NovaEnemyCount(this.GetComponent<enemyScript>());

            if (elemScript.elementActuel == 2)
            {
                elemScript.elementActuel = 0;
                sprRenderer.color = Color.magenta;
                waitForExplosion = true;
                explosedOne = true;
                StartCoroutine(ExplosionRoutine());
            }
            else
            {
                BecomingFroze(true);
            }
            
        }

        if (collision.gameObject.layer == 10)
        {
            scr_ScieBehaviour scieScript;
            scieScript = collision.GetComponent<scr_ScieBehaviour>();

            scieScript.ApplyScieDamage(this.GetComponent<enemyScript>());
            scieScript.CheckElementActive(this.GetComponent<scr_ElementsRemanentsLogic>());
        }

        if (collision.gameObject.layer == 13)
        {
            scr_FireLogic fireScript;
            fireScript = collision.gameObject.GetComponent<scr_FireLogic>();
            damageReceived = fireScript.damage;
            colorToPass = 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            scr_MeteoreOmbreBehavior napalmScriptActive;
            napalmScriptActive = collision.GetComponent<scr_MeteoreOmbreBehavior>();
            if (elemScript.elementActuel != 0)
            {

            }
            else if (napalmScriptActive.isNapalm)
            { elemScript.elementActuel = 6; }

            if (napalmScriptActive.isNapalm && !DotFlagged)
            {
                damageReceived = napalmScriptActive.damage;
                DotFlagged = true;
                colorToPass = 1;
            }
        }

        if (collision.gameObject.layer == 12)
        {
            typhonActiveScript = collision.gameObject.GetComponent<scr_TyphonBehaviour>();
            typhoned = true;

            if (!dotTyphonFlagged)
            {
                damageReceived = typhonActiveScript.damage;
                dotTyphonFlagged = true;
                colorToPass = 3;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            typhoned = false;

            if (elemScript.elementActuel !=0)
            {

            }
            else
            { elemScript.elementActuel = 1; }
        }
        if (collision.gameObject.layer == 15)
        {
            tornaded = false;
        }
    }
}
