using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TyphonLevelLogic : MonoBehaviour
{
    public void CheckLevel(scr_armeLevelUp armeScript, scr_TyphonLogic tScript)
    {
        switch (armeScript.armeLevel)
        {
            case 1:
                tScript.damage = 1;
                tScript.typhonFireRate = 6;
                tScript.rangeMultiplier = 1;
                tScript.nombreDeTyphon = 1;
                break;

            case 2:
                tScript.damage = 1;
                tScript.typhonFireRate = 5.5f;
                tScript.rangeMultiplier = 1;
                tScript.nombreDeTyphon = 1;
                break;

            case 3:
                tScript.damage = 1;
                tScript.typhonFireRate = 5.5f;
                tScript.rangeMultiplier = 1.1f;
                tScript.nombreDeTyphon = 1;
                break;

            case 4:
                tScript.damage = 5;
                tScript.typhonFireRate = 5f;
                tScript.rangeMultiplier = 1.1f;
                tScript.nombreDeTyphon = 1;
                break;

            case 5:
                tScript.damage = 5;
                tScript.typhonFireRate = 5f;
                tScript.rangeMultiplier = 1.2f;
                tScript.nombreDeTyphon = 2;
                break;

            case 6:
                tScript.damage = 5;
                tScript.typhonFireRate = 4.5f;
                tScript.rangeMultiplier = 1.2f;
                tScript.nombreDeTyphon = 2;
                break;

            case 7:
                tScript.damage = 7;
                tScript.typhonFireRate = 4.5f;
                tScript.rangeMultiplier = 1.3f;
                tScript.nombreDeTyphon = 2;
                break;

            case 8:
                tScript.damage = 7;
                tScript.typhonFireRate = 4f;
                tScript.rangeMultiplier = 1.3f;
                tScript.nombreDeTyphon = 2;
                break;

            case 9:
                tScript.damage = 10;
                tScript.typhonFireRate = 4f;
                tScript.rangeMultiplier = 1.5f;
                tScript.nombreDeTyphon = 2;
                break;
        }
    }
}
