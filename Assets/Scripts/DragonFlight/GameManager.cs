using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DragonFlight
{

    public class GameManager : MonoBehaviour
    {
        private static GameManager sInstance;

        
        public int bestScore { get; private set; }
        public int Score { get; private set; }
        public bool die { get; private set; }

        public static GameManager Instance
        {
            get
            {
                if (sInstance == null)
                {

                    GameObject newGameObject = new GameObject("_GameManager");
                    sInstance = newGameObject.AddComponent<GameManager>();
                }

                return sInstance;
            }
        }

        public int changeScene = 0;

        private void Awake()
        {
            if (sInstance != null && sInstance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            sInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        public void ChangeScene()
        {
            int sceneIndex = changeScene++ % 2;
            //string sceneName = string.Format("Scene_{0:2d}", scene);
            SceneManager.LoadScene(sceneIndex);
        }

        public void ChangeScene(string sceneName)
        {

            SceneManager.LoadScene(sceneName);
        }

        public void SetScore(int score)
        {
            Score += score;
            if (bestScore < Score) bestScore = Score;
        }

        public void SetState(bool state)
        {
            die = state;
        }

    }

}
