using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
public class Mouselock_controller : MonoBehaviour
{
    MonoBehaviour cameraScript;
    PlayerInput player;
    public GameObject cursor;
    public static bool isLocked=false;
    bool playerIsIn = false;
    bool withControl = true;

    // Update is called once per frame
    private void Start()
    {
        cameraScript=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineBrain>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            lockscreen();
        }
    }

    public void lockscreen()
    {
        if (withControl)
        {
            if (!playerIsIn)
            {
                player = GameObject.FindGameObjectWithTag("photonmanager").GetComponent<LauncherScript>().thePlayer.GetComponent<PlayerInput>();
                playerIsIn = true;
            }
            isLocked = !isLocked;
            Cursor.visible = true;
            Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked) ? CursorLockMode.Confined : CursorLockMode.Locked;
            cursor.SetActive(!cursor.activeInHierarchy);
            cameraScript.enabled = !cameraScript.enabled;
            player.enabled = !player.enabled;
        }   
    }
    public void locking()
    {
        lockscreen();
        withControl = false;
    }
    public void deblocking()
    {
        withControl = true;
        lockscreen();
        
    }
}
