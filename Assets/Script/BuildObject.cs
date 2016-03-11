using UnityEngine;
using System.Collections;

public class BuildObject : MonoBehaviour
{

    public Texture img;//图片/  
    public GameObject madeObject;
    private Vector3 poistion3= new Vector3(0,0,0);

   public void OnGUI()
    {

        GUI.Label(new Rect(-590,175, 175, 175), img);
    }
   public void makeObject()
    {
        Instantiate(madeObject, poistion3, Quaternion.identity);
    }
}