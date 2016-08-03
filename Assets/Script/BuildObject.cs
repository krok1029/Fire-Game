using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Parse;

public class BuildObject : MonoBehaviour
{
    public GameObject madeObject;
    int objectLimit;
    private int counter = 0;
    private int objectID;
    private int currentObjectID = 0;
    public Text levelnum;
    GameObject levelNum;
    public int buildCost;
    PlayerMoney buildmoney;

    void Start()
    {
        buildmoney = GameObject.Find("Main Camera").GetComponent<PlayerMoney>();
        objectID = currentObjectID;
        currentObjectID++;
        counter = PlayerPrefs.GetInt("ObjectInt_Lamp" + objectID.ToString());
        levelNum = GameObject.Find("Main Camera");
        objectLimit = levelNum.GetComponent<NowLevel>().level;
    }
    void Update()
    {
        objectLimit = levelNum.GetComponent<NowLevel>().level;
    }
    public void makeObject()
    {
        if (buildmoney.money - buildCost > 0)
        {
            buildmoney.money -= buildCost;
            GameObject clone;
            if (counter >= objectLimit)
            {
                CancelInvoke();
            }
            else
            {
                clone = Instantiate(madeObject, Input.mousePosition, Quaternion.identity) as GameObject;
                clone.transform.position = Vector3.Slerp(Input.mousePosition, new Vector3(-5.5f, 5.0f, 4.7f), 1f);
                clone.transform.Rotate(new Vector3(0, 0, 0));
                counter = counter + 1;
            }
        }
        else { Debug.Log("money is not enough"); }
    }
    public void counterSave()
    {
        PlayerPrefs.SetInt("ObjectInt_Lamp" + objectID.ToString(), counter);
    }
   

}