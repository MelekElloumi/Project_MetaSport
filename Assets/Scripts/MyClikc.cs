using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;

public class MyClikc : MonoBehaviour
{
    // Start is called before the first frame update
    public Button nextButton;
	public Button previousButton;
	public Button loadButton;
	
	public GameObject[] myPrefab;
	
	public GameObject NickName;
	
	private int x = 0;
	
	GameObject player;
	
	TextMeshProUGUI mText;

	void Start () {

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		mText = NickName.GetComponent<TextMeshProUGUI>();
		
		player = Instantiate(myPrefab[0], new Vector3(0, 0.1f, -1.6f), Quaternion.identity);
		foreach(Transform child in player.transform)
        {
			child.gameObject.SetActive(false);
        }
		player.transform.GetChild(0).gameObject.SetActive(true);
		player.transform.GetChild(1).gameObject.SetActive(true);
		player.GetComponent<ThirdPersonController>().enabled=false;
		player.GetComponent<playerstats_controller>().enabled = false;
		player.GetComponent<Mouse_highlighter>().enabled = false;
		player.GetComponent<push2talk>().enabled = false;
		player.transform.Rotate(new Vector3(0, 180, 0));

		PlayerPrefs.SetString("PrefabName", myPrefab[x].name);
		
		nextButton.onClick.AddListener(ShowNextCharacter);

		previousButton.onClick.AddListener(ShowPreviousCharacter);

		loadButton.onClick.AddListener(SceneLoader);

		mText.SetText(myPrefab[x].name);
	}

    private void Update()
    {
		if (NonUIInput.GetKeyDown(KeyCode.LeftControl))
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		
	}

    void ShowNextCharacter(){

		Destroy(player);
		
		x = (x + 1) % myPrefab.Length;

		mText.SetText(myPrefab[x].name);

		player = Instantiate(myPrefab[x], new Vector3(0, 0.1f, -1.6f), Quaternion.identity);
		player.GetComponent<Mouse_highlighter>().enabled = false;
		foreach (Transform child in player.transform)
		{
			child.gameObject.SetActive(false);
		}
		player.transform.GetChild(0).gameObject.SetActive(true);
		player.transform.GetChild(1).gameObject.SetActive(true);
		player.GetComponent<ThirdPersonController>().enabled = false;
		player.GetComponent<playerstats_controller>().enabled = false;
		
		player.transform.Rotate(new Vector3(0, 180, 0));

	}

	void ShowPreviousCharacter()
	{
		Destroy(player);

		x = x - 1;
		if(x < 0)
        {
			x = myPrefab.Length - 1;

		}

		mText.SetText(myPrefab[x].name);

		player = Instantiate(myPrefab[x], new Vector3(0, 0.1f, -1.6f), Quaternion.identity);
		foreach (Transform child in player.transform)
		{
			child.gameObject.SetActive(false);
		}
		player.transform.GetChild(0).gameObject.SetActive(true);
		player.transform.GetChild(1).gameObject.SetActive(true);
		player.GetComponent<ThirdPersonController>().enabled = false;
		player.GetComponent<playerstats_controller>().enabled = false;
		player.GetComponent<Mouse_highlighter>().enabled = false;
		player.transform.Rotate(new Vector3(0, 180, 0));

	}

	void SceneLoader()
    {
		PlayerPrefs.SetString("PrefabName", myPrefab[x].name);
		PlayerPrefs.Save();
		SceneManager.LoadScene("Game");
	}


}

