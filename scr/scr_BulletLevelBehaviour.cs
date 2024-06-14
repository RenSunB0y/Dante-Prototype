using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_BulletLevelBehaviour : MonoBehaviour
{
    public void CheckLevel(scr_armeLevelUp armeScript, weapon1Script bulletScript)
    {
        if (armeScript.armeLevel == 1)
        {
            bulletScript.nombreDeProjectiles = 1;
            bulletScript.damage = 12;
            bulletScript.nombreDeCibles = 1;
        }

        if (armeScript.armeLevel == 2)
        { 
            bulletScript.nombreDeProjectiles = 2;
            bulletScript.damage = 12;
            bulletScript.nombreDeCibles = 1;
        }

        if (armeScript.armeLevel == 3)
        {
            bulletScript.nombreDeProjectiles = 3;
            bulletScript.damage = 12;
            bulletScript.nombreDeCibles = 1;
        }

        if (armeScript.armeLevel == 4)
        {
            bulletScript.nombreDeProjectiles = 3;
            bulletScript.damage = 12;
            bulletScript.nombreDeCibles = 2;
        }

        if (armeScript.armeLevel == 5)
        {
            bulletScript.nombreDeProjectiles = 3;
            bulletScript.damage = 20;
            bulletScript.nombreDeCibles = 2;
        }

        if (armeScript.armeLevel == 6)
        {
            bulletScript.nombreDeProjectiles = 4;
            bulletScript.damage = 20;
            bulletScript.nombreDeCibles = 2;
        }

        if (armeScript.armeLevel == 7)
        {
            bulletScript.nombreDeProjectiles = 5;
            bulletScript.damage = 20;
            bulletScript.nombreDeCibles = 2;
        }

        if (armeScript.armeLevel == 8)
        {
            bulletScript.nombreDeProjectiles = 5;
            bulletScript.damage = 20;
            bulletScript.nombreDeCibles = 3;
        }

        if (armeScript.armeLevel == 9)
        {
            bulletScript.nombreDeProjectiles = 5;
            bulletScript.damage = 30;
            bulletScript.nombreDeCibles = 3;
        }

    }
}
