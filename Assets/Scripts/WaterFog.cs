using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterFog : MonoBehaviour
{
    public GameObject Player;
    public Player playerScript;
    public bool Fog;
    public Text UnderWaterText;
    public float Percent = 100;
    public bool waterDrown;

    // Start is called before the first frame update
    private void Start()
    {
        Invoke("Stop", 2f);
        UnderWaterText.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Player) { RenderSettings.fog = true; }
        Debug.Log("Player has Enterd");
        UnderWaterText.enabled=true;
       
        waterDrown = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (Player) { RenderSettings.fog = false; }
        Percent = 100;
        UnderWaterText.enabled = false;
        waterDrown=false;
        
    }
    private void Stop()
    {
        RenderSettings.fog = false;
    }
    private void Update()
    {
       
        float roundedPercent = Mathf.Round(Percent);
        UnderWaterText.text = roundedPercent.ToString() + "%";
        if(waterDrown == true)
        {
            Percent -= Time.deltaTime * 5;
            if (Input.GetKey(KeyCode.Space))
            {

                Player.transform.Translate(0, 10 * Time.deltaTime, 0);
                playerScript.gravity = -10;
            }
        }
        
    }
}
