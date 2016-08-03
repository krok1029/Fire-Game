using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fight_Damage : MonoBehaviour {
    public ParticleSystem fireEffect;
    int fireCounter = 0;
    GameObject time;
    float time0;
    RaycastHit rayHit;
    GameObject getLevel;
    int nowLevel;
    int fireTimes;
    public Text fireTimesLeft;
    public Button backbutton;
    public ParticleSystem explorsion;

    void Start () {
        getLevel = GameObject.Find("SceneManager");
        nowLevel = getLevel.GetComponent<Scenemanager>().nowLevel;
        switch (nowLevel) {
            case 1:
                fireTimes = 5000;
                break;
            case 2:
                fireTimes = 100;
                break;
            case 3:
                fireTimes = 150;
                break;
            default:
                fireTimes = 150;
                break;
        }
	}
    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        time = GameObject.Find("Main Camera");
        time0 = time.GetComponent<SelfSavingTimer>().time;

        if (Input.GetButtonDown("Fire1") && time0 != 0 && fireTimes > fireCounter && Physics.Raycast(ray, out rayHit))
        {
                fireCounter++;
                Instantiate(fireEffect, rayHit.point, Quaternion.Euler(0, 0, 0));
                fireEffect.Play();
                fireEffect.Stop();
                if (rayHit.transform.tag == "Building")
                    {
                        Object_Health objectHealth = rayHit.collider.GetComponent<Object_Health>();
                        if (objectHealth != null)
                        {
                            objectHealth.ObjectHealth -= 30;
                            if (objectHealth.ObjectHealth <= 0)
                            {
                            Instantiate(explorsion, rayHit.point, Quaternion.Euler(0, 0, 0));
                            objectHealth.ObjectHealth = 0;
                            rayHit.transform.position=new Vector3 (200,200,200);
                            }
                        }
                    }
                
            else if (rayHit.transform.tag == "Man")
            {
 
                    Object_Health objectHealth = rayHit.collider.GetComponent<Object_Health>();
                    if (objectHealth != null)
                    {
                        objectHealth.ObjectHealth -= 20;
                        if (objectHealth.ObjectHealth <= 0)
                        {
                            objectHealth.ObjectHealth = 0;
                            rayHit.transform.position = new Vector3(200, 200, 200);
                        }
                    }
            }
            
        }
        if (!backbutton.IsActive())
        {
            int fireleft = fireTimes - fireCounter;
            fireTimesLeft.text = "Fire Times:" + fireleft.ToString();
        } 
        
	}
}
