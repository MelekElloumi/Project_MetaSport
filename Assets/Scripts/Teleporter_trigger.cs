using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Teleporter_trigger : MonoBehaviour
{
    public GameObject panel;
    public GameObject prompt;
    public GameObject mouselocksys;
    public string scenename;
    private void OnTriggerEnter(Collider other)
    {
        mouselocksys.GetComponent<Mouselock_controller>().locking();
        panel.SetActive(true);
        prompt.GetComponent<Text>().text= "Do you want to teleport to " + scenename+" ?";
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
