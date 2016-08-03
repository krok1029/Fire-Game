using UnityEngine;
using System.Collections;

public class SceneManager2 : MonoBehaviour {
    public int brokenRate;
    public int getmoney;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        getmoney = GameObject.Find("Main Camera").GetComponent<SelfSavingTimer>().getmoney;
        brokenRate = (int)GameObject.Find("Main Camera").GetComponent<SelfSavingTimer>().brokenRate;
    }
}
