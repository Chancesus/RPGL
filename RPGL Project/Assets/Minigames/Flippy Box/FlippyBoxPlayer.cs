using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippyBoxPlayer : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    [SerializeField] Vector2 _jumpVelocity = Vector2.up;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _rigidbody.velocity = _jumpVelocity;
        }
    }
}
