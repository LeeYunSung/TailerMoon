using Photon.Pun;
using Photon.Realtime;
using Project.Common.System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Project.Lobby {

    public class LobbyManager : MonoBehaviourPunCallbacks {

        [SerializeField] private TextMeshProUGUI networkStatusText;
        [SerializeField] private TextMeshProUGUI userNameText;
        [SerializeField] private GameObject menuPopup;
        [SerializeField] private TMP_InputField roomNumberInput;
        [SerializeField] private PhotonView PV;

        [SerializeField] private Room roomObject;
        [SerializeField] private GameObject roomObjectRoot;
        private List<GameObject> roomObjectList = new List<GameObject>();

        private bool isMenuActive = false;


        private void Start() { userNameText.text = PhotonNetwork.LocalPlayer.NickName; }
        private void Update() { networkStatusText.text = PhotonNetwork.NetworkClientState.ToString(); }

        public void OnClickedMakeRoomButton(){
            PhotonNetwork.JoinOrCreateRoom(Random.Range(1, PhotonNetwork.CountOfRooms + 2).ToString(), new RoomOptions { MaxPlayers = 8 }, null);
        }
        public void OnClickedSpeedJoinButton(){ PhotonNetwork.JoinRandomRoom(); }
        public void OnClickedRoomSearchButton(){ PhotonNetwork.JoinRoom(roomNumberInput.text); }

        public override void OnCreatedRoom(){
            //PV.RPC("RoomListRPC", RpcTarget.All);
            SceneManager.Instance.LoadScene(SceneType.RoomScene);
        }

        public override void OnCreateRoomFailed(short returnCode, string message){ OnClickedMakeRoomButton(); }

        [PunRPC]
        private void RoomListRPC() {
            /*
            GameObject gameObject = Instantiate(roomObject.gameObject, roomObjectRoot.transform) as GameObject;
            gameObject.GetComponent<Room>().roomNumber = int.Parse(PhotonNetwork.CurrentRoom.Name);
            gameObject.GetComponent<Room>().roomPeopleCurrentNum = PhotonNetwork.CurrentRoom.PlayerCount;
            gameObject.GetComponent<Room>().roomPeopleMaxNum = 8;
            roomList.Add(gameObject);
            */
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList){
            roomObjectList.Clear();

            for (int i = 0; i < roomList.Count; i++){
                GameObject gameObject = Instantiate(roomObject.gameObject, roomObjectRoot.transform) as GameObject;
                gameObject.GetComponent<Room>().roomNumber = int.Parse(roomList[i].Name);
                gameObject.GetComponent<Room>().roomPeopleCurrentNum = roomList[i].PlayerCount;
                gameObject.GetComponent<Room>().roomPeopleMaxNum = roomList[i].MaxPlayers;
                roomObjectList.Add(gameObject);
            }
        }

        public void OnClickedMenuButtom() {
            isMenuActive = !isMenuActive;
            menuPopup.SetActive(isMenuActive);
        }
        
        public void OnClickedEixtButton() {  PhotonNetwork.Disconnect(); }
    }
}