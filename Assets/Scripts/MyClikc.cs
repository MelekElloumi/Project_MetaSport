using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MyClikc : MonoBehaviour
{
    // Start is called before the first frame update
    public Button nextButton;
	
	public Button loadButton;
	
	public GameObject[] myPrefab;
	
	public GameObject NickName;
	
	private int x = 0;
	
	GameObject player;
	
	TextMeshProUGUI mText;

	void Start () {
		
		mText = NickName.GetComponent<TextMeshProUGUI>();
		
		player = Instantiate(myPrefab[0], new Vector3(0, 1, 0), Quaternion.identity);

		PlayerPrefs.SetString("PrefabName", myPrefab[x].name);
		
		nextButton.onClick.AddListener(ShowNextCharacter);

		loadButton.onClick.AddListener(SceneLoader);

		mText.SetText(myPrefab[x].name);
	}

	void ShowNextCharacter(){
		
		Destroy(player);
		
		if (x < (myPrefab.Length - 1)) x++;
		else x = 0;
		
		mText.SetText(myPrefab[x].name);
		
		player = Instantiate(myPrefab[x], new Vector3(0, 2, 0), Quaternion.identity);

	}

	void SceneLoader()
    {
		PlayerPrefs.SetString("PrefabName", myPrefab[x].name);
		PlayerPrefs.Save();
		SceneManager.LoadScene("Game");
	}


}

