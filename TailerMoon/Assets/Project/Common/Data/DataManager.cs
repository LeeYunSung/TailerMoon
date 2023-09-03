using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Common.Data {

    public enum CharacterType{
        Dog,
        Pig,
        Rabbit,
        Mouse,
        Cat,
        Monkey,
    }

    public class UserInfo {
        public string ID { get; protected set; }
        public string Name { get; protected set; }
        public CharacterType characterType { get; protected set; }

        public UserInfo(string userID, string userName, CharacterType type = CharacterType.Cat){
            ID = userID;
            Name = userName;
            characterType = type;
        }
    }

    public class DataManager : MonoBehaviour {

        private static DataManager instance;

        public static DataManager Instance {
            get {
                if (instance == null) instance = new DataManager();
                return instance;
            }
        }
    }
}