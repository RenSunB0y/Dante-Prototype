using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ExplosionLogic : MonoBehaviour
{
    public enemyScript eScript;

    public int explosionDamage;
    public int colateralDamage;

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            eScript = collision.gameObject.GetComponent<enemyScript>();
            if(eScript.explosedOne == false)
            eScript.damageReceived = colateralDamage;
            eScript.colorToPass = 2;
        }
    }
}
