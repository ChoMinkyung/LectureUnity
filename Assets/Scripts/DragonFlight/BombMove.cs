using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DragonFlight
{
    public class BombMove : MonoBehaviour
    {
        private float moveSpeed = 200.0f;
        private float rotateSpeed = 100f;

        public int charactor; // 1 : enemy, -1, player

        float xScreenHalfSize;
        float yScreenHalfSize;

        // Start is called before the first frame update
        void Start()
        {
            yScreenHalfSize = Camera.main.orthographicSize;
            xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;
        }

        // Update is called once per frame
        void Update()
        {
            float rot = rotateSpeed * Time.deltaTime;
            //transform.Rotate(rot * Vector3.up);

            if (charactor < 0)
            {
                transform.Translate(charactor * Vector3.left * Time.deltaTime * moveSpeed);
                if (transform.position.x > xScreenHalfSize) DestroyImmediate(this.gameObject);
            }
            else
            {
                transform.Translate(charactor * Vector3.left * Time.deltaTime * moveSpeed);
                if (transform.position.x < -1 * xScreenHalfSize) DestroyImmediate(this.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject hitObject = collision.gameObject;

            if (charactor == 1 && hitObject.tag == "Player")
            {
                Destroy(this.gameObject);
            }

            if (charactor == -1 && hitObject.tag == "Enemy")
            {
                Destroy(this.gameObject);

            }

        }

    }
}