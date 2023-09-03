using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Project.Common.System;
using Photon.Pun;
using Photon.Realtime;
using Project.Common.Data;

namespace Project.Room{

    public class RoomManager : MonoBehaviourPunCallbacks {

        [SerializeField] private TextMeshProUGUI roomNumberText;

        [SerializeField] private GameObject roomUserRoot;
        [SerializeField] private RoomUser roomUserObject;
        private List<GameObject> userList;

        [SerializeField] private GameObject chatRoot;
        [SerializeField] private Chatting chattingObject;

       [SerializeField] private PhotonView PV;

        private void Start() {
            roomNumberText.text = PhotonNetwork.CurrentRoom.Name;
            //PV.RPC("UserRPC", RpcTarget.All);
        }

        public void OnClickedChattingInputButton(){

        }

        public void OnClickedStartGameButton() {
            SceneManager.Instance.LoadScene(SceneType.GameScene);
        }

        public void OnClickedLeaveRoomButton() {
            PhotonNetwork.LeaveRoom();
            SceneManager.Instance.LoadScene(SceneType.LobbyScene);
        }

        [PunRPC]
        private void UserRPC() {
            userList.Clear();
            for (int i= 0; i< PhotonNetwork.CurrentRoom.PlayerCount; i++){
                GameObject gameObject = Instantiate(roomUserObject.gameObject, roomUserRoot.transform) as GameObject;
                gameObject.GetComponent<RoomUser>().characterType = CharacterType.Cat;
                gameObject.GetComponent<RoomUser>().userName = PhotonNetwork.PlayerList[i].NickName;
                gameObject.GetComponent<RoomUser>().isReady = false;
                userList.Add(gameObject);
            }
        }

        [PunRPC]
        private void ChatRPC() {

        }
    }

}