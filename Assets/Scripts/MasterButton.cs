using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterButton : MonoBehaviour
{
   private BaseMonster monster;

   private void Start() {
        monster = GetComponent<BaseMonster>();
   }

   public void AddHunter() {
       monster.AddHunter();
   }

   public void RemoveHunter() {
       monster.RemoveHunter();
   }


}
