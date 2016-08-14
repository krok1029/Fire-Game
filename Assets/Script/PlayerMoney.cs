using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Parse;

public class PlayerMoney : MonoBehaviour {
    public Text playermoneyText;
    public int money=1000;
    int getmoney;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        playermoneyText.text = "Money : " + money;

	}
}
