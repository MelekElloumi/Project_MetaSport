using UnityEngine;
using Photon.Pun;
using TMPro;
public class playerstats_controller : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject window;
    [SerializeField] GameObject username;
    [SerializeField] PhotonView playerPV;
    [SerializeField] GameObject icon;
    // Start is called before the first frame update
    void Start()
    {
        if (playerPV.IsMine)
        {
            canvas.SetActive(false);
        }
        username.GetComponent<TextMeshProUGUI>().text = playerPV.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPV.IsMine)
        {
            if (Input.GetKey(KeyCode.T))
            {
                icon.SetActive(true);
            }
            if (Input.GetKeyUp(KeyCode.T))
            {
                icon.SetActive(false);
            }
        }
    }
    private void OnMouseDown()
    {
        window.SetActive(!window.activeInHierarchy);
    }

}
