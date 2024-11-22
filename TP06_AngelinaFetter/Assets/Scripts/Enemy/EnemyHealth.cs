using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health;

    private Animator animator;
    SoundManager soundManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Death();
        }
        else if (health > 0)
        {
            soundManager.PlaySFX(soundManager.enemyHurt);
            animator.SetTrigger("hurt");
        }
    }

    private void Death()
    {
        
           soundManager.PlaySFX(soundManager.enemyDeath);
           animator.SetTrigger("die");
           gameObject.SetActive(false);


    }
}
