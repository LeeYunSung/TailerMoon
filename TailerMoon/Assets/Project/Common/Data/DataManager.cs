using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Common.Data {

    public class UserInfo {
        public string ID { get; protected set; }
        public string Name { get; protected set; }

        public UserInfo(string userID, string userName){
            ID = userID;
        }

    }

    public class DataManager : MonoBehaviour {

        static DataManager instance;

        public static DataManager Instance {
            get {
                if (instance == null) instance = new DataManager();
                return instance;
            }
        }
    }
}