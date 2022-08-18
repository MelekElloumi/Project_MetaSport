using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Voice;
using Photon.Realtime;
public class playerstats_controller : MonoBehaviourPun
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject window;
    [SerializeField] GameObject username;
    [SerializeField] PhotonView playerPV;
    [SerializeField] SkinnedMeshRenderer myMesh;
    public Material myColor;
    // Start is called before the first frame update
    void Start()
    {
        username.GetComponent<TextMeshProUGUI>().text = playerPV.Owner.NickName;
        if (playerPV.IsMine)
        {
            username.SetActive(false);
        }    
        window.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPV.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                photonView.RPC("skinchange", RpcTarget.AllBuffered);
            }
        }
        
    }
    private void OnMouseDown()
    {
        if (!playerPV.IsMine)
        {
            window.SetActive(true);
        }
    }

    [PunRPC]
    void skinchange()
    {
        myMesh.material = myColor;
        /*if (text.GetComponent<TextMeshProUGUI>().text == playerName)
        {
            
        }
        else
        {
            Debug.Log("didn't send");
        }*/
    }


}








/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyColor : MonoBehaviour
{
    public SkinnedMeshRenderer myMesh;
    public Material[] myColors;
    private int x = 0;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            incrementIndex();
            myMesh.material = myColors[x];
        }
    }

    void incrementIndex()
    {
        if (x == myColors.Length - 1) x = 0;
        else x++;
    }
}
*/