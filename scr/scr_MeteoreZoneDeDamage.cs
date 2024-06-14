using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_MeteoreZoneDeDamage : MonoBehaviour
{
    public scr_MeteoreLogic mScript;
    public enemyScript actualCollidedEnemyScript;


    IEnumerator DisappearCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        mScript = GameObject.FindGameObjectsWithTag("arme")[4].GetComponent<scr_MeteoreLogic>();
        StartCoroutine(DisappearCoroutine());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            actualCollidedEnemyScript = collision.gameObject.GetComponent<enemyScript>();

            actualCollidedEnemyScript.damageReceived += mScript.damage;
            actualCollidedEnemyScript.colorToPass = 1;
        }
    }
}
