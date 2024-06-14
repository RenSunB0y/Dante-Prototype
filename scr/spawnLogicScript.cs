using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnLogicScript : MonoBehaviour
{
    public GameObject sH;
    public GameObject sB;
    public GameObject sG;
    public GameObject sD;
    public GameObject enemy;
    public GameObject player;

    public GameObject fantome;
    public GameObject squelette;

    public float rYPos;
    public float rXPos;

    public List<GameObject> nombreEnemy = new List<GameObject>();

    public float spawnTimer;
    public float spawnRate;
    public int maxEnemies;

    public static int nombreDeVagues;
    public static int nombreDeRun;

    // Start is called before the first frame update
    void Start()
    {

        nombreDeVagues = 0;
        maxEnemies = 500;

        spawnTimer = 0;

        rYPos = Random.Range(-20, 20);
        rXPos = Random.Range(-32, 32);

        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        switch (nombreDeVagues)
        {
            case 5:
                spawnRate = 2;
                break;


            case 30:
                spawnRate = 1;
                break;

            case 100:
                spawnRate = .5f;
                break;
    }


        if (spawnTimer >= spawnRate)
        {

            nombreEnemy.AddRange(GameObject.FindGameObjectsWithTag("mechant"));
            //Debug.Log(nombreEnemy.Count);
            rYPos = Random.Range(-20, 20);
            rXPos = Random.Range(-32, 32);
            if (nombreEnemy.Count < maxEnemies)
            {
                SpawnEnemy();
            }

            spawnTimer =0;
            nombreEnemy.Clear();
        }

        else
        {
            spawnTimer += 1 * Time.deltaTime;
        }   
    }

    void SpawnEnemy()
    {
        if (spawnLogicScript.nombreDeVagues >= 30 && spawnLogicScript.nombreDeVagues < 75)
        {
            enemy = fantome;
        }

        else if (spawnLogicScript.nombreDeVagues >= 75)
        {

            enemy = squelette;
        }

        Vector3 posG = new Vector3(sG.transform.position.x, rYPos);
        Instantiate(enemy, posG, transform.rotation);

        Vector3 posD = new Vector3(sD.transform.position.x, rYPos);
        Instantiate(enemy, posD, transform.rotation);

        Vector3 posH = new Vector3(rXPos, sH.transform.position.y);
        Instantiate(enemy, posH, transform.rotation);

        Vector3 posB = new Vector3(rXPos, sB.transform.position.y);
        Instantiate(enemy, posB, transform.rotation);

        nombreDeVagues += 1;
    }
}
