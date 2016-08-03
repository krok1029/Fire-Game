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
        var sceneManager = GameObject.Find("SceneManager2");
        if (null != sceneManager)
        {
            money += GameObject.Find("SceneManager2").GetComponent<SceneManager2>().getmoney;
        }
    }
	
	// Update is called once per frame
	void Update () {
        playermoneyText.text = "Money : " + money;

	}
}
