using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource soundEffects;

    public AudioClip background;
    public AudioClip death;
    public AudioClip jump;
    public AudioClip hurt;
    public AudioClip attack;
    public AudioClip cristalHealth;
    public AudioClip incrementDamage;
    public AudioClip coin;
    public AudioClip enemyHurt;
    public AudioClip enemyDeath;

    private void Awake()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        soundEffects.PlayOneShot(clip);
    }

}
