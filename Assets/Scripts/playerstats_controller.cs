using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class playerstats_controller : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject window;
    [SerializeField] Text username;
    [SerializeField] PhotonView playerPV;
    // Start is called before the first frame update
    void Start()
    {
        if (playerPV.IsMine)
        {
            canvas.SetActive(false);
        }
        username.text = playerPV.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        window.SetActive(!window.activeInHierarchy);
    }

}
