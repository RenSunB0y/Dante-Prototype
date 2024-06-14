using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_MeteoreBehaviour : MonoBehaviour
{
    public Transform parent;
    public scr_MeteoreOmbreBehavior scrOmbreParente;

    public GameObject zoneDeDamage;
    public float actualY;

    public Vector3 pPos;
    public float mSpeed;

    public bool meteoreFallenTrigger;

    IEnumerator StartNapalmRoutine()
    {
        yield return new WaitForSeconds(.1f);
        scrOmbreParente.isNapalm = true;

        MeteoreFallen();
    }

    // Start is called before the first frame update

    void Start()
    {
        meteoreFallenTrigger = false;
        GetOmbrePosition();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        YPositif();
    }

    void Move()
    {
        if (actualY < 0 && !meteoreFallenTrigger)
        {
            meteoreFallenTrigger = true;
            pPos = Vector3.zero;
            transform.position += Vector3.zero;
            StartCoroutine(StartNapalmRoutine());

        }
        else if (pPos != Vector3.zero)
        {
            GetOmbrePosition();
            GoToOmbrePosition();
        }
    }

    public void GetParent(GameObject ombre)
    {
        parent = ombre.transform;
        scrOmbreParente = ombre.GetComponent<scr_MeteoreOmbreBehavior>();
    }

    void GetOmbrePosition()
    {
        pPos = transform.position - parent.position;
    }

    void GoToOmbrePosition()
    {
        transform.position -= pPos.normalized * mSpeed * Time.deltaTime;
    }

    void MeteoreFallen()
    {
        Instantiate(zoneDeDamage, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void YPositif()
    {
        actualY = transform.position.y - parent.position.y;
    }
}
