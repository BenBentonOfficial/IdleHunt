using UnityEngine;

[CreateAssetMenu(fileName = "ResourceTypeSO", menuName = "ScriptableObjects/ResourceTypeSO", order = 0)]
public class ResourceTypeSO : ScriptableObject {

    public string monsterName = "Default";
    public string partName = "Default";

    [Range(1,100)] 
    public int dropChance;
}