using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace defence
{
    public class Player : MonoBehaviour
    {
        Animation spartanKing;

        public AnimationClip IDLE;
        public AnimationClip RUN;
        public AnimationClip ATTACK;

        CharacterController pcControl;
        public float runSpeed = 10.0f;
        public float rotationSpeed = 720.0f;

        public GameObject objSword = null;

        Vector3 velocity;

        // Start is called before the first frame update
        void Start()
        {
            spartanKing = gameObject.GetComponentInChildren<Animation>();
            pcControl = gameObject.GetComponent<CharacterController>();
            objSword.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            //AnimationPlay_4();
            CharacterControl_Slerp();
        }

        private void CharacterControl_Slerp()
        {
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if(Input.GetKeyDown(KeyCode.F))
            {
                spartanKing.wrapMode = WrapMode.Loop;
                spartanKing.CrossFade(RUN.name, 0.6f);
            }

            if (direction.sqrMagnitude > 0.01f)
            {
                spartanKing.wrapMode = WrapMode.Loop;
                spartanKing.CrossFade(RUN.name, 0.3f);

                Vector3 forward = Vector3.Slerp(transform.forward, direction,
                    rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));

                transform.LookAt(transform.position + forward);
            }
            else
            {
                spartanKing.wrapMode = WrapMode.Loop;
                spartanKing.CrossFade(IDLE.name, 0.3f);
            }

            pcControl.Move(runSpeed * direction * Time.deltaTime + Physics.gravity);
            //pcControl.SimpleMove(velocity);
        }

        private void AnimationPlay_4()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine("AttackToIdle2");
            }
        }

            IEnumerator AttackToIdle2()
        {
            if (spartanKing[ATTACK.name].enabled == true) yield break;

            objSword.SetActive(true);
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.CrossFade(ATTACK.name, 0.3f);

            float delayTime = spartanKing.GetClip(ATTACK.name).length - 0.3f;

            yield return new WaitForSeconds(delayTime);

            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade(IDLE.name, 0.3f);
            objSword.SetActive(false);

        }
    }
}