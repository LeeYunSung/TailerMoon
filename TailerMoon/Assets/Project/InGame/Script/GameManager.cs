using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject GameResultPopup;
    [SerializeField] private GameObject playerObjectRoot;

    private const string PLAYER_PREFAB_NAME = "Player";

    private void Start() {
        //GameObject gameObject = PhotonNetwork.Instantiate(PLAYER_PREFAB_NAME, playerObjectRoot.transform.position, Quaternion.identity);
        //gameObject.transform.SetParent(playerObjectRoot.transform);
        //gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

}
