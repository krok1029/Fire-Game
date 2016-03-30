using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class dragObject : MonoBehaviour {
    public float speed = 15;
    public Transform building ;
    public Button backbutton;
    public Button buildbutton;
    public Button Lockbutton;
    private bool i=true;
    int test = 0;

    void Start() {
        backbutton.onClick.AddListener(click1);
        buildbutton.onClick.AddListener(click2);
        //Lockbutton.onClick.AddListener(click1);
    }

    void OnMouseDrag()
    {
        if (i == true)
        {
            speed = 0;
        }
        else {
            speed = 15;
        }
        building.position += Vector3.right * Time.deltaTime * Input.GetAxis("Mouse X") * speed * 10;
        building.position += Vector3.forward * Time.deltaTime * Input.GetAxis("Mouse Y") * speed * 10;

       
        Debug.Log(i+ "test" + test);

    }

    void click1()
    {
        i = true;
        test++;

    }
    void click2()
    {
        i = false;
        test++;
    }
   
}
