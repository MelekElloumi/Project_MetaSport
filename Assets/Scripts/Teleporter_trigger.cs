using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using Photon.Pun;

public class Teleporter_trigger : MonoBehaviour
{
    public GameObject panel;
    public GameObject prompt;
    public GameObject mouselocksys;
    public string scenename;
    public Transform target;
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
        //SceneManager.LoadScene(scenename);
        StartCoroutine("Teleport");
        panel.SetActive(false);

    }

    private IEnumerator Teleport()
    {
        GameObject player = GameObject.FindGameObjectWithTag("photonmanager").GetComponent<LauncherScript>().thePlayer;
        player.GetComponent<CharacterController>().enabled = false;
        yield return new WaitForSeconds(0.01f);
        player.transform.position = target.position;
        yield return new WaitForSeconds(0.01f);
        player.GetComponent<CharacterController>().enabled = true;
    }
    public void TeleportNo()
    {
        mouselocksys.GetComponent<Mouselock_controller>().deblocking();
        panel.SetActive(false);
    }
}
