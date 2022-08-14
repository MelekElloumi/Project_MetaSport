using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;

public class Teleporter_trigger : MonoBehaviour
{
    public GameObject panel;
    public GameObject prompt;
    public GameObject mouselocksys;
    public string scenename;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PhotonView>() != null)
        {
            if (other.GetComponent<PhotonView>().IsMine)
            {
                mouselocksys.GetComponent<Mouselock_controller>().locking(false);
                panel.SetActive(true);
                prompt.GetComponent<TextMeshProUGUI>().text = "Do you want to teleport to " + scenename + " ?";
            }
        }
        
    }
    public void TeleportYes()
    {
        mouselocksys.GetComponent<Mouselock_controller>().deblocking();
        SceneManager.LoadScene(scenename);
    }
    public void TeleportNo()
    {
        mouselocksys.GetComponent<Mouselock_controller>().deblocking();
        panel.SetActive(false);
    }
}
