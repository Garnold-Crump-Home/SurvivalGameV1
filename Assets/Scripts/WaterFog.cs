using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFog : MonoBehaviour
{
    public GameObject Player;
    public bool Fog;

    // Start is called before the first frame update
    private void Start()
    {
        Invoke("Stop", 2f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Player) { RenderSettings.fog = true; }
        Debug.Log("Player has Enterd");
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (Player) { RenderSettings.fog = false; }
    }
    private void Stop()
    {
        RenderSettings.fog = false;
    }
}
