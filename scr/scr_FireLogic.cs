using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_FireLogic : MonoBehaviour
{
    public int damage;
    public float dureeDeVieFire;
    public enemyScript eScript;

    IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(dureeDeVieFire);
        Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(DestroyRoutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        { Destroy(gameObject); }
    }
}
