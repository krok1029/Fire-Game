using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Parse;

public class PlayerMoney : MonoBehaviour {
    public Text playermoneyText;
    public int money=1000;
    int getmoney;
    NowLevel getlevel;
	// Use this for initialization
	void Start () {
        getlevel = GameObject.Find("Main Camera").GetComponent<NowLevel>();
    }
	
	// Update is called once per frame
	void Update () {
        if (getlevel.level != 0)
        {
            playermoneyText.text = "Money : " + money;
        }
	}
}
