using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DragonFlight
{
    public class CloudMove : MonoBehaviour
    {

        private float moveSpeed = 100.0f;
        float xScreenHalfSize;
        float yScreenHalfSize;
        new SpriteRenderer cloundSprite;

        // Start is called before the first frame update
        void Start()
        {
            yScreenHalfSize = Camera.main.orthographicSize;
            xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;
            cloundSprite = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);

            if (transform.position.x + cloundSprite.bounds.size.x / 2 < -1 * xScreenHalfSize) Death();
        }

        void Death()
        {
            DestroyImmediate(this.gameObject);
        }
    }
}