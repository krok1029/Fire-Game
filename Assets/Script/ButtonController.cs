using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonController : MonoBehaviour {
    public GameObject build;
    public GameObject buildList;
    public float speed = 50;
    public Transform building;
    public void appear()
    {
        buildList.SetActive(true);
        build.SetActive(true);        
    }


    public void disappear()
    {
        buildList.SetActive(false);
        build.SetActive(false);
    
    }

}

