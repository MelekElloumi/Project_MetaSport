using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Voice;
using Photon.Realtime;
public class playerstats_controller : MonoBehaviourPun
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject window;
    [SerializeField] GameObject username;
    [SerializeField] PhotonView playerPV;

    public SkinnedMeshRenderer top_wear, bottom_wear, shoes;
    public int i, j, k;
    public Material[] myColors;
    // Start is called before the first frame update
    void Start()
    {
        i = j = k = 0;
        username.GetComponent<TextMeshProUGUI>().text = playerPV.Owner.NickName;
        if (playerPV.IsMine)
        {
            username.SetActive(false);
            photonView.RPC("SetSkinn", RpcTarget.AllBuffered, PlayerPrefs.GetInt("Top_wear"), PlayerPrefs.GetInt("Bottom_wear"), PlayerPrefs.GetInt("Shoes"));
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

    public void TopIncrement()
    {
        i = IncrementIndex(i);

        top_wear.material = myColors[i];
    }
    public void TopDecrement()
    {
        i = DecrementIndex(i);

        top_wear.material = myColors[i];
    }
    public void BottomIncrement()
    {
        j = IncrementIndex(j);

        bottom_wear.material = myColors[j];
    }
    public void BottomDecrement()
    {
        j = DecrementIndex(j);

        bottom_wear.material = myColors[j];
    }
    public void ShoesIncrement()
    {
        k = IncrementIndex(k);

        shoes.material = myColors[k];
    }
    public void ShoesDecrement()
    {
        k = DecrementIndex(k);

        shoes.material = myColors[k];
    }

    int IncrementIndex(int x)
    {
        if (x == myColors.Length - 1) x = 0;

        else x++;
        return x;
    }

    int DecrementIndex(int x)
    {
        if (x == 0) x = myColors.Length - 1;

        else x--;

        return x;
    }
    [PunRPC]
    public void SetSkinn(int a, int b, int c)
    {
        top_wear.material = myColors[a];
        bottom_wear.material = myColors[b];
        shoes.material = myColors[c];
    }

}