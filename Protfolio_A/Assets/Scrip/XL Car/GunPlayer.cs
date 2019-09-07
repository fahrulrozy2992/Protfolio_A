using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XL_Car
{
    public class GunPlayer : MonoBehaviour
    {
        Camera mainCamera;

        // Use this for initialization
        void Start()
        {
            mainCamera = FindObjectOfType<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;
            if(groundPlane.Raycast(cameraRay,out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.green);
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));

            }
        }
    }
}
