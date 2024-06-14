using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject player;
    public Vector3 pVect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pVect = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        transform.position = pVect;
    }
}
