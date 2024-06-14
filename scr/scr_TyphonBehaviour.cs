using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TyphonBehaviour : MonoBehaviour
{
    public float secondsBeforeDestroy;

    public bool isNova;

    public scr_TyphonLogic tScript;

    public int damage;
    public int dechargeDamage;

    public Collider2D[] results;
    public SpriteRenderer sprRenderer;
    public enemyScript eScript;

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(secondsBeforeDestroy);
        Destroy(gameObject);
    }

    IEnumerator DestroyCoroutineFaster()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(.5f);
        sprRenderer.color = Color.white;
    }


    void Start()
    {
        transform.localScale = transform.localScale * tScript.rangeMultiplier;
        damage = tScript.damage;
        StartCoroutine(DestroyCoroutine());
        sprRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            StartCoroutine(DestroyCoroutineFaster());
            results = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x/2, LayerMask.GetMask("enemies"), -1f, 10f);
            for (int i = 0; i < results.Length; i++)
            {
                eScript = results[i].GetComponent<enemyScript>();
                eScript.typhoned = false;

                eScript.BecomingFroze(false);
            }
            sprRenderer.color = Color.cyan;

            Color tmp = sprRenderer.color;
            tmp.a = .45f;
            sprRenderer.color = tmp;

            gameObject.layer = 0;
            isNova = true;
        }

        if (collision.gameObject.layer == 16 && !isNova)
        {
            results = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x/2, LayerMask.GetMask("enemies"), -1f, 10f);
            for (int i = 0; i < results.Length; i++)
            {
                eScript = results[i].GetComponent<enemyScript>();
                eScript.damageReceived += dechargeDamage;
                eScript.colorToPass = 2;
                sprRenderer.color = Color.yellow;
                StartCoroutine(ChangeColor());
            }
        }
    }


}
