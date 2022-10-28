using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(ParticleSystem))]

public class Particlecollsion : MonoBehaviour
{
    
    public GameObject Particle;

    public Color color;
    
    private Raincontrol control;

    private ParticleSystem ps;

    Vector3 pos;
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

        ps = GetComponent<ParticleSystem>();
        pos = transform.position;
        // Particle.GetComponent<ParticleSystem>().enableEmission = true;
        Particle.GetComponent<ParticleSystem>().emissionRate = 100;


        control.Particle.Effect.performed += _ => ParticleEffect();


        var main = ps.main;

       


    }



    // Update is called once per frame
    void Update()
    {
      /*  if (ps == null)
        {
            enabled = false;
            return;
        }

        Vector3 newPos = pos;
        newPos.x = Mathf.Sin(Time.timeSinceLevelLoad) * 3f;
        transform.position = newPos;

        var main = ps.main;
        main.startColor = UnityEngine.Random.ColorHSV(0f, 1f, 0f, 1f, 0.5f, 1f, 1f, 1f);
      */
    }

        [Obsolete]
    private void ParticleEffect()
    {
        // Particle.GetComponent<ParticleSystem>().enableEmission =false;
       Particle.GetComponent<ParticleSystem>().emissionRate = 1000;
        Particle.GetComponent<ParticleSystem>().startSpeed = 30;
        ParticleSystem.MainModule main = ps.main;
        color = UnityEngine.Random.ColorHSV(0f, 1f, 0f, 1f, 0.5f, 1f, 1f, 1f);
        main.startColor = color;
    }
}
