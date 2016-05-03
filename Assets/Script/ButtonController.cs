using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonController : MonoBehaviour {
    public GameObject build;
    public GameObject buildList;
    public GameObject buildbutton;
    public GameObject backbutton;
    public Transform building;
    public GameObject LogIn;
    bool loginbool=false;
    void Start()
    {
        if (PlayerPrefsX.GetBool("login"))
        {
            LogIn.SetActive(false);
        }
    }
  

    public void appear()
    {
        buildList.SetActive(true);
        build.SetActive(true);
        backbutton.SetActive(true);
        buildbutton.SetActive(false);
    
    }


    public void disappear()
    {
        buildList.SetActive(false);
        build.SetActive(false);
        backbutton.SetActive(false);
        buildbutton.SetActive(true);
      
    }
    public void login()
    {
        Destroy(LogIn);
        loginbool = true;
        PlayerPrefsX.SetBool("login", loginbool);
    }
}

