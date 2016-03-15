using UnityEngine;
using System.Collections;

public class MousePullPbject : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            //取得碰撞的材質UV位置，回傳0-1之間的float 值
            Debug.Log("X =" + hit.textureCoord2.x.ToString() + "Y =" + hit.textureCoord2.y.ToString());

        }
        
    }
}
    
