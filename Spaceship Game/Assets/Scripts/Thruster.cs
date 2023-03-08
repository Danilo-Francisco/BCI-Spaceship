using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
[RequireComponent (typeof(Light))]
public class Thruster : MonoBehaviour
{
    /*TrailRenderer trailRenderer;*/
    Light thrusterLight;

    void Awake()
    {
        /*trailRenderer = GetComponent<TrailRenderer>();*/
        thrusterLight = GetComponent<Light>();  
    }

    void Start()
    {
        /*        trailRenderer.enabled = false;
                thrusterLight.enabled = false;*/

        thrusterLight.intensity = 0;
    }

/*    public void Activate(bool activate = true)
    {
        if(activate)
        {
            trailRenderer.enabled = true;
            thrusterLight.enabled = true;
            //turn on partical effects
            //turn on sound
            //etc
        }
        else
        {
            trailRenderer.enabled = false;
            thrusterLight.enabled = false;  
            //turn off anything associated with thrusting
        }
    }*/

    public void Intensity(float inten)
    {
        thrusterLight.intensity = inten * 2f;
    }
}
