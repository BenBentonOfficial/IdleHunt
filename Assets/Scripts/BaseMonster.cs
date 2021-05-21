using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(MasterButton))]
public class BaseMonster : MonoBehaviour {

    [SerializeField] protected string monsterName;

    [SerializeField] protected int hunterAmt = 0;
    [SerializeField] protected int worth = 1;
    [SerializeField] protected int worthMulti = 1;

    [SerializeField] protected float huntTime = 2;
    [SerializeField] protected float currentHuntTimeMax = 2;
    [SerializeField] protected float huntTimeMax = 2;

    protected ResourceTypeListSO monsterResourceList;

    private Slider progressSlider;
    private TextMeshProUGUI [] textList;
    private bool startHunt = false;

    private void Awake() {
        monsterResourceList = Resources.Load<ResourceTypeListSO>(monsterName + "PartList");
        textList = GetComponentsInChildren<TextMeshProUGUI>();
    }

    private void Start() {
        progressSlider = GetComponentInChildren<Slider>();
        Debug.Log("there are " + textList.Length + " components");

        UpdateText();

    }

    private void Update()
    {
        Hunt();
    }

    public string GetName() {
        return monsterName;
    }

    private void Hunt()
    {
        if (startHunt)
        {
            huntTime -= Time.deltaTime;

            progressSlider.value = huntTime / currentHuntTimeMax;

            if (huntTime < 0)
            {
                int prev = 0;
                int lootDrop = Random.Range(1, 101);
                foreach (ResourceTypeSO resourceType in monsterResourceList.list)
                {

                    //Debug.Log("Is " + lootDrop + " <= " + (prev + resourceType.dropChance));
                    if (lootDrop <= prev + resourceType.dropChance)
                    {
                        ResourceManager.Instance.AddResource(resourceType, worth * worthMulti);
                        break;
                    }
                    else
                    {
                        prev += resourceType.dropChance;
                    }
                }

                huntTime = currentHuntTimeMax;
                UpdateAmtText();
            }
        }
    }

    public void AddHunter() {
        hunterAmt ++;
        startHunt = true;
        currentHuntTimeMax = huntTimeMax / hunterAmt;
        huntTime = currentHuntTimeMax;

        UpdateHunterAmtText();
    }

    public void RemoveHunter() {
        //if there is a hunter to take away, do it.
        if(startHunt != false && hunterAmt > 0) {
            hunterAmt--;
            UpdateHunterAmtText();

            //can't be dividing by zero
            if(hunterAmt > 0) {
                currentHuntTimeMax = huntTimeMax / hunterAmt;
                huntTime = currentHuntTimeMax;
            } else {
                startHunt = false;
            }
        }
    }

    private void UpdateText() {
        textList[0].text = monsterName;
        textList[1].text = "+";
        textList[2].text = "-";
        textList[3].text = "Hunters:";
        UpdateAmtText();
        UpdateAmtText();
    }

    private void UpdateHunterAmtText() {
        textList[4].text = hunterAmt.ToString();
    }

    private void UpdateAmtText() {
        textList[5].text = monsterResourceList.list[0].monsterName + monsterResourceList.list[0].partName;
        textList[6].text = monsterResourceList.list[1].monsterName + monsterResourceList.list[1].partName;
        textList[7].text = monsterResourceList.list[2].monsterName + monsterResourceList.list[2].partName;
        textList[8].text = ResourceManager.Instance.GetResourceAmount(monsterResourceList.list[0]).ToString();
        textList[9].text = ResourceManager.Instance.GetResourceAmount(monsterResourceList.list[1]).ToString();
        textList[10].text = ResourceManager.Instance.GetResourceAmount(monsterResourceList.list[2]).ToString();
    }
}