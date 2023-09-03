using Photon.Pun;
using Project.Common.System;
using TMPro;
using UnityEngine;

namespace Project.Lobby
{
    public class Room : MonoBehaviourPunCallbacks{

        [SerializeField] private TextMeshProUGUI roomNumberText;
        [SerializeField] private TextMeshProUGUI roomPeopleText;

        public int roomNumber;
        public int roomPeopleCurrentNum;
        public int roomPeopleMaxNum;

        private void Start(){
            roomNumberText.text = roomNumber.ToString();
            roomPeopleText.text = roomPeopleCurrentNum + "/" + roomPeopleMaxNum;
        }

        public void EnterRoom(int roomNumber){
            PhotonNetwork.JoinRoom(roomNumber.ToString());
        }

        public override void OnJoinedRoom() {
            SceneManager.Instance.LoadScene(SceneType.RoomScene);
        }
    }

}