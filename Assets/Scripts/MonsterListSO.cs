using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterListSO", menuName = "ScriptableObjects/MonsterListSO", order = 0)]
public class MonsterListSO : ScriptableObject {
    public List<string> list;
}