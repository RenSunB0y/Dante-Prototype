using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_MeteoreLogic : MonoBehaviour
{
    public float meteoreFireRate;
    public float meteoreTimer;

    public int damage;
    public int nombreDeMeteores;

    public int spawnerSelectione;
    public Vector3 instPos;

    public scr_armeLevelUp armeScript;
    public scr_MeteoreLevelLogic logicScript;

    public GameObject ombre;
    public GameObject ombreOmbre;
    public GameObject instantiatedOmbre;

    public GameObject[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        logicScript = gameObject.GetComponent<scr_MeteoreLevelLogic>();
        armeScript = gameObject.GetComponent<scr_armeLevelUp>();

        spawners = GameObject.FindGameObjectsWithTag("Meteore Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        if (armeScript.isActive)
        {
            MeteoreActive();
        }
    }

    void MeteoreActive()
    {   
        if (meteoreTimer >= meteoreFireRate)
        {
            logicScript.CheckLevel(armeScript, this);
            Meteore();
            meteoreTimer = 0;
        }
        else
        {
            meteoreTimer += 1 * Time.deltaTime;
        }
    }

    void Meteore()
    {
        spawnerSelectione = Random.Range(0, 4);
        instPos = new Vector3(spawners[spawnerSelectione].transform.position.x + Random.Range(-3, 3), spawners[spawnerSelectione].transform.position.y + Random.Range(-3, 3), spawners[spawnerSelectione].transform.position.z);

        instantiatedOmbre = Instantiate(ombre, instPos , spawners[spawnerSelectione].transform.rotation);
        instantiatedOmbre.transform.parent = transform;

        nombreDeMeteores -= 1;

        if (nombreDeMeteores >=1)
        { Meteore(); }
    }
}
