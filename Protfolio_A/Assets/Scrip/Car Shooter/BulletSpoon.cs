using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Car_Shooter;

namespace Car_Shooter
{
    public class BulletSpoon : MonoBehaviour
    {
        public GameObject Bullet;
        float timer = 0;
        float fireRate = 0.9f;
        public Weapon currentWeapon;
       
        void Update()
        {
            timer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && timer >= fireRate)
            {
                Shooting();
            }
        }

        void Shooting()
        {
            if(currentWeapon.amount <= 0)
            {
                return;
            }
            Instantiate(Bullet, transform.position, transform.rotation);
            currentWeapon.amount--;
            Debug.Log(string.Format("current amount: {0}", currentWeapon.amount));
           
        }
        public void ChangeWeapon(Weapon data)
        {
            currentWeapon = new Weapon();
            currentWeapon.amount = data.amount;
        }
    }
}
