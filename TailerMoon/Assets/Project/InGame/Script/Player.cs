using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Project.InGame {

    public class Player : MonoBehaviourPunCallbacks, IPunObservable{

        [SerializeField] private TextMeshProUGUI userNameText;
        [SerializeField] private TextMeshProUGUI countText;
        [SerializeField] private PhotonView photonView;

        [SerializeField] private Joystick joystick;
        private const float speed = 0.1f;

        private void Awake() {
            userNameText.text = photonView.IsMine ? PhotonNetwork.NickName : photonView.Owner.NickName;
            userNameText.color = photonView.IsMine ? Color.yellow : Color.green;
        }

        private void Start() {
            StartCoroutine(MovePlayer());
        }

        private IEnumerator MovePlayer() {
            while (true) {
                float moveHorizontal = joystick.moveHorizontal;
                float moveVertical = joystick.moveVertical;
                Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                transform.localPosition = movement;
                yield return null;
            }
        }

        private void Update() {
            if (photonView.IsMine) {

            }
        }

        [PunRPC]
        private void FlipXRPC(float axis) {

        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {

        }
    }
}