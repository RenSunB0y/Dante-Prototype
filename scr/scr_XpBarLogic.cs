using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_XpBarLogic : MonoBehaviour
{
    public Image xpBar;
    public xpManagerScript xpScript;

    public void UpdateXpBar()
    {
        xpBar.fillAmount = Mathf.Clamp(xpScript.xp / xpScript.xpPourPasserAuLevelSuivant, 0, 1f);
    }
}
