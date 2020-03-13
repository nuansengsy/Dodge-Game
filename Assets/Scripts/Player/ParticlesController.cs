using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    private ParticleSystem ps;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.enableEmission = false;
        EventsMananger.GameStart += TurnOnParticles;
        EventsMananger.GameOver += TurnOffParticles;
    }

    void TurnOnParticles()
    {
        ps.enableEmission = true;
        EventsMananger.GameStart -= TurnOnParticles;
    }

    void TurnOffParticles()
    {
        ps.enableEmission = false;
        EventsMananger.GameOver -= TurnOffParticles;
    }
}
