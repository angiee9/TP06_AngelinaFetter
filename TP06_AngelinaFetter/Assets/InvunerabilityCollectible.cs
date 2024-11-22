using System.Collections;
using UnityEngine;

public class InvunerabilityCollectible : MonoBehaviour
{
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberFlashes;

    private SpriteRenderer spriteRenderer;
    SoundManager soundManager;

    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            soundManager.PlaySFX(soundManager.coin);
            StartCoroutine(Invunerability());
            gameObject.SetActive(false);
        }
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(9, 10, true);
        for (int i = 0; i < numberFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 5f);
            yield return new WaitForSeconds(iFramesDuration / (numberFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(9, 10, false);
    }
}
