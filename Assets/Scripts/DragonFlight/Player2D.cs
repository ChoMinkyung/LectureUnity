using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DragonFlight
{
    public class Player2D : MonoBehaviour
    {

        // << UI:
        public Image imgHPBar = null;

        // >>
        private Rigidbody2D rigidBody;
        float maxSpeed = 2000f;
        int maxHP = 100;
        int curHP = 0;
        new SpriteRenderer renderer;

        enum State { Idle, Hurt, HurtING }

        State state = State.Idle;

        // Start is called before the first frame update
        void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            renderer = GetComponent<SpriteRenderer>();
            GameManager.Instance.SetState(false);
            curHP = maxHP;
            ShowHPBar(curHP);
        }

        void ShowHPBar(int hp)
        {
            imgHPBar.fillAmount = (float)hp / (float)100;
        }


        // Update is called once per frame
        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Move_2(x, y);

            if (state == State.Hurt)
            {
                state = State.HurtING;
                renderer.color = Color.red;
                StartCoroutine(ReturnToIdleStateAfterDelay(1f));
            }
        }

        IEnumerator ReturnToIdleStateAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            renderer.color = Color.white;
            state = State.Idle;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                Destroy(collision.gameObject, 0.5f);
            }
            else if (collision.tag == "EnemyBomb")
            {
                if (state == State.Idle)
                {
                    state = State.Hurt;
                    curHP -= 5;
                    ShowHPBar(curHP);

                    if(curHP <=0)
                    {
                        GameManager.Instance.SetState(true);
                    }
                }
            }
        }


        void Flip_2D(float x)
        {
            if (Mathf.Abs(x) > 0)
            {
                if (x >= 0) renderer.flipX = false;
                else renderer.flipX = true;
            }
        }

        void Move_1(float x, float y)
        {
            rigidBody.AddForce(new Vector2(x * maxSpeed * Time.deltaTime, y * maxSpeed * Time.deltaTime));

        }

        void Move_2(float x, float y)
        {
            Vector3 position = rigidBody.transform.position;
            position = new Vector3(position.x + (x * maxSpeed * Time.deltaTime), position.y + (y * maxSpeed * Time.deltaTime), position.z);

            rigidBody.MovePosition(position);
        }



    }
}