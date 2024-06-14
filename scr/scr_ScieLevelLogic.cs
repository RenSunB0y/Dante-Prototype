using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ScieLevelLogic : MonoBehaviour
{
    public void CheckLevel(scr_armeLevelUp armeScript, scr_Scie sScript)
    {
        switch (armeScript.armeLevel)
        {
            case 1:
                sScript.damage = 3;
                sScript.scieFireRate = 4;
                sScript.nombreDeScies = 1;
                break;
            case 2:
                sScript.damage = 5;
                sScript.scieFireRate = 4;
                sScript.nombreDeScies = 1;
                break;
            case 3:
                sScript.damage = 5;
                sScript.scieFireRate = 3.5f;
                sScript.nombreDeScies = 1;
                break;
            case 4:
                sScript.damage = 8;
                sScript.scieFireRate = 3.5f;
                sScript.nombreDeScies = 2;
                break;
            case 5:
                sScript.damage = 8;
                sScript.scieFireRate = 3;
                sScript.nombreDeScies = 2;
                break;
            case 6:
                sScript.damage = 12;
                sScript.scieFireRate = 3;
                sScript.nombreDeScies = 2;
                break;
            case 7:
                sScript.damage = 12;
                sScript.scieFireRate = 2.5f;
                sScript.nombreDeScies = 2;
                break;
            case 8:
                sScript.damage = 17;
                sScript.scieFireRate = 2.5f;
                sScript.nombreDeScies = 3;
                break;
            case 9:
                sScript.damage = 22;
                sScript.scieFireRate = 2;
                sScript.nombreDeScies = 3;
                break;
        }
    }
}
