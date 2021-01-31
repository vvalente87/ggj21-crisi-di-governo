using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 1f; 
    private Rigidbody2D _rb2d;
    Vector2 movement;
    Vector3 lastMouseCoordinate = Vector3.zero;
    private Animator _animator;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
      //  _rb2d.MovePosition(_rb2d.position + movement * speed* Time.fixedDeltaTime);
    }

    void Update()
    {
        if (GameState.Instance.CurrentState == GameState.State.Run)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = (pos);
        }
        //muovendolo col mouse non ha molto senso e non funziona benissimo, lo lascio se cambiamo idea
        /*
        Vector3 mouseDelta = Input.mousePosition - lastMouseCoordinate;
        if (mouseDelta.x < 0)
            _animator.SetFloat("Speed", 1);
        else
            _animator.SetFloat("Speed", 0);
        lastMouseCoordinate = Input.mousePosition;
        */
    }
}