using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CarMove : MonoBehaviour
{
    enum tire { FrontL = 1, FrontR, RearL, RearR }
    public float Speed = 6.0f;
    public float RotateSpeed = 100.0f;
    private Ray CarRay;
    private Ray TireRay;

    float angle;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.Translate(new Vector3(0.0f, 0.0f, 0.0f)); // ·ÎÄÃ ÁÂÇ¥ ±âÁØ ( ±âÁ¸ ÁÂÇ¥ + )
        CarRay = new Ray();
        CarRay.origin = this.transform.position;
        CarRay.direction = this.transform.forward;

        TireRay = new Ray();
        TireRay.origin = this.transform.GetChild((int)tire.FrontR).position;
        TireRay.direction = this.transform.GetChild((int)tire.FrontR).forward;

    }

    // Update is called once per frame
    void Update()
    {
        CarMoveControl();
        DirectionControl();
    }

    void CarMoveControl()
    {
        CarRay.origin = this.transform.position;
        CarRay.direction = this.transform.forward;

        TireRay.origin = this.transform.GetChild((int)tire.FrontR).position;
        TireRay.direction = this.transform.GetChild((int)tire.FrontR).forward;

        //Input.GetKey
        float move = Input.GetAxis("Vertical"); // project setting -> Input Manager

        if (move != 0)
            Debug.Log("angle : " + angle); // 90


        if (Vector3.Angle(CarRay.direction, TireRay.direction) != 0)
            transform.Rotate(angle * move * Time.deltaTime * Vector3.up);

        transform.Translate(Vector3.forward * Time.deltaTime * Speed * move); // move Å°°¡ ¾È ´­·ÈÀ» ¶© 0
        
        for (int i = 1; i <= (int)tire.RearR; i++)
        {
            transform.GetChild(i).Rotate(RotateSpeed * move * Time.deltaTime * Vector3.right);
        }

    }

    void DirectionControl()
    {
        TireRay.origin = this.transform.GetChild((int)tire.FrontR).position;
        TireRay.direction = this.transform.GetChild((int)tire.FrontR).forward;

        //Input.GetKey
        float rotate = Input.GetAxis("Horizontal"); // project setting -> Input Manager

        angle = Vector3.Angle(CarRay.direction, TireRay.direction) * rotate;


        if (rotate != 0)
        {
            Debug.Log("ÁÂ¿ìÈ¸Àü : " + angle); // 90

        }

        if (Vector3.Angle(CarRay.direction, TireRay.direction) < 20)
        {
            for (int i = 1; i <= (int)tire.RearR; i++)
            {
                transform.GetChild(i).Rotate(Speed * rotate * Time.deltaTime * Vector3.up);
            }
        }

    }
    private void OnDrawGizmos()
    {
        //Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(CarRay.origin, CarRay.direction * 5 + CarRay.origin);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(TireRay.origin, TireRay.direction * 5 + TireRay.origin);

    }

}
