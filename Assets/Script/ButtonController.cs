using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonController : MonoBehaviour {
    public GameObject build;
    public GameObject buildList;
    public GameObject buildbutton;
    public GameObject backbutton;
    public Transform building;

   
  

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

}

