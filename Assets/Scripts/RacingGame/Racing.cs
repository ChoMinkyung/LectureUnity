using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Race
{

    public class Racing : MonoBehaviour
    {
        private int laps = -1;
        private bool tileCollision = false;

        public Text displayText; // UI Text�� ������ ����
        enum tire { FrontL = 1, FrontR, RearL, RearR }
        public float Speed = 6.0f;
        public float RotateSpeed = 100.0f;
        private Ray CarRay;
        private Ray[] TireRays = new Ray[2];

        private Ray rayRight = new Ray(); // ���� ����
        private Ray rayLeft = new Ray();
        float angle;

        private RaycastHit[] rayHits;
        private RaycastHit[] rayHitsLeft;
        private RaycastHit[] rayHitsRight;

        public int distance = 15;

        Rigidbody rigidbody;


        // Start is called before the first frame update
        void Start()
        {
            this.transform.Translate(new Vector3(0.0f, 0.0f, 0.0f)); // ���� ��ǥ ���� ( ���� ��ǥ + )
            CarRay = new Ray();
            CarRay.origin = this.transform.position;
            CarRay.direction = this.transform.forward;

            for (int i = 0; i < TireRays.Length; i++)
            {
                TireRays[i] = new Ray();

                TireRays[i].origin = this.transform.GetChild(i + 1).position;
                TireRays[i].direction = this.transform.GetChild(i + 1).forward;
            }

            rigidbody = this.gameObject.GetComponent<Rigidbody>();
            displayText = GetComponent<Text>();
            if (displayText == null)
            {
                Debug.LogError("Text ������Ʈ�� ã�� �� �����ϴ�.");
            }
            else
            {
                displayText.text = "";
                //displayText.enabled = false; // Text�� ��Ȱ��ȭ
            }

        }

        // Update is called once per frame
        void Update()
        {
            CarMoveControl();
            DirectionControl();
            Collision();
        }

        void CarMoveControl()
        {
            CarRay.origin = this.transform.position;
            CarRay.direction = this.transform.forward;

            for (int i = 0; i < TireRays.Length; i++)
            {
                TireRays[i].origin = this.transform.GetChild(i + 1).position;
                TireRays[i].direction = this.transform.GetChild(i + 1).forward;
            }


            float move = 1; //Input.GetAxis("Vertical"); // project setting -> Input Manager

            if (Vector3.Angle(CarRay.direction, TireRays[0].direction) != 0)
                transform.Rotate(move * angle / 2 * Time.deltaTime * Vector3.up);

            transform.Translate(move * Vector3.forward * Time.deltaTime * Speed); // move Ű�� �� ������ �� 0

            for (int i = 1; i < 3; i++)
            {
                transform.GetChild(i).Rotate(move * RotateSpeed * Time.deltaTime * Vector3.right);
            }

        }

        void DirectionControl()
        {
            for (int i = 0; i < TireRays.Length; i++)
            {
                TireRays[i].origin = this.transform.GetChild(i + 1).position;
                TireRays[i].direction = this.transform.GetChild(i + 1).forward;
            }

            //Input.GetKey
            float rotate = 0;// = Input.GetAxis("Horizontal"); // project setting -> Input Manager

            if (rayHitsLeft != null)
            {
                for (int index = 0; index < rayHitsLeft.Length; index++)
                {
                    if (rayHitsLeft[index].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
                    {
                        rotate = 1;
                        Debug.Log("���ʿ� �ε��� ����������");
                    }
                }
            }

            if (rayHitsRight != null)
            {
                for (int index = 0; index < rayHitsRight.Length; index++)
                {
                    if (rayHitsRight[index].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
                    {
                        if (rotate == 1) rotate = 0;
                        else rotate = -1;
                        Debug.Log("�����ʿ� �ε��� ��������");
                    }
                }
            }


            angle = Vector3.Angle(CarRay.direction, TireRays[0].direction) * rotate;


            if (Vector3.Angle(CarRay.direction, TireRays[0].direction) < 20)
            {
                for (int i = 1; i <= (int)tire.RearR; i++)
                {
                    transform.GetChild(i).Rotate(Speed * rotate * Time.deltaTime * Vector3.up);
                }
            }

        }

        void Collision()
        {
            rayHitsLeft = Physics.RaycastAll(rayLeft, distance);
            rayHitsRight = Physics.RaycastAll(rayRight, distance);

            rayHits = new RaycastHit[rayHitsLeft.Length + rayHitsRight.Length];
            rayHitsLeft.CopyTo(rayHits, 0);
            rayHitsRight.CopyTo(rayHits, rayHitsLeft.Length);

            //for (int index = 0; index < rayHitsRight.Length; index++)
            //{
            //    Debug.Log(rayHitsRight[index].collider.gameObject.name + " hit!!");
            //}


        }

        private void OnTriggerEnter(Collider other)
        {
            GameObject hitObject = other.gameObject;
            if (hitObject.layer == LayerMask.NameToLayer("RaceStart"))
            {
                tileCollision = true;
                StartCoroutine(ShowAndHideText());

            }
        }


        private void OnTriggerExit(Collider other)
        {
            if(tileCollision)
            {
                laps++;
                tileCollision = false;
                Debug.Log("�����? " + laps);
                displayText.text = laps.ToString() + " lap";

            }
        }

        private IEnumerator ShowAndHideText()
        {

            // displayText�� null���� Ȯ��
            if (displayText != null)
            {
                // 3�� ���� UI Text�� Ȱ��ȭ�Ͽ� ������
                displayText.enabled = true;

                // 3�� ���
                yield return new WaitForSeconds(3f);

                // 3�� �Ŀ� UI Text�� ��Ȱ��ȭ�Ͽ� ����
                displayText.enabled = false;
            }
            else
            {
                Debug.LogError("displayText�� null�Դϴ�.");
            }
        }

        public Vector3 GetCarPos()
        {
            //Debug.Log("�� ��ġ : " + this.transform.position);
            return this.transform.position - this.transform.forward * 10;
        }

        private void OnDrawGizmos()
        {

            rayLeft.origin = this.transform.GetChild((int)tire.FrontL).position;
            rayLeft.direction = Quaternion.Euler(0, -45, 0) * this.transform.forward;

            rayRight.origin = this.transform.GetChild((int)tire.FrontR).position;
            rayRight.direction = Quaternion.Euler(0, 45, 0) * this.transform.forward;

            Gizmos.color = Color.green;
            Gizmos.DrawLine(rayLeft.origin, rayLeft.direction * (distance) + rayLeft.origin);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(rayRight.origin, rayRight.direction * (distance) + rayRight.origin);

            if (this.rayHits != null)
            {
                for (int i = 0; i < this.rayHits.Length; i++)
                {
                    // : collision
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(this.rayHits[i].point, 0.1f);
                }
            }
        }
    }
}