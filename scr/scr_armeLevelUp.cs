using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_armeLevelUp : MonoBehaviour
{
    public bool isActive;
    public int armeLevel;
    public static int nombreArmes;

    //public xpManagerScript managerScript;

    // Start is called before the first frame update
    void Start()
    {
        if (isActive)
        {
            armeLevel = 1;
            xpManagerScript.armesDejaEnPossession.Add(gameObject);
            nombreArmes++;
        }
        else
        {
            armeLevel = 0;
        }
    }

    public void armeLevelUp()
    {
        if (!isActive)
        {
            isActive = true;
            nombreArmes++;
            xpManagerScript.armesDejaEnPossession.Add(gameObject);
            //Debug.Log(nombreArmes);
        }
        if (armeLevel < 9)
        { armeLevel += 1; }

    }
}
