using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ETC
{

    public class GameManager : MonoBehaviour
    {
        private static GameManager sInstance;

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

    public string nextSceneName;
    }

}

