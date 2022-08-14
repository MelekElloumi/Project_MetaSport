using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

namespace Com.MyCompany.MyGame
{
    public class ChatBox : MonoBehaviourPun
    {
        public GameObject chatLogText;
        public GameObject chatInput;
        TextMeshProUGUI tmplog;
        TMP_InputField tmpinput;
        void Start()
        {
            tmplog = chatLogText.GetComponent<TextMeshProUGUI>();
            tmpinput = chatInput.GetComponent<TMP_InputField>();
        }
        void Update() {
            if (EventSystem.current.currentSelectedGameObject!=null && EventSystem.current.currentSelectedGameObject.name == "Message input")
            {
                if (Input.GetKeyUp(KeyCode.Return))
                    {
                        OnChatInputSend();
                        tmpinput.ActivateInputField();
                    }
            }
            
            
        }
        // called when sending msg
        public void OnChatInputSend() {
            if (chatInput != null) {
                if (tmpinput.text.Length > 0) {
                    photonView.RPC("Log", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName, tmpinput.text);
                }
                //EventSystem.current.SetSelectedGameObject(null);
            }
            else {
                Debug.Log("reference to chatInput not found");
            }
        }
        [PunRPC]
        void Log( string playerName, string message) {
            tmplog.text += string.Format("<b>{0} :</b> {1}\n\n", playerName, message);
            tmpinput.text = "";
        }
    }
}