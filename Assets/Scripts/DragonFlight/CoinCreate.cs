using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DragonFlight
{
    public class CoinCreate : MonoBehaviour
    {
        public GameObject coinPrefab;
        private float coinInterval = 5.0f;
        private Vector3 coinPos;

        float xScreenHalfSize;
        float yScreenHalfSize;

        // Start is called before the first frame update
        void Start()
        {
            yScreenHalfSize = Camera.main.orthographicSize;
            xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

            StartCoroutine(Coin());
        }

        private IEnumerator Coin()
        {
            while (true)
            {

                int xPosRandom = Random.Range(-(int)xScreenHalfSize + 15, (int)xScreenHalfSize - 15);
                int yPosRandom = Random.Range(- (int)yScreenHalfSize + 15, (int)yScreenHalfSize - 15);

                coinPos = new Vector3(xPosRandom, yPosRandom, 0);
                Instantiate(coinPrefab, coinPos, transform.rotation);

                yield return new WaitForSeconds(coinInterval);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
