using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
    public GameObject mesh;
    public void appear()
    {
        mesh.SetActive(true);
    }
    public void disappear()
    {
        mesh.SetActive(false);
    }
    }

