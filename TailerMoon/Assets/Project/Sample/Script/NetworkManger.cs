using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class NetworkManger : MonoBehaviourPunCallbacks
{
    [SerializeField] TextMeshProUGUI serverStatusText;
    [SerializeField] TMP_InputField nicknameInput, roomNameInput;

    private void Awake() => Screen.SetResolution(960, 540, false);
    private void Update() => serverStatusText.text = PhotonNetwork.NetworkClientState.ToString();

    public void OnClickedServerConnect() => PhotonNetwork.ConnectUsingSettings();
    public override void OnConnectedToMaster() {
        Debug.Log("서버접속완료");
        PhotonNetwork.LocalPlayer.NickName = nicknameInput.text;
    }

    public void OnClickedServerNonConnect() => PhotonNetwork.Disconnect();
    public override void OnDisconnected(DisconnectCause cause) => print("연결끊김");

    public void OnClickedConnectLobby() => PhotonNetwork.JoinLobby();
    public override void OnJoinedLobby() => print("로비접속완료");

    public void OnClickedMakeRoom() => PhotonNetwork.CreateRoom(roomNameInput.text, new RoomOptions { MaxPlayers = 2 });
    public override void OnCreatedRoom() => print("방만들기 완료");
    public override void OnCreateRoomFailed(short returnCode, string message) => print("방만들기 실패");

    public void OnClickedEnterRoom() => PhotonNetwork.JoinRoom(roomNameInput.text);
    public override void OnJoinedRoom() => print("방참가 완료");
    public override void OnJoinRoomFailed(short returnCode, string message) => print("방참가 실패");

    public void OnClickedMakeRoomEnterRoom() => PhotonNetwork.JoinOrCreateRoom(roomNameInput.text, new RoomOptions { MaxPlayers = 2 }, null);

    public void OnClickedEnterRandomRoom() => PhotonNetwork.JoinRandomRoom();
    public override void OnJoinRandomFailed(short returnCode, string message) => print("방랜덤참가 실패");

    public void OnClickedLeaveRoom() => PhotonNetwork.LeaveRoom();
    public override void OnLeftRoom() => print("방떠나기");

    [ContextMenu("Info")]
    void Info() {
        if (PhotonNetwork.InRoom) {
            print("현재 방 이름: " + PhotonNetwork.CurrentRoom.Name);
            print("현재 방 인원수: " + PhotonNetwork.CurrentRoom.PlayerCount);
            print("현재 방 최대 인원 수: " + PhotonNetwork.CurrentRoom.MaxPlayers);
            string playerString = "방에 있는 플레이어 목록: ";
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) playerString += PhotonNetwork.PlayerList[i].NickName + ", ";
            print(playerString);
        }
        else {//Lobby에 있을 때
            print("접속한 인원 수: " + PhotonNetwork.CountOfPlayers);
            print("방 개수: " + PhotonNetwork.CountOfRooms);
            print("모든 방 인원 수: " + PhotonNetwork.CountOfPlayersInRooms);
            print("로비에 있는지?: " + PhotonNetwork.InLobby);
            print("연결됐는지?: " + PhotonNetwork.IsConnected);
        }
    }
}
