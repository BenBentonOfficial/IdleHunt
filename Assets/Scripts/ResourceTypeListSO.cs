using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ResourceTypeListSO", menuName = "ScriptableObjects/ResourceTypeListSO", order = 1)]
public class ResourceTypeListSO : ScriptableObject {
    public List<ResourceTypeSO> list;
}