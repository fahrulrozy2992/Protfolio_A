using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car_Shooter
{
    public class Rotation_Gun : MonoBehaviour
    {
        public Transform Gun;
        float MinimumAngel = -45f;
        float MaximalAngel = 45f;
        float CurrentAngel = 0f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            RotateGun();
        }
        void RotateGun()
        {
            if (Input.GetKey(KeyCode.W))
            {
                CurrentAngel += 2;
                CurrentAngel = Mathf.Clamp(CurrentAngel, MinimumAngel, MaximalAngel);
                transform.rotation = Quaternion.Euler(0, 0, CurrentAngel);
            }
            if (Input.GetKey(KeyCode.S))
            {
                CurrentAngel -= 2;
                CurrentAngel = Mathf.Clamp(CurrentAngel, MinimumAngel, MaximalAngel);
                transform.rotation = Quaternion.Euler(0, 0, CurrentAngel);
            }
        }



    }
}
