using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Common.System {

    public enum SceneType {
        IntroScene,
        LoginScene,
        LobbyScene,
        RoomScene,
        GameScene
    }

    public class SceneManager : MonoBehaviour {
        private static SceneManager instance;

        private void Awake(){
            if (instance == null){
                instance = this;
            }
        }

        public static SceneManager Instance {
            get {
                if (instance == null) {
                    return null;
                }
                return instance;
            }
        }

        public void LoadScene(SceneType sceneType) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneType.ToString());
        }

    }

}