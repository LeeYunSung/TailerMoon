using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;


namespace Project.System.Network {

    public class NetworkManager : MonoBehaviour {
        static NetworkManager instance;
        public string serverStatus;

        public static NetworkManager Instance {
            get {
                if (instance == null) instance = new NetworkManager();
                return instance;
            }
        }

    }

}