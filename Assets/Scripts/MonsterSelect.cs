using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterSelect : MonoBehaviour
{
    private MonsterListSO monsterNames;

    public TMP_Dropdown dropdown;
    private Text selectedMonster;

    public void Dropdown_IndexChanged(int index) {
        selectedMonster.text = monsterNames.list[index];
    }

    private void Start() {
        monsterNames = Resources.Load<MonsterListSO>("MonsterList");
        PopulateList();
    }

    void PopulateList() {
        dropdown.ClearOptions();

        dropdown.AddOptions(monsterNames.list);
        dropdown.RefreshShownValue();
        dropdown.Show();
    }
}
