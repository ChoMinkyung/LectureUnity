using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ETC
{
    public class GameTitle : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void GoNextScene()
        {
            Debug.Log("���� ��ư Ŭ��");
            GameManager.Instance.nextSceneName = "08_Mecanim";
            SceneManager.LoadScene("14_Loading");
        }
    }
}
