using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DragonFlight
{
    public class DefaultUI : MonoBehaviour
    {
        public Text textScore;

        public GameObject popupObj = null;
        public GameObject gameOver = null;

        // Start is called before the first frame update
        void Start()
        {
            GameManager.Instance.SetScore(-GameManager.Instance.Score);
            Time.timeScale = 1f;
            popupObj.SetActive(false);
            gameOver.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            textScore.text = "SCORE : " + GameManager.Instance.Score.ToString();
            if (GameManager.Instance.die)
            {
                gameOver.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        void onPopup()
        {
            if (popupObj.activeSelf)
            {
                popupObj.SetActive(false);
            }
            else
            {
                popupObj.SetActive(true);
                Time.timeScale = 0f;
            }
        }

    }
}
