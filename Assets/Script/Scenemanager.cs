using UnityEngine;
using System.Collections;

public class Scenemanager : MonoBehaviour {
    GameObject userNum;
    public int userNumber;

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
    }
	// Update is called once per frame
	void Update () {

    }
}
