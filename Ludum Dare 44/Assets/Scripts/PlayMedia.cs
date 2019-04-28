using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMedia : MonoBehaviour {

    ParticleSystem particleSystem;
    Animation animation;
    AudioSource audioSource;

    public void playParticleEffect()
    {
        particleSystem.Play();
    }

    public IEnumerator playAnimationCoroutine(string animationName)
    {
        animation.Play();
        while (animation.IsPlaying(animationName))
        {
            yield return null;
        }
        playParticleEffect();
    }

    public void playAnimation(string animationName)
    {
        StartCoroutine(playAnimationCoroutine(animationName));
    }

    public void playAudio()
    {
        audioSource.Play();
    }

	// Use this for initialization
	void Start () {
        particleSystem = GetComponent<ParticleSystem>();
        animation = GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();
	}
}
