using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class BuildObject_BakerHouse : MonoBehaviour
{
    public GameObject madeObject;
    int objectLimit;
    public int officecounter=0;
    private int objectID;
    private static int currentObjectID = 0;
    public Text levelnum;
    int levelnumber;
    GameObject levelNum;
    public int buildCost;
    PlayerMoney buildmoney;
    public Text consoleText;
    public GameObject console;

    void Start()
    {
        buildmoney = GameObject.Find("Main Camera").GetComponent<PlayerMoney>();
        objectID = currentObjectID;
        currentObjectID++;
        officecounter = Resources.FindObjectsOfTypeAll(typeof(BuildObject_BakerHouse)).Length - 3;
        levelNum = GameObject.Find("Main Camera");
        levelnumber = levelNum.GetComponent<NowLevel>().level;
        objectLimit = levelnumber;
/*
        UnityEngine.Object[] tyu = Resources.FindObjectsOfTypeAll(typeof(BuildObject_BakerHouse));
        Debug.Log("bakerhouse=" + Resources.FindObjectsOfTypeAll(typeof(BuildObject_BakerHouse)).Length);
        for(int i=0;i< Resources.FindObjectsOfTypeAll(typeof(BuildObject_BakerHouse)).Length; i++) { Debug.Log(tyu[i].name); }
  */  }
    void Update()
    {
        levelnumber = levelNum.GetComponent<NowLevel>().level;
        objectLimit = levelnumber;
        officecounter = Resources.FindObjectsOfTypeAll(typeof(BuildObject_BakerHouse)).Length - 3;
    }
    public void makeObject()
    {
        if (buildmoney.money - buildCost > 0)
        {
            GameObject clone;
            if (officecounter >= objectLimit)
            {
                consoleText.text = "Your level is not enough \n Please level up";
                console.SetActive(true);
            }
            else
            {
                buildmoney.money -= buildCost;
                clone = Instantiate(madeObject, Input.mousePosition, Quaternion.identity) as GameObject;
                clone.transform.position = Vector3.Slerp(Input.mousePosition, new Vector3(-5.5f, 0, 5f), 1f);
                clone.transform.Rotate(new Vector3(-90, 0, 0));
            }
        }
        else
        {
            consoleText.text = "Money is not enough";
            console.SetActive(true);
        }
    }
}