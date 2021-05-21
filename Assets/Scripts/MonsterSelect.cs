using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterSelect : MonoBehaviour
{
    private MonsterListSO monsterNames;
    private BaseMonster monster;

    public TMP_Dropdown dropdown;
    private Text selectedMonster;

    public void Dropdown_IndexChanged(int index) {
        selectedMonster.text = monsterNames.list[index];
    }

    private void Start() {
        monsterNames = Resources.Load<MonsterListSO>("MonsterList");
        monster = GetComponentInParent<BaseMonster>();
        PopulateList();
    }

    void PopulateList() {
        dropdown.ClearOptions();

        dropdown.AddOptions(monsterNames.list);
        dropdown.RefreshShownValue();
    }

    public void ChangeMonster() {
        Debug.Log(monster.GetName());
        monster.ChangeMonster(dropdown.options[dropdown.value].text);
    }
}
