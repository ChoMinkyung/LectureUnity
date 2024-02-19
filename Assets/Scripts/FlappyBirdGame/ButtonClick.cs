using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class ButtonClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            GameManager.Instance.ChangeScene("FlappyBirdPlay");
        }
    }
}
