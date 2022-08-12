using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Photon.Pun;
using Photon.Realtime;

namespace Com.MyCompany.MyGame
{
public class ChatBox : MonoBehaviourPun
{
    public Text chatLogText;
    public InputField chatInput;
    public static ChatBox instance;
    void Awake() {
        Debug.Log("hello");
        instance = this;
        Debug.Log(chatLogText, chatInput);

    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (EventSystem.current.currentSelectedGameObject == chatInput)
                OnChatInputSend();
            else
                EventSystem.current.SetSelectedGameObject(chatInput.gameObject);
        }
    }
    // called when sending msg
    public void OnChatInputSend() {
        Debug.Log(photonView);

        if (chatInput != null) {
            if (chatInput.text.Length > 0) {
               photonView.RPC("Log", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName, chatInput.text); 
               chatInput.text = "";
            }
            EventSystem.current.SetSelectedGameObject(null);
        }
        else {
            Debug.Log("reference to chatInput not found");
        }
    }
    [PunRPC]
    void Log( string playerName, string message) {
        chatLogText.text += string.Format("<b>{0}: </b> {1} \n", playerName, message);
        chatLogText.transform.position = new Vector3(chatLogText.transform.position.x, chatLogText.transform.position.y  + 10, chatLogText.transform.position.z );
    }
}
}