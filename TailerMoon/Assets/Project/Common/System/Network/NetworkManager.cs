using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;


namespace Project.Common.System {

    public class NetworkManager : MonoBehaviourPunCallbacks {
        private static NetworkManager instance;

        private void Awake() {
            if (instance == null){
                instance = this;
            }
        }

        public static NetworkManager Instance {
            get {
                if(instance == null) {
                    return null;
                }
                return instance;
            }
        }

        public override void OnConnectedToMaster() => Debug.Log("�������ӿϷ�");
        public override void OnDisconnected(DisconnectCause cause) => print("�������");

        public override void OnJoinedLobby() => print("�κ����ӿϷ�");

        public override void OnCreatedRoom() => print("�游��� �Ϸ�");
        public override void OnCreateRoomFailed(short returnCode, string message) =>  print("�游��� ����");

        public override void OnJoinedRoom() => print("������ �Ϸ�");
        public override void OnJoinRoomFailed(short returnCode, string message) => print("������ ����");
        public override void OnJoinRandomFailed(short returnCode, string message) => print("�淣������ ����");

        public override void OnLeftRoom() => print("�涰����");


        [ContextMenu("Info")]
        void Info()
        {
            if (PhotonNetwork.InRoom)
            {
                print("���� �� �̸�: " + PhotonNetwork.CurrentRoom.Name);
                print("���� �� �ο���: " + PhotonNetwork.CurrentRoom.PlayerCount);
                print("���� �� �ִ� �ο� ��: " + PhotonNetwork.CurrentRoom.MaxPlayers);
                string playerString = "�濡 �ִ� �÷��̾� ���: ";
                for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) playerString += PhotonNetwork.PlayerList[i].NickName + ", ";
                print(playerString);
            }
            else
            {//Lobby�� ���� ��
                print("������ �ο� ��: " + PhotonNetwork.CountOfPlayers);
                print("�� ����: " + PhotonNetwork.CountOfRooms);
                print("��� �� �ο� ��: " + PhotonNetwork.CountOfPlayersInRooms);
                print("�κ� �ִ���?: " + PhotonNetwork.InLobby);
                print("����ƴ���?: " + PhotonNetwork.IsConnected);
            }
        }
    }

}