using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSelect : MonoBehaviour
{
    public List<string> monsterNames;

    public Dropdown dropdown;
    public Text selectedMonster;
    public void Dropdown_IndexChanged(int index) {
        selectedMonster.text = monsterNames[index];
    }

    private void Start() {
        PopulateList();
    }

    void PopulateList() {
        dropdown.AddOptions(monsterNames);
    }
}
