using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_NovaLevelLogic : MonoBehaviour
{
    public void CheckLevel(scr_armeLevelUp armeScript, NovaScript nScript)
    {
        if(armeScript.armeLevel == 1)
        {
            nScript.damageMultiplier = 1;
            nScript.vectorRange = new Vector3(5,5,1);
            nScript.novaFireRate = 5;
        }

        if (armeScript.armeLevel == 2)
        {
            nScript.damageMultiplier = 1;
            nScript.vectorRange = new Vector3(5,5,1);
            nScript.novaFireRate = 4.5f;
        }

        if (armeScript.armeLevel == 3)
        {
            nScript.damageMultiplier = 1;
            nScript.vectorRange = new Vector3(6,6,1);
            nScript.novaFireRate = 4.5f;
        }

        if (armeScript.armeLevel == 4)
        {
            nScript.damageMultiplier = 1.5f;
            nScript.vectorRange = new Vector3(6,6,1) ;
            nScript.novaFireRate = 4;
        }

        if (armeScript.armeLevel == 5)
        {
            nScript.damageMultiplier = 1.5f;
            nScript.vectorRange = new Vector3(7,7,1);
            nScript.novaFireRate = 4;
        }

        if (armeScript.armeLevel == 6)
        {
            nScript.damageMultiplier = 1.5f ;
            nScript.vectorRange = new Vector3(7,7,1);
            nScript.novaFireRate = 3.5f;
        }

        if (armeScript.armeLevel == 7)
        {
            nScript.damageMultiplier = 1.5f;
            nScript.vectorRange = new Vector3(8,8,1);
            nScript.novaFireRate = 3.5f;
        }

        if (armeScript.armeLevel == 8)
        {
            nScript.damageMultiplier = 2;
            nScript.vectorRange = new Vector3(8,8,1);
            nScript.novaFireRate = 3.5f;
        }

        if (armeScript.armeLevel == 9)
        {
            nScript.damageMultiplier = 2;
            nScript.vectorRange = new Vector3(8,8,1);
            nScript.novaFireRate = 3;
        }
    }
}
