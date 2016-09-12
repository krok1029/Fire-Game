using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour
{
    public GameObject fire;
    ParticleSystem waterEffect;

    void Awake()
    {
      //  fire = GameObject.Find("Fire");
        waterEffect = this.GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter(Collider onfire)
    {
        if (onfire.gameObject.tag == "Fire")
        {
            //water.SetActive (true);
            waterEffect.Play();

            Destroy(onfire.gameObject);

        }
    }

    void OnTriggerExit(Collider onfire)
    {
        if (onfire.gameObject.tag == "Fire")
        {

        }
    }


}