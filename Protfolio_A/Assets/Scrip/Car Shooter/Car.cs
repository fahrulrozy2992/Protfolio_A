using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car_Shooter
{
    public class Car : MonoBehaviour
    {
        public WheelJoint2D bandepan;
        public WheelJoint2D banbelakang;
        public JointMotor2D motor;
        float maju = 600f;
        float rem = 300f;
        float mundur = 100f;
        // Use this for initialization
        void Start()
        {
            motor.maxMotorTorque = 1000f;
        }

        // Update is called once per frame
        void Update()
        {
            move();
        }
        void move()
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (motor.motorSpeed > 0)
                    motor.motorSpeed = 0;

                motor.motorSpeed -= maju * Time.deltaTime;
                bandepan.motor = motor;
                banbelakang.motor = motor;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (motor.motorSpeed < 0)
                    motor.motorSpeed = 0;
                motor.motorSpeed += mundur * Time.deltaTime;
                bandepan.motor = motor;
                banbelakang.motor = motor;
            }
            else
            {
                motor.motorSpeed += rem * Time.deltaTime;
                motor.motorSpeed = Mathf.Clamp(motor.motorSpeed, -10000f, 0);
                bandepan.motor = motor;
                banbelakang.motor = motor;
            }

        }
    }
}
