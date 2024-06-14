using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ScieBehaviour : MonoBehaviour
{
    public scr_Scie scieScript;
    public int elementPropage;

    public Vector3 vectorDirection;

    public SpriteRenderer sprRenderer;

    IEnumerator DisappearCoroutine()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisappearCoroutine());
        sprRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.parent.transform.position, vectorDirection, 360 * Time.deltaTime);
    } 

    public void ApplyScieDamage(enemyScript actualCollidedEnemyScript)
    {
        if (!actualCollidedEnemyScript.freezed)
        {
            actualCollidedEnemyScript.damageReceived += scieScript.damage;
        }
        else
        {
            actualCollidedEnemyScript.damageReceived += actualCollidedEnemyScript.hp;
        }
    }

    public void CheckElementActive(scr_ElementsRemanentsLogic elemScript)
    {
        if(elemScript.elementActuel != 0)
        {

        }
        else { elemScript.elementActuel = 3; }
    }

    void ChangeColor()
    {
        switch (elementPropage)
        {
            case 1:
                sprRenderer.color = Color.blue;
                break;
            case 2:
                sprRenderer.color = Color.yellow;
                break;
            case 4:
                sprRenderer.color = Color.grey;
                break;
            case 5:
                sprRenderer.color = Color.cyan;
                break;
            case 6:
                sprRenderer.color = Color.red;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            scr_ElementsRemanentsLogic elemScript;
            elemScript = collision.gameObject.GetComponent<scr_ElementsRemanentsLogic>();

            if (elementPropage == 0)
            {
                elementPropage = elemScript.elementActuel;

                ChangeColor();
            }
            else
            {
                elemScript.elementActuel = elementPropage;
            }
        }
    }
}