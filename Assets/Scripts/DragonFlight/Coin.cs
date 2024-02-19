using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DragonFlight
{
    public class Coin : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject hitObject = collision.gameObject;

            if (hitObject.tag == "Player")
            {
                Debug.Log("충돌 점수 상승");

                GameManager.Instance.SetScore(20);
                Destroy(this.gameObject);
            }

        }
    }
}
