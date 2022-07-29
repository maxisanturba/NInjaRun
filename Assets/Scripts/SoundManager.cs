using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpClip, dashClip, coinClip, powerupClip, hitClip, gameoverClip;
    static AudioSource audioSrc;

    private void Start()
    {
        jumpClip = Resources.Load<AudioClip>("Sounds/jump");
        dashClip = Resources.Load<AudioClip>("Sounds/dash");
        coinClip = Resources.Load<AudioClip>("Sounds/coin");
        powerupClip = Resources.Load<AudioClip>("Sounds/powerup");
        hitClip = Resources.Load<AudioClip>("Sounds/hit");
        gameoverClip = Resources.Load<AudioClip>("Sounds/gameover");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump": audioSrc.PlayOneShot(jumpClip); break;
            case "dash": audioSrc.PlayOneShot(dashClip); break;
            case "coin": audioSrc.PlayOneShot(coinClip); break;
            case "powerup": audioSrc.PlayOneShot(powerupClip); break;
            case "hit": audioSrc.PlayOneShot(hitClip); break;
            case "gameover": audioSrc.PlayOneShot(gameoverClip); break;
        }
    }
}
