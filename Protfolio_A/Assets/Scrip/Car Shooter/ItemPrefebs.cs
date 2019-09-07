using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Car_Shooter;

namespace Car_Shooter
{
    public class ItemPrefebs : MonoBehaviour
    {
        [SerializeField] Text file_name;
        public Weapon weaponData;

        public void SetData(string File_Name,Weapon data)
        {
            file_name.text = File_Name;
            weaponData = new Weapon();
            weaponData.amount = data.amount; ;
        }

        public void SetOnClick(PlayerController pc)
        {
            GetComponent<Button>().onClick.AddListener(delegate { pc.bulletSpoon.ChangeWeapon(weaponData); });
        }
        
    }
}
