using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XL_Car;

namespace XL_Car
{

    public class PlayerShooting : MonoBehaviour
    {
        public int damagaePerShot;
        public float timeBetweenBullets = 0.15f;
        public float range = 100f;

        public GameObject Bullet;

        float timer;
        Ray shootRay;
        RaycastHit shootHit;
        int shootableMask;
        LineRenderer gunLine;
        float effectDisplayTime = 0.2f;
        EnemyH EH;
        public Weapon weaponJ;

        private void Awake()
        {
            gunLine = GetComponent<LineRenderer>();
            weaponJ.damage = damagaePerShot;
        }
        
        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if(Input.GetButtonDown("Fire1") & timer >= timeBetweenBullets)
            {
                switch (weaponJ.weapon)
                {
                    case WeaponList.Laser:
                        Shoot();
                        break;
                    case WeaponList.Homing:
                        ShootingRudal();
                        break;

                }
            }
            if(timer >= timeBetweenBullets * effectDisplayTime)
            {
                DisableEffects();
            }
        }
        
        void DisableEffects()
        {
            gunLine.enabled = false;
        }

        void Shoot()
        {
            if(weaponJ.amount <= 0)
            {
                return;
            }
            Debug.Log("shoot");
            timer = 0f;
            gunLine.enabled = true;
            gunLine.SetPosition(0, transform.position);

            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;

            if(Physics.Raycast(shootRay,out shootHit, range))
            {
                Debug.Log(shootHit.transform.name);
                gunLine.SetPosition(1, shootHit.point);
                if(shootHit.collider.tag == "EnemyCube")
                {
                    EH = shootHit.collider.GetComponent<EnemyH>();
                    EH.enemyHealt -= damagaePerShot;
                    EH.EnemyDead();
                }
            }
            else
            {
                Debug.Log("gunLine");
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
            weaponJ.amount--;
        }

        void ShootingRudal()
        {
            if(weaponJ.amount <= 0)
            {
                return;
            }
            Instantiate(Bullet, transform.position, transform.rotation);
            weaponJ.amount--;
        }
    }
}
