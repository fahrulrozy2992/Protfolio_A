using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XL_Car
{
    public class MovmentPlayer : MonoBehaviour
    {
        float Speed = 12f;
        float TrunSpeed = 90f;
        Rigidbody RigidbodyPLY;
        float MovmentForward;
        float MovmentTurn;

        private void Awake()
        {
            RigidbodyPLY = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            RigidbodyPLY.isKinematic = false;
            MovmentForward = 0f;
            MovmentTurn = 0f;
        }

        private void OnDisable()
        {
            RigidbodyPLY.isKinematic = true;
        }

        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            MovmentForward = Input.GetAxis("Vertical");
            MovmentTurn = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            Move();
            Trun();
        }

        void Move()
        {
            Vector3 movment = transform.forward * MovmentForward * Speed * Time.deltaTime;
            RigidbodyPLY.MovePosition(RigidbodyPLY.position + movment);
        }

        void Trun()
        {
            float trun = MovmentTurn * TrunSpeed * Time.deltaTime;
            Quaternion trunRotation = Quaternion.Euler(0f, trun , 0f);
            RigidbodyPLY.MoveRotation(RigidbodyPLY.rotation * trunRotation);
        }
    }
}
