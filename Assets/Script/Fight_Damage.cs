using UnityEngine;
using System.Collections;

public class Fight_Damage : MonoBehaviour {
    public ParticleSystem fireEffect;
    int counter = 0;
    GameObject time;
    float time0;
    RaycastHit rayHit;
	void Start () {

	}
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        time = GameObject.Find("Main Camera");
        time0 = time.GetComponent<SelfSavingTimer>().time;

        if (Input.GetButtonDown("Fire1")&&time0!=0)
        {
            if(Physics.Raycast(ray,out rayHit))
            {
                counter++;
                Instantiate(fireEffect, rayHit.point, Quaternion.Euler(0, 0, 0));

                    fireEffect.Play();
                    fireEffect.Stop();

                if (rayHit.transform.tag == "Building")
                {
                    Destroy(rayHit.transform.gameObject);
                }
            }
        }
	}
}
