using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Photon.Pun.UtilityScripts;

public class LauncherScript : MonoBehaviourPunCallbacks
{
    public Vector3 pos;
    public PhotonView playerPrefab;
    public Vector3 min = new Vector3(-5, 0, 0);
    public Vector3 max = new Vector3(5, 0, 7);
    public GameObject thePlayer;
    public GameObject chat;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdRealtime);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room successfully!");
        pos = new Vector3(UnityEngine.Random.Range(-5,5), 0, UnityEngine.Random.Range(0,7));
        //Debug.Log(pos);
        //pos = new Vector3(38, 0, 16);
        //GameObject o=PhotonNetwork.Instantiate(PlayerPrefs.GetString("PrefabName"), pos, Quaternion.identity);
        thePlayer = PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);

        int p = UnityEngine.Random.Range(0, 10);
        string Username = "TesingBot" + p.ToString();
        PhotonNetwork.LocalPlayer.NickName = Username;
        Debug.Log("1" + PhotonNetwork.LocalPlayer.NickName);

        chat.GetComponent<Photon.Pun.Demo.PunBasics.ConnectedPlayers>().displayPlayers();

    }

    // Update is called once per frame
    void Update()
    {

    }
}