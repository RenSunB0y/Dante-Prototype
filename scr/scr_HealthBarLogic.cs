using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_HealthBarLogic : MonoBehaviour
{
    public Image healthBarImage;
    public playercolliderScript player;

    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(player.hp / player.maxHp, 0, 1f);
    }

}
