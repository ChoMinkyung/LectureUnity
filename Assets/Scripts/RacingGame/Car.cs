using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotSpeed = 50.0f;
    public float wheelSpeed = 100.0f;

    /*public float maxRotAngle = 45.0f;
    public float minRotAngle = -45.0f;*/
    
    public GameObject target = null;

    public GameObject[] wheels = new GameObject[4];
    public GameObject[] wheelcenters = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move_Control();
        WheelMove();
        WheelRotate();
    }

    void Move_Control() // 차 이동
    {
        //Input.GetKey
        float move = Input.GetAxis("Vertical"); // project setting -> Input Manager
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * move); // move 키가 안 눌렸을 땐 0

        float rotate = Input.GetAxis("Horizontal");
        float rot = rotSpeed * rotate * Time.deltaTime * move;
        transform.RotateAround(target.transform.position, Vector3.up, rot);
    }

    void WheelMove() // 바퀴 돌아
    {
        float move = Input.GetAxis("Vertical");
        float rot = wheelSpeed * Time.deltaTime;

        for (int i = 0; i < 4; i++)
        {
            wheels[i].transform.rotation *= Quaternion.AngleAxis(rot, Vector3.up * move);
        }
    }

    void WheelRotate() // 앞바퀴 두 개만 회전
    {
        float move = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");
        float rot = rotSpeed * Time.deltaTime;

        for (int i = 0; i < 2; i++)
        {
            if(wheels[i].transform.eulerAngles.y <= 45.0f || wheels[i].transform.eulerAngles.y >= 315.0f)
                wheels[i].transform.RotateAround(wheelcenters[i].transform.position, Vector3.up * rotate, rot);
                //transform.Rotate(Vector3.right * rot * move);
            else if(wheels[i].transform.eulerAngles.y > 45.0f && wheels[i].transform.eulerAngles.y <= 180.0f)
                wheels[i].transform.rotation = Quaternion.Euler(0.0f, 45.0f, 90.0f);
            else if(wheels[i].transform.eulerAngles.y < 315.0f)
               wheels[i].transform.rotation = Quaternion.Euler(0.0f, 315.0f, 90.0f);
        }
    }
}
