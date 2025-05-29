using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    public float timeBetweenEating;
    public Player player;
    public Image h1;
    public Image h2;
    public Image h3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenEating += Time.deltaTime;

        if(timeBetweenEating >= 90) {
            player.hunger = 10;
            h1.enabled = false;
            if(player.hunger == 10)
            {
                h2.enabled = false;
                player.hunger = 9;
            }
            if(player.hunger == 9) { h3.enabled = false; player.hunger = 8;}
            timeBetweenEating = 0;
        }
    }
}
