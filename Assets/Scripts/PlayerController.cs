using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;                

    private Rigidbody2D _rb2d;       


    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();  
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");

        
        float moveVertical = Input.GetAxis("Vertical");

        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        
        _rb2d.AddForce(movement * speed);
    }

    void Update()
    {

        //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = (pos);

    }
}