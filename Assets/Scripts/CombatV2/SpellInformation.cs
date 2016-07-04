﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using S_M_D.Spell;
using S_M_D.Character;
using System.Collections.Generic;

public class SpellInformation : MonoBehaviour {

    public Spells spell;
    int position;
    bool[] cible;

    public static List<GameObject> arrows;

    public GameObject arrowPrefab;

	// Use this for initialization
	void Start () {
        arrows = new List<GameObject>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (Camera.main.GetComponent<CombatLogic>().monstersTurn)
        {
            Debug.Log("Can't target enemy during enemy's turn.");
            return;
        }
        // Deleting the previously instantiated arrows
        GameObject[] arrows;
        if (GameObject.Find("redarrow") != null)
        {
            arrows = GameObject.FindGameObjectsWithTag("redArrow");
            foreach (GameObject arrowObj in arrows)
            {
                Destroy(arrowObj.gameObject);
            }
        }
        
        // 

        position = 0;
        for (int idx = 0; idx < 4; idx++)
        {
            if (StartCombat.Combat.Heros[idx] == StartCombat.Combat.GetCharacterTurn())
                break;
            position++;
        }
        Debug.Log("Character turn = " + StartCombat.Combat.GetCharacterTurn().CharacterName);
        /*
        foreach(BaseHeros H in StartCombat.Combat.Heros)
        {
            if (H == StartCombat.Combat.GetCharacterTurn())
            {
                break;
            }
                position++;
        }
        */
        Debug.Log("Position = " + position);
        cible = StartCombat.Combat.SpellManager.WhoCanBeTargetable(spell, position);
        int id = 0;
        foreach(BaseMonster M in StartCombat.Combat.Monsters)
        {
            if (M.HP <= 0)
                cible[id] = false;
            id++;
        }
        int i = 0;
        foreach(bool b in cible)
        {
            GameObject canvas = GameObject.Find("SuperCanvas");
            if (b)
            {
               GameObject arrow =  Instantiate(arrowPrefab, new Vector3(StartCombat.monstersGO[i].transform.position.x * 40, StartCombat.monstersGO[i].transform.position.y + 60, 0), Quaternion.identity) as GameObject;
                arrow.tag = "redArrow";
                arrow.name = "redarrow";
                arrow.transform.localScale = new Vector3(6, 6, 1);
                arrow.transform.SetParent(canvas.transform, false);
                arrow.GetComponent<ArrowScript>().MonsterPosition = i;
                arrow.GetComponent<ArrowScript>().AssociatedSpell = spell;
            }
                i++;
        }
    }
}
