using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfire : MonoBehaviour
{
    public Player player1;
    public Player player2;
    [SerializeField] private float _speed ;
    private Animator animator;
    [SerializeField] private AudioClip _clip;
    private AudioSource _audioSource;
    [SerializeField] private GameObject Bullet;
    private bool _addscore = true;
    void Start()
    {
        GameObject gameplayer1 = GameObject.Find("Player 1");
        if (gameplayer1 != null) { player1 = gameplayer1.GetComponent<Player>(); }
        GameObject gameplayer2 = GameObject.Find("Player 2");
        if (gameplayer2 != null) { player2 = gameplayer2.GetComponent<Player>(); }
        animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource != null)
        {
            _audioSource.clip = _clip;

        }
        StartCoroutine(Timespawnbullet());

    }

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime * Random.Range(3, 10));

        if (transform.position.y < -11)
        {
            this.transform.position = new Vector3(Random.Range(-24, 24), 13, 0);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") && _addscore)
        {
            if (player1 != null)
            {
                player1.AddScore(10);
                _addscore = false;
            }
            if (player2 != null)
            {
                player2.AddScore(10);
                _addscore = false;
            }
            Destroy(collision.gameObject);
            animator.SetTrigger("destroy");
            Destroy(gameObject, 1);
            _audioSource.Play();
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
    IEnumerator Timespawnbullet()
    {
        while (true)
        {
            Instantiate(Bullet, transform.position - new Vector3(0, 3, 0), Quaternion.identity);
            _speed = 0.5f;
            yield return new WaitForSeconds(3.5f);
        }
    }
}
