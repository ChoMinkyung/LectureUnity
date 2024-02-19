using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race
{
    public class RaceCamera : MonoBehaviour
    {
        Camera CarCamera;
        Racing racing;
        Vector3 carPos;
        // Start is called before the first frame update
        void Start()
        {
            CarCamera = GetComponent<Camera>();
            racing = FindObjectOfType<Racing>();
           
            if (racing == null)
            {
                Debug.LogWarning("Racing script not found.");
            }
        }

        // Update is called once per frame
        void Update()
        {
            MoveCamera();
        }

        void MoveCamera()
        {
            carPos = racing.GetCarPos();
            transform.position = new Vector3(carPos.x, transform.position.y, carPos.z);

        }
    }
}
