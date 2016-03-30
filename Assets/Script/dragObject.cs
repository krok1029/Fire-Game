using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class dragObject : MonoBehaviour {
    public float speed = 15;
    public Transform building ;
    public Button backbutton;
    public Button buildbutton;
    public Button Lockbutton;
    bool i; 


    void OnMouseDrag()
    { 
       building.position += Vector3.right * Time.deltaTime * Input.GetAxis("Mouse X") * speed * 10;
       building.position += Vector3.forward * Time.deltaTime * Input.GetAxis("Mouse Y") * speed * 10;


        backbutton.onClick.AddListener(click1);
        buildbutton.onClick.AddListener(click2);
        Lockbutton.onClick.AddListener(click1);
        if (i==true)
        {
            speed = 0;
        }
        if (i == false)
        {
            speed = 15;
        }
       // Debug.Log(speed);

    }

    void click1()
    {
        i = true;

    }
    void click2()
    {
        i = false;
    }
   
}
