using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    public Vector3 bulletDirection;

    public playerScript pScript;
    public enemyScript actualCollidedEnemyScript;

    public weapon1Script weaponScript;
    public int nombreActuelDeCible;

    public float bulletSpeed;

    public float lifeTime;
    public float lifeCounter;

    // Start is called before the first frame update
    void Start()
    {
        pScript = GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<playerScript>();

        bulletDirection = pScript.passedPlayerDirection.normalized;
        nombreActuelDeCible = weaponScript.nombreDeCibles;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletDirection * bulletSpeed *Time.deltaTime;

        if (lifeCounter >= lifeTime)
            { Destruction(); }
        else { lifeCounter += 1 * Time.deltaTime; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            actualCollidedEnemyScript = collision.gameObject.GetComponent<enemyScript>();

            actualCollidedEnemyScript.damageReceived = weaponScript.damage;

            if (nombreActuelDeCible <= 1)
            {
                Destruction();
            }
            else
            {
                Debug.Log("cible -1");  
                 nombreActuelDeCible -= 1;
            }
        }
    }


    void Destruction()
    {
        Destroy(gameObject);
    }
}
