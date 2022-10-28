using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnCollision : MonoBehaviour
{
    public ParticleSystem part;
    public GameObject partExplode;
    public List<ParticleCollisionEvent> collisionEvents;
    public Particlecollsion particlecollsion;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;
        Debug.Log("ParticleCollided"+numCollisionEvents);
        while (i < numCollisionEvents)
        {
            if (rb)
            {
                Vector3 pos = collisionEvents[i].intersection;
                //Vector3 force = collisionEvents[i].velocity * 10;
                GameObject go = Instantiate(partExplode, pos, Quaternion.identity);
                //rb.AddForce(force);
                ParticleSystem ps = go.GetComponent<ParticleSystem>();
                //ps.emissionRate = 1000;
                //ps.startSpeed = 30;
                ParticleSystem.MainModule main = ps.main;
                main.startColor = particlecollsion.color;
                //= UnityEngine.Random.ColorHSV(0f, 1f, 0f, 1f, 0.5f, 1f, 1f, 1f);
                ps.GetComponent<ParticleSystemRenderer>().material.color = particlecollsion.color;
            }
            i++;
        }
    }
}