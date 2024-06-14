using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercolliderScript : MonoBehaviour
{
    public Collider2D pCollider;
    public float hp;
    public float maxHp;

    public GameObject playerParent;
    public GameObject gameoverScreen;
    public GameObject collidedXp;

    public float immuneTimer;
    public float immuneRate;

    public enemyScript _collidedEnemyScript;
    public xpBehavior xpObjectScript;

    public xpManagerScript xpManaScr;

    public SpriteRenderer sprRenderer;
    public Color defaultColor;

    public scr_HealthBarLogic healthBar;

    IEnumerator TimeBeforeGettingXp()
    {
        yield return new WaitForSeconds(Random.Range(0f, .7f));
        xpManaScr.GetXp(xpObjectScript.xpValue);
        
    }

    IEnumerator HitFrameRoutine()
    {
        yield return new WaitForSeconds(.1f);

        sprRenderer.color = defaultColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = sprRenderer.color;
        xpManaScr = GameObject.FindGameObjectWithTag("manager").GetComponent<xpManagerScript>();
        collidedXp = GameObject.FindGameObjectWithTag("xp");

        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

        if (hp <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        playerParent.SetActive(false);
        gameoverScreen.SetActive(true);

    }

    

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (immuneTimer <= 0)
            {
                _collidedEnemyScript = collision.gameObject.GetComponent<enemyScript>();

                if (_collidedEnemyScript.freezed == false)
                {
                    hp-= _collidedEnemyScript.damageDealt;
                    immuneTimer = immuneRate;
                    sprRenderer.color = Color.red;
                    healthBar.UpdateHealthBar();
                }
            }
            else
            {
                immuneTimer -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 6 && sprRenderer.color != defaultColor)
        {
            //StartCoroutine(HitFrameRoutine());
            sprRenderer.color = defaultColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            xpObjectScript = collision.gameObject.GetComponent<xpBehavior>();

            StartCoroutine(TimeBeforeGettingXp());
            Destroy(collision.gameObject);
        }
    }
}
