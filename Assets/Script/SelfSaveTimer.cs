using UnityEngine;
using System.Collections;

public class SelfSaveTimer : MonoBehaviour {
    private float time = 0.0f;
	
	void Start ()
    {
        time= PlayerPrefs.GetFloat("Timer",0.0f);
	}
	
	void Update () {
        time += Time.deltaTime;
	}
    void OnDestory()
    {
        PlayerPrefs.SetFloat("Timer", time);
        PlayerPrefs.Save();
    }
    void OnGUI()
    {
        GUILayout.Label(time.ToString()); 
    }
}
