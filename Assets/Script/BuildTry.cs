using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class BuildTry : MonoBehaviour {

    public GameObject madeObject;
    int objectLimit;
    private int counter = 0;
    private int objectID;
    private static int currentObjectID = 0;
    int BuildObjectMove=0;

    void Start()
    {

    }
  
          public GameObject particle;
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
                Instantiate(particle, transform.position, transform.rotation);
        }
    }

    public void makeObject()
    {
        GameObject clone;

            clone = Instantiate(madeObject, Input.mousePosition, Quaternion.identity) as GameObject;
            clone.transform.position =Input.mousePosition;
            clone.transform.Rotate(new Vector3(-90, 0, 0));


    }

}
