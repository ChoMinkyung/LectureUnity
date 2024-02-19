using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DragonFlight
{
    public class EnemyShot : MonoBehaviour
    {
        public GameObject Bomb;
        private float Rate = 1f;
        private bool hasWaited = false;

        // Start is called before the first frame update

        void Start()
        {
            StartCoroutine(ShootCoroutine());
        }
        IEnumerator ShootCoroutine()
        {
            while (true)
            {
                if (!hasWaited)
                {
                    yield return new WaitForSeconds(1.0f);
                    hasWaited = true;
                }
                else
                {
                    yield return new WaitForSeconds(Rate);

                    ShootProjectile();
                }
            }
        }

        // Update is called once per frame
        void ShootProjectile()
        {
            Instantiate(Bomb, this.transform.position, this.transform.rotation);
        }

    }
}