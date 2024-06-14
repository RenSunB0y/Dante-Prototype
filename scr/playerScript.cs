using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public CharacterController charCtrl;
    public float hInput;
    public float vInput;
    public float pSpeed;

    public Vector3 actualPlayerDirection;
    public Vector3 passedPlayerDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

    }

    private void FixedUpdate()
    {
        Move();
    }


    void GetInput()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
    }

    void Move()
    {
        actualPlayerDirection = new Vector3 (hInput, vInput, 0);

        if (actualPlayerDirection.x != 0 || actualPlayerDirection.y != 0)
        {
            passedPlayerDirection = actualPlayerDirection;
        }
        else if (passedPlayerDirection.x == 0 && passedPlayerDirection.y == 0)
        {
            passedPlayerDirection = Vector3.right;
        }

        charCtrl.Move(actualPlayerDirection.normalized * pSpeed);
    }

}
