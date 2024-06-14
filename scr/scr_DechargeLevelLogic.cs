using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DechargeLevelLogic : MonoBehaviour
{
    public void CheckLevel(scr_armeLevelUp armeScript, scr_DechargeLogic dechargeScript)
    {
        switch (armeScript.armeLevel)
        {
            case 1:
                dechargeScript.damage = 10;
                dechargeScript.damagePropagation = 0;
                dechargeScript.cerclesMax = 1;
                dechargeScript.dechargeFireRate = 4.5f;
                break;

            case 2:
                dechargeScript.damage = 12;
                dechargeScript.damagePropagation = 4;
                dechargeScript.cerclesMax = 1;
                dechargeScript.dechargeFireRate = 4.5f;
                break;

            case 3:
                dechargeScript.damage = 12;
                dechargeScript.damagePropagation = 4;
                dechargeScript.cerclesMax = 2;
                dechargeScript.dechargeFireRate = 4.5f;
                break;

            case 4:
                dechargeScript.damage = 15;
                dechargeScript.damagePropagation = 7;
                dechargeScript.cerclesMax = 2;
                dechargeScript.dechargeFireRate = 4f;
                break;

            case 5:
                dechargeScript.damage = 15;
                dechargeScript.damagePropagation = 7;
                dechargeScript.cerclesMax = 3;
                dechargeScript.dechargeFireRate = 4f;
                break;

            case 6:
                dechargeScript.damage = 20;
                dechargeScript.damagePropagation = 10;
                dechargeScript.cerclesMax = 3;
                dechargeScript.dechargeFireRate = 3.5f;
                break;

            case 7:
                dechargeScript.damage = 20;
                dechargeScript.damagePropagation = 10;
                dechargeScript.cerclesMax = 4;
                dechargeScript.dechargeFireRate = 3.5f;
                break;

            case 8:
                dechargeScript.damage = 25;
                dechargeScript.damagePropagation = 15;
                dechargeScript.cerclesMax = 4;
                dechargeScript.dechargeFireRate = 3f;
                break;

            case 9:
                dechargeScript.damage = 30;
                dechargeScript.damagePropagation = 20;
                dechargeScript.cerclesMax = 5;
                dechargeScript.dechargeFireRate = 3f;
                break;
        }
    }
}
