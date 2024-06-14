using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class damageTextScript : MonoBehaviour
{
    public TextMeshPro damageText;
    public float textMoveSpeed;
    public Color textcolor;
    public float alphaDisappearSpeed;
    public float disappearTimer;

    public int damageType;

    IEnumerator DestroyCouroutine()
    {
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }

    private void Awake()
    {
        //damageText = gameObject.GetComponent<TextMeshPro>();
    }
    // Start is called before the first frame update
    void Start()
    {

        SetTextColor();

        textcolor = damageText.color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * textMoveSpeed* Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            textcolor.a -= alphaDisappearSpeed * Time.deltaTime;
            damageText.color = textcolor;
            if (textcolor.a < 0)
            { Destroy(gameObject); }
        }
    }

    void SetTextColor()
    {
         switch (damageType)
        {
            case 1:
                damageText.color = Color.red;
                break;
            case 2:
                damageText.color = Color.yellow;
                break;
            case 3:
                damageText.color = Color.blue;
                break;
            case 4:
                damageText.color = Color.cyan;
                break;
            case 5:
                damageText.color = Color.gray;
                break;
        }
    }

    public void ApplyTextDamage(int textApplied)
    {
        damageText.SetText(textApplied.ToString());
    }
}
