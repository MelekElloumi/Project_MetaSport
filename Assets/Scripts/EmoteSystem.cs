using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class EmoteSystem : MonoBehaviourPun
{
    PhotonView pv;
    Animator anim;
    void Start()
    {
        pv=GetComponent<PhotonView>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pv.IsMine)
        {
            if (NonUIInput.GetKeyDown(KeyCode.I))
            {
                photonView.RPC("Emote", RpcTarget.All);            

            }

        }
        
    }

    [PunRPC]
    void Emote()
    {
        anim.SetTrigger("Emoting");
    }
}
