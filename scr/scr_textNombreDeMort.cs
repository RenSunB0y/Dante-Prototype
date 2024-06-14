using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scr_textNombreDeMort : MonoBehaviour
{
    public TMP_Text textAffiche;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textAffiche.SetText( enemyScript.nombreEnemyTue + " kills");
    }
}
