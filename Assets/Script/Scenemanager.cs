using UnityEngine;
using System.Collections;

public class Scenemanager : MonoBehaviour {
    GameObject userNum;
    public int userNumber;
    GameObject allUser;
    public int counter;
    GameObject getLevel;
    public int nowLevel;
    int n = 0;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    // Use this for initialization
    void Start () {

	}
    public void Save() {
        userNum = GameObject.Find("Main Camera");
        userNumber = userNum.GetComponent<NowLevel>().userValue;
        allUser = GameObject.Find("Main Camera");
        counter = allUser.GetComponent<userCounter>().c;
    }
	// Update is called once per frame
	void Update () {
        getLevel = GameObject.Find("Main Camera");
        nowLevel = getLevel.GetComponent<NowLevel>().level;
    }
}
