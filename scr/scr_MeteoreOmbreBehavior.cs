using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_MeteoreOmbreBehavior : MonoBehaviour
{
    public bool isNapalm;
    public float yOffset;
    public float xOffset;
    public bool coroutineStarted;

    public float ombreDeliage;
    public float ombreTimer;

    public enemyScript actualCollidedEnemyScript;
    public int damage;

    public GameObject meteoreLie;
    public scr_MeteoreBehaviour scrMeteoreLie;
    public GameObject meteoreH;
    public Vector3 meteoreStartedPosition;

    public float duréeDeVieNapalm;

    IEnumerator DestroyCouroutine()
    {
        yield return new WaitForSeconds(duréeDeVieNapalm);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        isNapalm = false;

        xOffset = Random.Range(-16, 16);
        yOffset = 20 + Random.Range(0, 10);
    }
        

    // Update is called once per frame
    void Update()
    {
        if (isNapalm && !coroutineStarted)
        {
            coroutineStarted = true;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(DestroyCouroutine());
        }
        if (transform.parent)
        {
            if (ombreTimer >= ombreDeliage)
            {
                transform.parent = null;
                MeteoreOnAction();
            }
            else
            {
                ombreTimer += 1 * Time.deltaTime;
            }
        }
    }

    void MeteoreOnAction()
    {
        meteoreStartedPosition = new Vector3(gameObject.transform.position.x + xOffset, gameObject.transform.position.y + yOffset, gameObject.transform.position.z);

        meteoreLie = Instantiate(meteoreH, meteoreStartedPosition, gameObject.transform.rotation);
        meteoreLie.transform.parent = gameObject.transform;

        scrMeteoreLie = meteoreLie.GetComponent<scr_MeteoreBehaviour>();
        scrMeteoreLie.GetParent(gameObject);
    }
}
