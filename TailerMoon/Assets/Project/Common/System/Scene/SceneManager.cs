using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Common.System {

    public enum SceneType {
        Intro,
        Login,
        Lobby,
        Room,
        Game
    }

    public class SceneManager : MonoBehaviour {
        static SceneManager instance;
        public static SceneManager Instance{
            get{
                if (instance == null) instance = new SceneManager();
                return instance;
            }
        }

        public void LoadScene(SceneType sceneType) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneType.ToString());
        }

    }

}