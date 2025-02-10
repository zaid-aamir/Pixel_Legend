using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLige : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Transform movement;

    [SerializeField] private AudioSource deathSoundEffect;

    private bool fellOff;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<Transform>();

        fellOff = false;
    }

    private void Update()
    {
        if (movement.position.y < -32)
        {
            if (!fellOff)
            {
                fellOff = true;

                Die();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
