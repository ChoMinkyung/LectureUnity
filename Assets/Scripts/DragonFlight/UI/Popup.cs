using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DragonFlight
{
    public class Popup : MonoBehaviour
    {
        public Text titleText = null;
        public InputField inputText = null;
        public Toggle toggleBGM = null;
        public GameObject radioGroupObj = null;
        Toggle[] toggleRadio;

        public GameObject background1 = null;
        public GameObject background2 = null;

        // Start is called before the first frame update
        void Start()
        {
            titleText = GetComponentInChildren<Text>();
            //titleText.text= "뷁";

            toggleRadio = radioGroupObj.GetComponentsInChildren<Toggle>();

        }

        // Update is called once per frame
        void Update()
        {

        }

        void onClickOK()
        {
            Debug.Log("onClickOK()");
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }

        void onClickCancel()
        {
            Debug.Log("onClickCancel()");
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }

        void onTextChange()
        {
            Debug.Log("onTextChange()");
            titleText.text = inputText.text;
        }

        void onTextEndEdit()
        {
            Debug.Log("onTextEndEdit()");
            titleText.text = inputText.text;

        }

        public void onToggleBGM()
        {
            if (toggleBGM.isOn)
            {
                Debug.Log("BGM on!!");
            }
            else
            {
                Debug.Log("BGM off!!");

            }
        }

        public void onToggleRadio()
        {
            if (toggleRadio == null) return;
            else
            {
                if (toggleRadio[0].isOn)
                {
                    background1.SetActive(true);
                    background2.SetActive(false);
                    Debug.Log("1번 선택");
                }
                else if (toggleRadio[1].isOn)
                {
                    Debug.Log("2번 선택");
                    background1.SetActive(false);
                    background2.SetActive(true);
                }
            }

        }
    }
}
