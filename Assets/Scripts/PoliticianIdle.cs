 using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PoliticianIdle : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    [SerializeField]
    private Vector2 force = new Vector2(1,0);

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        //_rigidbody.DOMove(new Vector2(2,0),5).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);

        InvokeRepeating("AddForce", 0, 0.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }


    void AddForce()
    {

        force *= -1;
        //_rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(force);

    }
}
