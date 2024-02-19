using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DragonFlight
{
    public class PlayerShot : MonoBehaviour
    {
        public GameObject Bomb;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(Bomb, this.transform.position, this.transform.rotation);
            }
        }

    }
}