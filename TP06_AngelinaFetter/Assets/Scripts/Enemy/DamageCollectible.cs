using UnityEngine;

public class DamageCollectible : MonoBehaviour
{
    [SerializeField] private float damageValue;
    [SerializeField] private float durationDamageValue;

    SoundManager soundManager;
     
    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            soundManager.PlaySFX(soundManager.coin);

            PlayerAttack playerAttack = collision.GetComponent<PlayerAttack>();

            if (playerAttack != null)
            {
                playerAttack.attackDamage += damageValue;
            }
            
            gameObject.SetActive(false);
        }
    }

}
