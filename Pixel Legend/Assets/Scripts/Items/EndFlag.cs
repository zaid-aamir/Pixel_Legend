using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioSource winningSoundEffect;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("touch", true);
            winningSoundEffect.Play();
            CompeleteLevel();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("touched", true);
    }

    private void CompeleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
