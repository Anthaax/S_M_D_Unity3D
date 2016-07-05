﻿using UnityEngine;
using System.Collections;
using S_M_D.Character;
using S_M_D.Camp;
using S_M_D;
using System.Collections.Generic;
using UnityEngine.UI;
using S_M_D.Camp.Class;

public class Start : MonoBehaviour {

    private static GameContext _gtx;

    public static GameObject MenuBGArmory;
    public static GameObject MenuBGTownhall;
    public static GameObject MenuBGBar;
    public static GameObject MenuBGCaravan;
    public static GameObject MenuBGCasern;
    public static GameObject MenuBGCemetery;
    public static GameObject MenuBGHospital;
    public static GameObject MenuBGMentalhospital;
    public static GameObject MenuBGHotel;
    public static GameObject MenuProfil;
    public static GameObject PanelBoardMission;
    public static GameObject MenuProfilPlayer;
    public static GameObject MenuProfilStuff;

    public static Button[] ButtonsSicknesses;
    public static Button[] ButtonsMentalPsycho;
    public static Button[] ButtonsTownHall;
    public static Button[] ButtonsArmor;
    public static List<GameObject> ButtonsBuildings;
    public static List<GameObject> CasernSpells;
    public static List<GameObject> pHeroes;
    public static List<GameObject> DeathHeroes;
    // Use this for initialization
    void Awake () {


        MenuBGArmory = GameObject.Find("MenuBGArmory");
        MenuBGTownhall = GameObject.Find("MenuBGTownhall");
        MenuBGBar = GameObject.Find("MenuBGBar");
        MenuBGCaravan = GameObject.Find("MenuBGCaravan");
        MenuBGCasern = GameObject.Find("MenuBGCasern");
        MenuBGCemetery = GameObject.Find("MenuBGCemetery");
        MenuBGHospital = GameObject.Find("MenuBGHospital");
        MenuBGMentalhospital = GameObject.Find("MenuBGMentalhospital");
        MenuBGHotel = GameObject.Find("MenuBGHotel");
        MenuProfil = GameObject.Find("Profil");
        PanelBoardMission = GameObject.Find("PanelBoardMission");
        MenuProfilPlayer = GameObject.Find("ProfilPlayer");
        MenuProfilStuff = GameObject.Find("ProfilStuff");

        ButtonsBuildings = new List<GameObject>(GameObject.FindGameObjectsWithTag("Building"));
        CasernSpells = new List<GameObject>(GameObject.FindGameObjectsWithTag("Spell"));
        CasernSpells.Sort((t1, t2) => string.Compare(t1.name, t2.name));
        pHeroes = new List<GameObject>(GameObject.FindGameObjectsWithTag("pHero"));
        DeathHeroes = new List<GameObject>(GameObject.FindGameObjectsWithTag("DeathHeroes"));

        ButtonsSicknesses = MenuBGHospital.GetComponentsInChildren<Button>();
        HospitalBoard.InitializedButtonsHospitalBoard();

        ButtonsMentalPsycho = MenuBGMentalhospital.GetComponentsInChildren<Button>();
        MentalHospitalBoard.InitializedButtonsMentalHospitalBoard();

        ButtonsArmor = MenuBGArmory.GetComponentsInChildren<Button>();

        ButtonsTownHall = MenuBGTownhall.GetComponentsInChildren<Button>();

        Caravan caravan = Gtx.PlayerInfo.GetBuilding(S_M_D.Camp.Class.BuildingNameEnum.Caravan) as Caravan;
        caravan.HerosDispo.Clear();
        caravan.Initialized();

        CasernBoard.SetBoard();

        setButtonsBuildings();
        //-----------------------
        
        setHeroesList();
        _gtx.PlayerInfo.MyHeros[0].IsDead = true;

        BarBoard.Init();
        HotelBoard.Init();
        HospitalBoard.Init();
        MentalHospitalBoard.Init();
        DesactiveBoard();

    }
	
    void DesactiveBoard()
    {
        MenuBGArmory.SetActive(false);
        MenuBGTownhall.SetActive(false);
        MenuBGBar.SetActive(false);
        MenuBGCaravan.SetActive(false);
        MenuBGCasern.SetActive(false);
        MenuBGCemetery.SetActive(false);
        MenuBGHospital.SetActive(false);
        MenuBGMentalhospital.SetActive(false);
        MenuBGHotel.SetActive(false);
        MenuProfil.SetActive(false);
        PanelBoardMission.SetActive(false);
        MenuProfilPlayer.SetActive(false);
        MenuProfilStuff.SetActive(false);
    }
    
	// Update is called once per frame
	void Update () {
        setHeroesList();
	}

    private void RemoveDeathHeroes()
    {
        int nb = -1;
        while(nb != 0)
        {
            nb = 0;
            foreach (BaseHeros heros in _gtx.PlayerInfo.MyHeros)
            {
                if (heros.IsDead)
                    nb++;
            }

            if (nb > 0)
            {
                foreach (BaseHeros heros in _gtx.PlayerInfo.MyHeros)
                {
                    if (heros.IsDead)
                    {
                        heros.Die();
                        break;
                    }
                }
                nb--;
            }
        }
    }

    private void ResetHeroesList()
    {
        for (int i = 0; i < pHeroes.Count; i++)
        {
            GameObject.Find("Hero" + (i + 1) + "T").GetComponent<Text>().text = "";
            GameObject.Find("Hero" + (i + 1) + "I").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Icones/HeroDefault");
        }
    }

    private void setHeroesList()
    {
        RemoveDeathHeroes();
        ResetHeroesList();
        for(int i = 0; i < _gtx.PlayerInfo.MyHeros.Count; i++)
        {
            BaseHeros heros = _gtx.PlayerInfo.MyHeros[i];
            string sex = heros.IsMale ? "M" : "F";
            GameObject.Find("Hero" + (i + 1) + "T").GetComponent<Text>().text = heros.CharacterName;
            GameObject.Find("Hero" + (i + 1) + "I").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Icones/" + heros.CharacterClassName + "Icone" + sex);
        }
    }

    private void setButtonsBuildings()
    {
        foreach(BaseBuilding building in Gtx.PlayerInfo.MyBuildings)
        {
            if (building.Level < 1)
            {
                ButtonsBuildings.Find(t => t.name == building.Name.ToString()).GetComponent<Button>().enabled = false;
            }
            else
            {
                if(!isBaseBuilding(building.Name))
                {
                    Debug.Log("Name : " + building.Name.ToString());
                    ButtonsBuildings.Find(t => t.name == building.Name.ToString()).GetComponent<Button>().enabled = true;
                    ButtonsBuildings.Find(t => t.name == building.Name.ToString()).GetComponent<Button>().image.sprite = Resources.Load<Sprite>("Sprites/Buildings/" + building.Name.ToString());
                }
                
            }
        }
    }

    private bool isBaseBuilding(BuildingNameEnum building)
    {
        if (building == BuildingNameEnum.Townhall || building == BuildingNameEnum.Caravan
            || building == BuildingNameEnum.Cemetery)
            return true;

        return false;
    }

    public static GameContext Gtx
    {
        get
        {
            return _gtx;
        }

        set
        {
            _gtx = value;
        }
    }
}
