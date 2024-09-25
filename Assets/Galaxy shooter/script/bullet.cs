using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int _speed ;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.Translate(new Vector3(0, 1,0) * _speed* Time.deltaTime) ;
        if (transform.position.y >= 12)
        {
            Destroy(gameObject);
        }
         
    }
}
