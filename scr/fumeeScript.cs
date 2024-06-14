using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fumeeScript : MonoBehaviour
{
    public Color defaultColor;
    public SpriteRenderer sprRenderer;
    public float disappearSpeed;

    // Start is called before the first frame update
    void Start()
    {
        sprRenderer = gameObject.GetComponent<SpriteRenderer>();
        defaultColor = sprRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (defaultColor.a > 0)
        {
            defaultColor.a -= disappearSpeed * Time.deltaTime;
            sprRenderer.color = defaultColor;
        }
        else
        { Destroy(gameObject); }
    }
}
