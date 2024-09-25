using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Meteorite : MonoBehaviour
{
    private Player player1;
    private Player player2;
    private Animator animator;

    [SerializeField] private AudioClip _clip;
    private AudioSource _audioSource;
    private Collider2D Collider;
    
    void Start()
    {  
        animator = gameObject.GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource != null)
        {
            _audioSource.clip = _clip;

        }
        GameObject gameplayer1 = GameObject.Find("Player 1");
        if (gameplayer1 != null) { player1 = gameplayer1.GetComponent<Player>(); }
        GameObject gameplayer2 = GameObject.Find("Player 2");
        if (gameplayer2 != null) { player2 = gameplayer2.GetComponent<Player>(); }
    }
    void Update()
    {
        Vector3 vector = new Vector3(Random.Range(-1, -5), Random.Range(-1, -5), 0).normalized;
        transform.Rotate(0, 0, 0.1f);
        transform.Translate(vector * Time.deltaTime);

        if (transform.position.x > 35 || transform.position.x  < -35 || transform.position.y > 15 || transform.position.y < -15)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Bullet") || collision.CompareTag("enemy") )
        {
            Destroy(gameObject,1);
            Destroy(collision.gameObject);
            _audioSource.Play();
            if (animator != null)
            {
                animator.SetTrigger("destroy");
            }


        }
        if (collision.CompareTag("Player1"))
        {
            if (player1 != null)
            {
                if (player1._player1) { player1.Takedamage(); }

            }
            animator.SetTrigger("destroy");

            Destroy(gameObject, 1);
            _audioSource.Play();
        }
        if (collision.CompareTag("Player2"))
        {
            if (player2 != null)
            {
                if (player2._player2) { player2.Takedamage(); }

            }

            animator.SetTrigger("destroy");

            Destroy(gameObject, 1);
            _audioSource.Play();

        }

    }
}
