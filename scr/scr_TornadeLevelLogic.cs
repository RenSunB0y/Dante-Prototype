using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TornadeLevelLogic : MonoBehaviour
{
    public void CheckLevel(scr_armeLevelUp armeScript, scr_Tornade tScript)
    {
        switch (armeScript.armeLevel)
        {
            case 1:
                tScript.damage = 1;
                tScript.tornadeFireRate = 5;
                tScript.nombreDeTornades = 1;
                break;

            case 2:
                tScript.damage = 1;
                tScript.tornadeFireRate = 4.5f;
                tScript.nombreDeTornades = 1;
                break;

            case 3:
                tScript.damage = 2;
                tScript.tornadeFireRate = 4.5f;
                tScript.nombreDeTornades = 1;
                break;

            case 4:
                tScript.damage = 2;
                tScript.tornadeFireRate = 4;
                tScript.nombreDeTornades = 1;
                    break;

            case 5:
                tScript.damage = 2;
                tScript.tornadeFireRate = 4;
                tScript.nombreDeTornades = 2;
                break;

            case 6:
                tScript.damage = 3;
                tScript.tornadeFireRate = 4;
                tScript.nombreDeTornades = 2;
                break;

            case 7:
                tScript.damage = 3;
                tScript.tornadeFireRate = 3.5f;
                tScript.nombreDeTornades = 2;
                break;

            case 8:
                tScript.damage = 4;
                tScript.tornadeFireRate = 3.5f;
                tScript.nombreDeTornades = 2;
                break;

            case 9:
                tScript.damage = 4;
                tScript.tornadeFireRate = 3;
                tScript.nombreDeTornades = 4; // pas sur de ca
                break;

        }
    }
}
