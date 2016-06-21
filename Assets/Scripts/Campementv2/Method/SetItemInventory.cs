﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using S_M_D.Character;

public class SetItemInventory : MonoBehaviour {

	public void OnClickHeroItem()
    {
        if (Start.MenuProfilPlayer.activeInHierarchy)
        {
            int count = Start.Gtx.PlayerInfo.MyItems.Count+1;
            if (gameObject.name == "ArmorProfil" && count<5)
            {
                Start.Gtx.PlayerInfo.MyItems.Add(SetProfil.HeroOpen.Equipement[0]);
                GameObject.Find("ArmorProfilText").GetComponent<Text>().text = "";
                GameObject.Find("Item"+count+"T").GetComponent<Text>().text = SetProfil.HeroOpen.Equipement[0].ItemName;
                GameObject.Find("ArmorProfil").GetComponent<Image>().sprite = null;
                if (SetProfil.HeroOpen.Equipement[0].Itemtype == BaseItem.ItemTypes.Armor) GameObject.Find("Item" + count).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/A_Armor04");
                if (SetProfil.HeroOpen.Equipement[0].Itemtype == BaseItem.ItemTypes.Weapon) GameObject.Find("Item" + count).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/S_Sword10");
                if (SetProfil.HeroOpen.Equipement[0].Itemtype == BaseItem.ItemTypes.Trinket) GameObject.Find("Item" + count).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/S_Light01");
                SetProfil.HeroOpen.Equipement[0] = null;
            }
            else if (gameObject.name == "WeaponProfil" && count< 5)
            {
                Start.Gtx.PlayerInfo.MyItems.Add(SetProfil.HeroOpen.Equipement[1]);
                GameObject.Find("WeaponProfilText").GetComponent<Text>().text = "";
                GameObject.Find("Item" + count + "T").GetComponent<Text>().text = SetProfil.HeroOpen.Equipement[1].ItemName;
                GameObject.Find("WeaponProfil").GetComponent<Image>().sprite = null;
                if (SetProfil.HeroOpen.Equipement[1].Itemtype == BaseItem.ItemTypes.Armor) GameObject.Find("Item" + count).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/A_Armor04");
                if (SetProfil.HeroOpen.Equipement[1].Itemtype == BaseItem.ItemTypes.Weapon) GameObject.Find("Item" + count).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/S_Sword10");
                if (SetProfil.HeroOpen.Equipement[1].Itemtype == BaseItem.ItemTypes.Trinket) GameObject.Find("Item" + count).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/S_Light01");

                SetProfil.HeroOpen.Equipement[1] = null;
            }
            else if (gameObject.name == "Trinket1Profil" && count < 5)
            {
                Start.Gtx.PlayerInfo.MyItems.Add(SetProfil.HeroOpen.Equipement[2]);
                GameObject.Find("Trinket1ProfilText").GetComponent<Text>().text = "";
                GameObject.Find("Item" + count + "T").GetComponent<Text>().text = SetProfil.HeroOpen.Equipement[2].ItemName;
                GameObject.Find("Trinket1Profil").GetComponent<Image>().sprite = null;
                if (SetProfil.HeroOpen.Equipement[2].Itemtype == BaseItem.ItemTypes.Armor) GameObject.Find("Item" + count).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/A_Armor04");
                if (SetProfil.HeroOpen.Equipement[2].Itemtype == BaseItem.ItemTypes.Weapon) GameObject.Find("Item" + count).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/S_Sword10");
                if (SetProfil.HeroOpen.Equipement[2].Itemtype == BaseItem.ItemTypes.Trinket) GameObject.Find("Item" + count).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/S_Light01");

                SetProfil.HeroOpen.Equipement[2] = null;
            }
            else if (gameObject.name == "Trinket2Profil" && count < 5)
            {
                Start.Gtx.PlayerInfo.MyItems.Add(SetProfil.HeroOpen.Equipement[3]);
                GameObject.Find("Trinket2ProfilText").GetComponent<Text>().text = "";
                GameObject.Find("Item" + count + "T").GetComponent<Text>().text = SetProfil.HeroOpen.Equipement[3].ItemName;
                GameObject.Find("Trinket2Profil").GetComponent<Image>().sprite = null;
                if (SetProfil.HeroOpen.Equipement[3].Itemtype == BaseItem.ItemTypes.Armor) GameObject.Find("Item" + count).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/A_Armor04");
                if (SetProfil.HeroOpen.Equipement[3].Itemtype == BaseItem.ItemTypes.Weapon) GameObject.Find("Item" + count).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/S_Sword10");
                if (SetProfil.HeroOpen.Equipement[3].Itemtype == BaseItem.ItemTypes.Trinket) GameObject.Find("Item" + count).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/S_Light01");

                SetProfil.HeroOpen.Equipement[3] = null;
            }
        }
    }
    public void OnClickPlayerItem()
    {
        if (Start.MenuProfil.activeInHierarchy)
        {
            if (gameObject.name == "Item1")
            {
                SwitchItem(Start.Gtx.PlayerInfo.MyItems[0],1);
            }
            else if (gameObject.name == "Item2")
            {
                SwitchItem(Start.Gtx.PlayerInfo.MyItems[1],2);
            }
            else if (gameObject.name == "Item3")
            {
                SwitchItem(Start.Gtx.PlayerInfo.MyItems[2],3);
            }
            else if (gameObject.name == "Item4")
            {
                SwitchItem(Start.Gtx.PlayerInfo.MyItems[3],4);
            }

        }
    }
    private void SwitchItem(BaseItem item,int numItem)
    {
        if (item.Itemtype == BaseItem.ItemTypes.Armor)
        {
            if (SetProfil.HeroOpen.Equipement[0] == null)
            {
                SetProfil.HeroOpen.Equipement[0] = item;
                Start.Gtx.PlayerInfo.MyItems.Remove(item);
                GameObject.Find("Item"+numItem+"T").GetComponent<Text>().text = "";
                GameObject.Find("ArmorProfilText").GetComponent<Text>().text = SetProfil.HeroOpen.Equipement[0].ItemName;
                GameObject.Find("Item"+numItem).GetComponent<Image>().sprite = null;
                GameObject.Find("ArmorProfil").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/A_Armor04");
            }
            else
            {
                BaseItem temp = SetProfil.HeroOpen.Equipement[0];
                SetProfil.HeroOpen.Equipement[0] = item;
                item = temp;
                GameObject.Find("Item" + numItem + "T").GetComponent<Text>().text = item.ItemName;
                GameObject.Find("ArmorProfilText").GetComponent<Text>().text = SetProfil.HeroOpen.Equipement[0].ItemName;
                GameObject.Find("ArmorProfil").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/A_Armor04");
            }
        }
        else if (item.Itemtype == BaseItem.ItemTypes.Weapon)
        {
            if (SetProfil.HeroOpen.Equipement[1] == null)
            {
                SetProfil.HeroOpen.Equipement[1] = item;
                Start.Gtx.PlayerInfo.MyItems.Remove(item);
                GameObject.Find("Item" + numItem + "T").GetComponent<Text>().text = "";
                GameObject.Find("WeaponProfilText").GetComponent<Text>().text = SetProfil.HeroOpen.Equipement[1].ItemName;
                GameObject.Find("Item" + numItem).GetComponent<Image>().sprite = null;
                GameObject.Find("WeaponProfil").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/S_Sword10");
            }
            else
            {
                BaseItem temp = SetProfil.HeroOpen.Equipement[1];
                SetProfil.HeroOpen.Equipement[1] = item;
                item = temp;
                GameObject.Find("Item" + numItem + "T").GetComponent<Text>().text = item.ItemName;
                GameObject.Find("WeaponProfilText").GetComponent<Text>().text = SetProfil.HeroOpen.Equipement[1].ItemName;
                GameObject.Find("WeaponProfil").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/S_Sword10");
            }
        }
        else if (item.Itemtype == BaseItem.ItemTypes.Trinket)
        {
            if (SetProfil.HeroOpen.Equipement[2] == null)
            {
                SetProfil.HeroOpen.Equipement[2] = item;
                Start.Gtx.PlayerInfo.MyItems.Remove(item);
                GameObject.Find("Item" + numItem + "T").GetComponent<Text>().text = "";
                GameObject.Find("Trinket1ProfilText").GetComponent<Text>().text = SetProfil.HeroOpen.Equipement[2].ItemName;
                GameObject.Find("Item" + numItem).GetComponent<Image>().sprite = null;
                GameObject.Find("Trinket1Profil").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/S_Light01");
            }
            else
            {
                BaseItem temp = SetProfil.HeroOpen.Equipement[2];
                SetProfil.HeroOpen.Equipement[2] = item;
                item = temp;
                GameObject.Find("Item" + numItem + "T").GetComponent<Text>().text = item.ItemName;
                GameObject.Find("Trinket1ProfilText").GetComponent<Text>().text = SetProfil.HeroOpen.Equipement[2].ItemName;
                GameObject.Find("Trinket1Profil").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stats/S_Light01");
            }
        }
    }
}
