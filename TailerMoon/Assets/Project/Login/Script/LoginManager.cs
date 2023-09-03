using Photon.Pun;
using Project.Common.Data;
using Project.Common.System;
using TMPro;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Project.Login {

    public class LoginManager : MonoBehaviourPunCallbacks {
        [SerializeField] private TMP_InputField idInput;
        [SerializeField] private TMP_InputField nameInput;

        public void OnClickedGoogleLogin() {
            UserInfo userInfo = new UserInfo(idInput.text, nameInput.text);
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster(){
            PhotonNetwork.JoinLobby();
            PhotonNetwork.LocalPlayer.NickName = nameInput.text;
            SceneManager.Instance.LoadScene(SceneType.LobbyScene);
        }

        // public void OnClickedAppleLogin() {
        // }
        // public void OnClickedEmailLogin() {
        // }

    }
}