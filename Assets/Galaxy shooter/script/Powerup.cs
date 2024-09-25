using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private int PowerUpID;
    [SerializeField] private AudioClip _clip;
    private AudioSource _audioSource;
    void Start()
    { 
        _audioSource =gameObject.GetComponent<AudioSource>();
        if (_audioSource != null)
        {
            _audioSource.clip = _clip;

        }
    }
        
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -5, 0) * Time.deltaTime);
        if(transform.position.y <= -11)
        {
            Destroy(gameObject);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {   _audioSource.Play();
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                if(PowerUpID == 0)
                {
                    player.Triple_shoot();  
                    
                }
                else if(PowerUpID == 1) 
                {
                    player.Speed();
                    
                }
                else if(PowerUpID == 2)
                {
                    player.Sheilds();
                   
                }    
            }
        Destroy(gameObject, _clip.length);   
        }

    }
}
