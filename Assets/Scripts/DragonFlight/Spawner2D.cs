using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DragonFlight
{
    public class Spawner2D : MonoBehaviour
    {
        public GameObject cloudPrefab;
        private float cloudInterval = 3.0f;
        private Vector3 cloudPos;

        public GameObject enemyPrefab;
        private float enemyInterval = 3.0f;
        private Vector3 enemyPos;

        float xScreenHalfSize;
        float yScreenHalfSize;

        void Start()
        {
            yScreenHalfSize = Camera.main.orthographicSize;
            xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

            StartCoroutine(CloudCreate());
            StartCoroutine(EnemyCreate());
        }


        private IEnumerator CloudCreate()
        {
            while (true)
            {
                cloudPos = transform.position;

                int yPosRandom = Random.Range(0, (int)yScreenHalfSize);
                int intervalRandom = Random.Range(0, 5);

                cloudPos.y -= yPosRandom;

                Instantiate(cloudPrefab, cloudPos, transform.rotation);

                yield return new WaitForSeconds(cloudInterval);
            }
        }

        private IEnumerator EnemyCreate()
        {
            while (true)
            {
                enemyPos = transform.position;

                int yPosRandom = Random.Range(0, (int)yScreenHalfSize);
                int intervalRandom = Random.Range(0, 5);

                enemyPos.y -= yPosRandom;

                Instantiate(enemyPrefab, enemyPos, transform.rotation);

                yield return new WaitForSeconds(enemyInterval);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
