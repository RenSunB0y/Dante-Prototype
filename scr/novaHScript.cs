using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class novaHScript : MonoBehaviour
{
    public enemyScript actualCollidedEnemyScript;

    public int damage;

    public int nombreEnemy;

    public float overlapCircleRadius;

    public NovaScript nScript;


    public Collider2D[] results;
    public int nombreEnemyNova;

    IEnumerator NovaDisappearRoutine()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = nScript.vectorRange;
        overlapCircleRadius = nScript.vectorRange.x / 2;
        nombreEnemy = 0;
        StartCoroutine(NovaDisappearRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NovaEnemyCount(enemyScript eScript)
    {
        Destroy(gameObject.GetComponent<CircleCollider2D>());
        results = Physics2D.OverlapCircleAll(gameObject.transform.position, overlapCircleRadius, LayerMask.GetMask("enemies"), -1f, 100f); //a essayer : collider2D.Overlapcollider
        nombreEnemyNova = results.Length;

        ApplyDamage(eScript, nombreEnemyNova);
    }

    public void ApplyDamage(enemyScript actualEnemyScript, int nombreEnemyNova)
    {
        GetDamage(nombreEnemyNova);
        actualEnemyScript.colorToPass = 4;
        actualEnemyScript.damageReceived = damage;
        
    }

    public void CheckElementActive(scr_ElementsRemanentsLogic elemScript)
    {
        if (elemScript.elementActuel != 0)
        {

        }
        else { elemScript.elementActuel = 5; }
    }

    void GetDamage(int nombreEnemy)
    {
        if (nombreEnemy <= 3)
        {
            damage = Mathf.RoundToInt(2 * nScript.damageMultiplier);
        }
        else if (nombreEnemy <= 9)
        {
            damage = Mathf.RoundToInt(5 * nScript.damageMultiplier);
        }
        else if (nombreEnemy <= 15)
        {
            damage = Mathf.RoundToInt(8 * nScript.damageMultiplier);
        }
        else if (nombreEnemy <= 20)
        {
            damage = Mathf.RoundToInt(10 * nScript.damageMultiplier);
        }
        else if (nombreEnemy > 20)
        {
            damage = Mathf.RoundToInt(11 * nScript.damageMultiplier);
        }
    }

    


}
