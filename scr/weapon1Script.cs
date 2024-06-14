using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon1Script : MonoBehaviour
{
    public float fireRate;
    public float fireTimer;

    public int nombreDeProjectiles;
    public int nombreDeCibles;
    public int damage;

    public int nombreActuelDeProjectiles;

    public float projectileTimer;
    public float projectileRate;

    public GameObject bullet;
    public GameObject instantiatedBullet;
    public bulletBehavior bScript;

    public scr_armeLevelUp armeScript;
    public scr_BulletLevelBehaviour levelScript;

    IEnumerator RestartFireCoroutine()
    {
        yield return new WaitForSeconds(.2f);

        Fire();
    }

    // Start is called before the first frame update
    void Start()
    {
        nombreActuelDeProjectiles = 0;
        levelScript = gameObject.GetComponent<scr_BulletLevelBehaviour>();
        armeScript = gameObject.GetComponent<scr_armeLevelUp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (armeScript.isActive == true)
        {
            FlingueActive();
        }
        
    }

    void FlingueActive()
    {
        if (fireTimer >= fireRate)
        {
            levelScript.CheckLevel(armeScript, this);
            Fire();
            fireTimer = 0;
        }
        else fireTimer += 1 * Time.deltaTime;
    }

    void Fire()
    {
        nombreActuelDeProjectiles += 1;
        instantiatedBullet = Instantiate(bullet, transform.position, transform.rotation);
        bScript = instantiatedBullet.GetComponent<bulletBehavior>();
        bScript.weaponScript = this;

        if (nombreActuelDeProjectiles< nombreDeProjectiles)
        {
            StartCoroutine(RestartFireCoroutine());
        }
        else
        {
            nombreActuelDeProjectiles = 0;
        }
    }
}
