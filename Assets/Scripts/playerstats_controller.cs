using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Voice;
using Photon.Realtime;
public class playerstats_controller : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject window;
    [SerializeField] GameObject username;
    [SerializeField] PhotonView playerPV;
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

    }
    private void OnMouseDown()
    {
        if (!playerPV.IsMine)
        {
            window.SetActive(true);
        }
    }

}
