using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = new Vector3(0.0f, 5.0f, 0.0f); // 월드 좌표 기준 ( 원점 기준 ), 맵 배치 시킬 때 사용
        this.transform.Translate(new Vector3(0.0f, 0.0f, 0.0f)); // 로컬 좌표 기준 ( 기존 좌표 + )
    }

    // Update is called once per frame
    void Update()
    {
        //Move_1();
        //Move_2();
        Move_Control();
    }

    void Move_Control()
    {
        //Input.GetKey
        float move = Input.GetAxis("Vertical"); // project setting -> Input Manager
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * move); // move 키가 안 눌렸을 땐 0
    }
    void Move_1()
    {
        // delat time : 다음 업데이트까지 걸리는 시간, 움직임 고정하기 위해서
        // 움직임 고정 안 하면 컴퓨터마다 움직임 속도가 달라짐
        float moveDelta = this.moveSpeed * Time.deltaTime; 
        Vector3 pos = this.transform.position;
        pos.z += moveDelta;
        this.transform.position = pos;
    }

    void Move_2()
    {
        float moveDelta = this.moveSpeed * Time.deltaTime; 
        this.transform.Translate(Vector3.forward * moveDelta);
    }
}
