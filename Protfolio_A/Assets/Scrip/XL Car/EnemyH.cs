using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XL_Car;

namespace XL_Car
{
    public class EnemyH : MonoBehaviour
    {
        public int enemyHealt = 100;
        public GameObject effeckExp;

        public void EnemyDead()
        {
            if (enemyHealt <= 0)
            {
                Instantiate(effeckExp, transform.position, transform.rotation);
            }
        }

    }
}
