using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DragonFlight
{
    public class Gameover : MonoBehaviour
    {
        public Text textScore;
        public Text textBestScore;

        // Start is called before the first frame update
        void Start()
        {
            textScore.text = "SCORE : " + GameManager.Instance.Score.ToString();
            textBestScore.text = "BEST SCORE : " + GameManager.Instance.bestScore.ToString();

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void onClickRestart()
        {
            GameManager.Instance.ChangeScene("DragonFlight");

        }
    }


}
