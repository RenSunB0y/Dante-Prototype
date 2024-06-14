using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xpManagerScript : MonoBehaviour
{
    public GameObject chooseScreen;
    public Text textBoutonChoose1;
    public Text textBoutonChoose2;
    public Text textBoutonChoose3;

    public float xp;
    public scr_XpBarLogic xpBar;
    public int actualLevel;
    public float xpPourPasserAuLevelSuivant;

    public List<GameObject> armes = new List<GameObject>();

    public List<GameObject> propositions = new List<GameObject>();

    public static List<GameObject> armesDejaEnPossession = new List<GameObject>();
    public int armesMax;
    public int armesdep;

    public int aLength;

    public scr_armeLevelUp levelupScript;


    // Start is called before the first frame update
    void Start()
    {
        armesMax = 4;

        ArmesListe();

        xp = 0;
        actualLevel = 1;
        xpPourPasserAuLevelSuivant = 4;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ArmesListe()
    {
        armes.Clear();
        if (scr_armeLevelUp.nombreArmes != armesMax)
        { 
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("arme").Length; i++)
            {
                armes.Add(GameObject.FindGameObjectsWithTag("arme")[i]);
            }
        }
        else
        {
            for (int i = 0; i < armesDejaEnPossession.Count; i++)
            {
                armes.Add(armesDejaEnPossession[i]);
            }
        }

        aLength = armes.Count;
    }

    public void GetXp(float xpValueArgument)
    {
        if (xp < xpPourPasserAuLevelSuivant - 1)
        {
            xp += xpValueArgument;
            xpBar.UpdateXpBar();
        }
        else
        {
            LevelUp();
            xpBar.UpdateXpBar();
        }
    }

    void LevelUp()
    {
        xp = 0;
        actualLevel += 1;
        xpPourPasserAuLevelSuivant *= (float)1.7;
        xpPourPasserAuLevelSuivant = Mathf.Round(xpPourPasserAuLevelSuivant);

        ChooseAPower();
    }

    void ChooseAPower()
    {
        Time.timeScale = 0;
        BoutonsCreation(3);

        chooseScreen.SetActive(true);
    }

    void BoutonsCreation(int nombreDeProposition)
    {
        int _resultatRandom;

        for (int i = 0; i < nombreDeProposition; i++)
        {
            _resultatRandom = Random.Range(0, aLength);
            propositions.Add(armes[_resultatRandom]);
            armes.RemoveAt(_resultatRandom);
            aLength = armes.Count;
            
        }
        
            textBoutonChoose1.text = propositions[0].name;
            textBoutonChoose2.text = propositions[1].name;
            textBoutonChoose3.text = propositions[2].name;
        
    }

#region
    public void Un()
        {
            PowerChosen(0);
        }
        public void Deux()
        {
            PowerChosen(1);
        }
        public void Trois()
        {
            PowerChosen(2);
        }
#endregion

    public void PowerChosen(int boutonChoisi)
    {
        levelupScript = propositions[boutonChoisi].GetComponent<scr_armeLevelUp>();
        levelupScript.armeLevelUp();
        chooseScreen.SetActive(false);
        ArmesListe();
        propositions.Clear();
        Time.timeScale = 1;
    }
}
