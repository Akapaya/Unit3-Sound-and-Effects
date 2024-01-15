using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float JumpForce;
    public float MoveSpeed = 5;

    public ParticleSystem Explosion;
    public ParticleSystem DirtSplatter;

    public AudioSource AudioSource;
    public AudioClip ExplosionAudio;
    public AudioClip JumpAudio;

    #region Explosion Particle
    public void EnableExplosion()
    {
        Explosion.Play();
        AudioSource.clip = ExplosionAudio;
        AudioSource.Play();
    }
    #endregion

    #region DirtSplatter Particle
    public void EnableDirtSplatter()
    {
        DirtSplatter.Play();
    }

    public void DisableDirtSplatter()
    {
        DirtSplatter.Stop();
    }
    #endregion

    #region Jump
    public void EnableJump()
    {
        AudioSource.clip = JumpAudio;
        AudioSource.Play();
    }
    #endregion
}