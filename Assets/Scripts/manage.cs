using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Photon.Pun.UtilityScripts;
using UnityEngine.SceneManagement;
using Photon.Voice;

public class manage : MonoBehaviourPunCallbacks
{
    public Vector3 pos;
    private string id_sync = "eabb3d0c-d85f-459a-a185-77e3cc91b45e";
    private string id_voice = "216bfab1-b3c0-44f6-9477-54fc24d7ed9c";
    public PhotonView playerPrefab;
    public Vector3 min = new Vector3(-5, 0, 0);
    public Vector3 max = new Vector3(5, 0, 7);

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.PhotonServerSettings.AppSettings.AppIdRealtime = id_sync;
        PhotonNetwork.PhotonServerSettings.AppSettings.AppIdVoice = id_voice;
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
        pos = new Vector3(UnityEngine.Random.Range(-5, 5), 0, UnityEngine.Random.Range(0, 7));
        //Debug.Log(pos);
        //pos = new Vector3(38, 0, 16);
        PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            StartCoroutine(DisconnectAndLoad());
        }
    }
    IEnumerator DisconnectAndLoad()
    {
        PhotonNetwork.Disconnect();
        while (PhotonNetwork.IsConnected)
            yield return null;
        SceneManager.LoadScene("Game");
    }
}
