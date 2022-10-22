using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]

public class Particlecollsion : MonoBehaviour
{
    
    public GameObject Particle;
    
    private Raincontrol control;
    

    private void Awake()
    {
        control = new Raincontrol();
    }
    private void OnEnable()
    {
        control.Enable();
    }

    private void OnDisable()
    {
        control.Disable();
    }

    // Start is called before the first frame update
    [Obsolete]
    void Start()
    {
       // Particle.GetComponent<ParticleSystem>().enableEmission = true;
        Particle.GetComponent<ParticleSystem>().emissionRate = 100;

        control.Particle.Effect.performed += _ => ParticleEffect();

    




        
    }



    // Update is called once per frame
    void Update()
    {

    }



    [Obsolete]
    private void ParticleEffect()
    {
        // Particle.GetComponent<ParticleSystem>().enableEmission =false;
       Particle.GetComponent<ParticleSystem>().emissionRate = 1000;
      
    }
}
