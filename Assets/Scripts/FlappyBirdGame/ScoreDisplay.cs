using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textBestScore;

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
}
