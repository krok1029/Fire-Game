using UnityEngine;
using System.Collections;

public class chooseObject : MonoBehaviour {
    Camera cam;
    void Start()
    {
        cam = this.GetComponent<Camera>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TarRaycast();
        }
    }
    Vector3 mp;//鼠标位置
    Transform targetTransform;//点选的物体
    public LayerMask targetingLayerMask;//指定射线能检测到的Layermask层
    private float targetingRayLength = Mathf.Infinity;//射线的长度


    public void TarRaycast()
    {
        targetingLayerMask.value = 1 << 10; //打開第10層
        mp = Input.mousePosition;
        targetTransform = null;
        if (cam != null)
        {
            RaycastHit hitInfo;
            Ray ray = cam.ScreenPointToRay(new Vector3(mp.x, mp.y, 0f));
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, targetingRayLength, targetingLayerMask.value))
            {
                targetTransform = hitInfo.collider.transform;
            }
        }
        //得到被点选的物体后，对其进行操作~
        if (targetTransform != null)
        {
            Debug.Log(targetingLayerMask.value);
            Debug.Log(targetTransform.name);

        }
    }
}

