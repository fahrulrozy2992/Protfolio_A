using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XL_Car;

namespace XL_Car
{

    public class PlayerControl : MonoBehaviour
    {
        WeaponData weaponData;
        Weapon weaponj;

        public PlayerShooting playerShooting;
        int randomW;
        
        void WeaponRandom()
        {
            weaponData = new WeaponData();
            string json = Resources.Load<TextAsset>("Data").ToString();
            weaponData = JsonUtility.FromJson<WeaponData>(json);
            randomW = Random.Range(0, weaponData.ListWeaponData.Count);
            weaponj = weaponData.ListWeaponData[randomW];
            playerShooting.weaponJ = weaponj;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("TriggerCube"))
            {
                WeaponRandom();
            }
        }
    }
}
