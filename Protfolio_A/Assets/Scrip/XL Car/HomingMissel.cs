using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XL_Car;

namespace XL_Car
{

    public class HomingMissel : MonoBehaviour
    {
        public GameObject EffectExplosion;
        GameObject EnemyCube;
        public float force;
        public float rotationForce;
        Rigidbody rb;
        // Use this for initialization
        void Start()
        {
            EnemyCube = GameObject.FindGameObjectWithTag("EnemyCube");
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 direction = (Vector3)EnemyCube.transform.position - rb.position;
            direction.Normalize();
            Vector3 rotationAmount = Vector3.Cross(transform.forward, direction);
            rb.angularVelocity = rotationAmount * rotationForce;
            rb.velocity = transform.forward * force;
        }
        void OnTriggerEnter()
        {
            Instantiate(EffectExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

