using Project.Common.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Room{

    public class RoomUser : MonoBehaviour{

        [SerializeField] private Image characterImage;
        [SerializeField] private TMP_Text userNameText;
        [SerializeField] private GameObject readyImage;

        public CharacterType characterType;
        public string userName;
        public bool isReady;


        /*
        public RoomUser(string name, CharacterType type = CharacterType.Cat, bool ready = false) {
            characterType = type;
            userName = name;
            isReady = ready;
        }
        */

        private void Start() {
            userNameText.text = userName;
            readyImage.SetActive(false);
        }

    }
}