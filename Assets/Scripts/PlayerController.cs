using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float speed = 5f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private static readonly int Speed = Animator.StringToHash("Speed");

    private SpriteRenderer _spriteRenderer;

    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate() {
        if (GameState.Instance.CurrentState == GameState.State.Pause)
            return;


        Vector2 mousePositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var distance = mousePositionWorld - _rigidbody2D.position;
        if (distance.magnitude > 0.1f) {
            _animator.SetFloat(Speed, 1);
        }
        else {
            _animator.SetFloat(Speed, 0);
        }

        _spriteRenderer.flipX = distance.x < 0;

        _rigidbody2D.MovePosition(_rigidbody2D.position + distance * (speed * Time.deltaTime));
    }

    void Update() {
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