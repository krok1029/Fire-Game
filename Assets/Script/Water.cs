using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour
{
    GameObject fire;
    GameObject water;
    public ParticleSystem waterEffect;

    void Awake()
    {
        fire = GameObject.Find("Fire");
        water = GameObject.Find("Water");
    }

    void OnTriggerEnter(Collider onfire)
    {
        if (onfire.gameObject.tag == "Fire")
        {
            //water.SetActive (true);
            Instantiate(waterEffect, new Vector3(3, 40, 3), Quaternion.Euler(85, 180, 0));
            waterEffect.Play();

            Destroy(onfire.gameObject);

        }
    }

    void OnTriggerExit(Collider onfire)
    {
        if (onfire.gameObject.tag == "Fire")
        {
            //water.SetActive (false);
            //waterEffect.Stop();

        }
    }


}

