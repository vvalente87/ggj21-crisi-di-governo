using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 1f; 
    private Rigidbody2D _rb2d;
    Vector2 movement;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();  
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        _rb2d.MovePosition(_rb2d.position + movement * speed* Time.fixedDeltaTime);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
}