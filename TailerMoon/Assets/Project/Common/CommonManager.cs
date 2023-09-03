using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Common{

    public class CommonManager : MonoBehaviour{

        private static CommonManager instance;

        private void Awake(){
            if (instance == null){
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public static CommonManager Instance {
            get {
                if (instance == null)  {
                    return null;
                }
                return instance;
            }
        }

    }
}