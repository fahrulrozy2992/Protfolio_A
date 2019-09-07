using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car_Shooter
{
    public class BulletSpeed : MonoBehaviour
    {
        float Speed = 40f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            Destroy(gameObject, 13f);
        }
    }
}
