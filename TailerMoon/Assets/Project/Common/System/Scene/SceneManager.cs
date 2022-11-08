using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Common.System {

    public class SceneManager : MonoBehaviour {
        public enum SceneType {
            Intro,
            Login,
            Lobby,
            Game
        }

        public void LoadScene(SceneType sceneType) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneType.ToString());
        }

    }

}