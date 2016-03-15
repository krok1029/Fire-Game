using UnityEngine;
using System.Collections;

public class BuildObject : MonoBehaviour
{
    //Vector3 position3 = new Vector3(0, 0, 0);
    public Texture img;//图片/  
    public GameObject madeObject;
    
    public void OnGUI()
    {

        GUI.Label(new Rect(-590, 175, 175, 175), img);
    }
    public void makeObject()
    {
        GameObject clone;
        clone = Instantiate(madeObject, Input.mousePosition, Quaternion.identity) as GameObject;
        clone.transform.position = Vector3.Slerp(Input.mousePosition, new Vector3(5, 4.793643f, 3), 1f);
    }
  
}