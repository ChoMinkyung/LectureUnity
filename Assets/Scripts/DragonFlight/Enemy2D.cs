using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DragonFlight
{
    public class Enemy2D : MonoBehaviour
    {
        private Rigidbody2D rigidBody;
        private CircleCollider2D circleCollider;

        float maxSpeed = 500f;

        public GameObject deathEffect;
        private SpriteRenderer enemyRenderer; // ���� ���� Renderer ������Ʈ
        private bool die = false;
        float xScreenHalfSize;

        // Start is called before the first frame update
        void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            circleCollider = GetComponent<CircleCollider2D>();
            enemyRenderer = GetComponent<SpriteRenderer>();
            xScreenHalfSize = Camera.main.orthographicSize * Camera.main.aspect;
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector3 position = rigidBody.transform.position;
            position = new Vector3(position.x + (-1 * maxSpeed * Time.deltaTime), position.y, position.z);

            rigidBody.MovePosition(position);

            if (transform.position.x + enemyRenderer.bounds.size.x < -1 * xScreenHalfSize)
                DestroyImmediate(this.gameObject);

        }

        public Vector3 GetEnemyPos()
        {
            return rigidBody.transform.position;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject hitObject = collision.gameObject;

            if (!die && hitObject.tag == "PlayerBomb")
            {
                die = true;
                // �浹 ó�� ����
                circleCollider.enabled = false;
                StartCoroutine(DieWithEffect());
            }
        }

        IEnumerator DieWithEffect()
        {
            GameManager.Instance.SetScore(100);
            // �����
            enemyRenderer.enabled = false;

            // �״� ����Ʈ ���
            if (deathEffect != null)
            {
                GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);

                // ����Ʈ ����� ���� ������ ���

                ParticleSystem particleSystem = effect.GetComponent<ParticleSystem>();

                if (particleSystem != null)
                {
                    yield return new WaitForSeconds(particleSystem.main.duration);
                }
                else
                {
                    yield return new WaitForSeconds(2.0f); // ����Ʈ�� ���� �ð��� �� ��� ���
                }

                // ���� �ı�
                Destroy(effect);
                Destroy(gameObject);
            }
        }

    }
}