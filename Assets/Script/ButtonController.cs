using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonController : MonoBehaviour {
    public GameObject build;
    public GameObject buildList;
    public GameObject buildbutton;
    public GameObject backbutton;
    public Transform building;

    private float time=0.0f;
    void Start()
    {
        //time = PlayerPrefs.GetFloat("Timer", 0.0f);
    }
    void Update()
    {
        //time += Time.deltaTime;
    }
   // void OnGUI()
    //{
     //   GUILayout.Label(time.ToString());
   // }

    public void appear()
    {
        buildList.SetActive(true);
        build.SetActive(true);
        backbutton.SetActive(true);
        buildbutton.SetActive(false);
      //  PlayerPrefs.SetFloat("Timer", time);
        //PlayerPrefs.Save();
    }


    public void disappear()
    {
        buildList.SetActive(false);
        build.SetActive(false);
        backbutton.SetActive(false);
        buildbutton.SetActive(true);
    }

}

