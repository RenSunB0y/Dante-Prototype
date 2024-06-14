using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_MeteoreLevelLogic : MonoBehaviour
{
    public void CheckLevel(scr_armeLevelUp armeScript, scr_MeteoreLogic mScript)
    {
        switch (armeScript.armeLevel)
        {
            case 1:
                mScript.meteoreFireRate = 6;
                mScript.nombreDeMeteores = 1;
                mScript.damage = 10;
                break;

            case 2:
                mScript.meteoreFireRate = 5.5f;
                mScript.nombreDeMeteores = 1;
                mScript.damage = 10;
                break;

            case 3:
                mScript.meteoreFireRate = 5.5f;
                mScript.nombreDeMeteores = 2;
                mScript.damage = 10;
                break;

            case 4:
                mScript.meteoreFireRate = 5;
                mScript.nombreDeMeteores = 2;
                mScript.damage = 15;
                break;

            case 5:
                mScript.meteoreFireRate = 5;
                mScript.nombreDeMeteores = 3;
                mScript.damage = 15;
                break;

            case 6:
                mScript.meteoreFireRate = 4.5f;
                mScript.nombreDeMeteores = 3;
                mScript.damage = 15;
                break;

            case 7:
                mScript.meteoreFireRate = 4.5f;
                mScript.nombreDeMeteores = 4;
                mScript.damage = 20;
                break;

            case 8:
                mScript.meteoreFireRate = 4;
                mScript.nombreDeMeteores = 4;
                mScript.damage = 20;
                break;

            case 9:
                mScript.meteoreFireRate = 4;
                mScript.nombreDeMeteores = 5;
                mScript.damage = 25;
                break;
        }
    }
}
