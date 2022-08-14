using UnityEngine;

public class UI_elements : MonoBehaviour
{
    public static GameObject highlight;
    private void Awake()
    {
        highlight = GameObject.FindGameObjectWithTag("cur_high");
        highlight.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
