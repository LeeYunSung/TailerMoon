using Project.Common.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Intro {

    public class IntroScript : MonoBehaviour {
        
        private void Start()
        {
#if !UNITY_EDITOR && !UNITY_ANDROID && !UNITY_IOS
            Screen.SetResolution(960, 540, false);
#endif
            SceneManager.Instance.LoadScene(SceneType.LoginScene);
        }
    }
}