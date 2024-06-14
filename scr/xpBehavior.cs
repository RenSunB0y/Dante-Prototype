using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpBehavior : MonoBehaviour
{
    public xpManagerScript xpScript;
    public float xpValue;

    // Start is called before the first frame update
    void Start()
    {
        xpScript= GameObject.FindGameObjectWithTag("manager").GetComponent<xpManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void Destruction()
    {
        Destroy(gameObject);
    }
}
