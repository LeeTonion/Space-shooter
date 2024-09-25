using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private GameObject shoot, tripleshoot, shields, hurt;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private int health = 3;
    [SerializeField] public bool _istripleshort,_isspeed,_ishealth,_player1,_player2;
    [SerializeField] private bool _isEnemyFire = false;
    [SerializeField] private AudioClip _clip,_clip2;
    [SerializeField] private int _score = 0;
    private AudioSource _audioSource;
    private Animator _animator;
    private UI_Manager UI;


    private SpawnManager spawnManager;
    private float _canfire = -1f;
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();                                
        UI = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        _audioSource = gameObject.GetComponent<AudioSource>();


        StartCoroutine(TripleShotDown());
    }
    void Update()
    {
        if (_player1)
        {
            Move1();

        if (Input.GetKeyDown(KeyCode.F) && Time.time > _canfire)
        {
            FireBullet();
        }
        }
        if (_player2)
        {
            Move2();

            if (Input.GetKeyDown(KeyCode.L) && Time.time > _canfire)
            {
                FireBullet();
            }
        }

        if (_score == 500)
        {

            _isEnemyFire = true;

        }
        if (_isEnemyFire)
        {
            if(spawnManager != null) {spawnManager.isEnemyFire(); }
            AddScore(10);
            _isEnemyFire = false;
        }

    }

    private void Move2()
    {


        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector2(0, 1) * _speed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector2(0, -1) * _speed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-1, 0) * _speed * Time.deltaTime);
            _animator.SetBool("movingLeft", true);
            _animator.SetBool("isIdle", false);

        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _animator.SetBool("movingLeft", false);
            _animator.SetBool("isIdle", true);
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(1, 0) * _speed * Time.deltaTime);
            _animator.SetBool("movingRight", true);
            _animator.SetBool("isIdle", false);

        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _animator.SetBool("movingRight", false);
            _animator.SetBool("isIdle", true);
        }
        if (this.transform.position.x >= 24)
        {
            this.transform.position = new Vector3(-24, transform.position.y, 0);
        }
        else if (this.transform.position.x <= -24)
        {
            this.transform.position = new Vector3(24, transform.position.y, 0);
        }
        this.transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -11, 11), 0);
    }


    private void Move1()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector2(0, 1) * _speed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector2(0, -1) * _speed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(-1, 0) * _speed * Time.deltaTime);
            _animator.SetBool("movingLeft", true); 
            _animator.SetBool("isIdle", false); 

        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetBool("movingLeft", false);
            _animator.SetBool("isIdle", true);
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(1, 0) * _speed * Time.deltaTime);
            _animator.SetBool("movingRight", true);
            _animator.SetBool("isIdle", false);

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool("movingRight", false);
            _animator.SetBool("isIdle", true);
        }
        if (this.transform.position.x >= 24)
        {
            this.transform.position = new Vector3(-24, transform.position.y, 0);
        }
        else if (this.transform.position.x <= -24)
        {
            this.transform.position = new Vector3(24, transform.position.y, 0);
        }
        this.transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -11, 11), 0);

    }

    void FireBullet()
    {
        _canfire = Time.time + _fireRate;
        if (_istripleshort)
        {
            Instantiate(tripleshoot, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(shoot, transform.position + new Vector3(0, 2.5f, 0), Quaternion.identity);
        }
        if (_audioSource != null)
        {
            _audioSource.clip = _clip;
            _audioSource.Play();
        }
        
    }
    public void Takedamage()
    {
     
            if (shields.activeSelf)                      
            {
                shields.SetActive(false);
                return;
            }
            health--;
            Instantiate(hurt, transform.position, Quaternion.identity);
        if (_player1) {UI.UpdateLive1(health); }
        if (_player2) { UI.UpdateLive2(health); }
            
            if (health == 0 )
            {
                Destroy(this.gameObject);

            }
        
    }
   
    public void Triple_shoot()
    {
        _istripleshort = true;
        StartCoroutine(TripleShotDown());
    }
    IEnumerator TripleShotDown()
    {
        yield return new WaitForSeconds(8.0f);
        _istripleshort = false;
    }
    public void Speed()
    {
        _speed += 5f;
        StartCoroutine(SpeedDown());
    }
    IEnumerator SpeedDown()
    {
        yield return new WaitForSeconds(5.0f);
        _speed -= 5f;
    }
    public void Sheilds()
    {
        shields.SetActive(true);
        StartCoroutine(SheildsDown());
    }
    IEnumerator SheildsDown()
    {
        yield return new WaitForSeconds(10.0f);
        shields.SetActive(false);
    }
    public void AddScore(int point)
    {

        _score += point;

        UI.UpdateScore(_score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletEnemy"))
        {
            
            Takedamage(); 

            if (_audioSource != null  && gameObject != null)
            {
                _audioSource.clip = _clip2;
                _audioSource.Play();
            }
            
        }
    }
}

