using UnityEngine;

public class FlippyBoxMovingBlock : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] float _moveSpeed = 2f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector2 movement = Vector2.left * _moveSpeed * Time.deltaTime;
        _rigidbody.position += movement;
        if (_rigidbody.position.x < -15f)
        {
            _rigidbody.position += new Vector2(30f, 0);
        }
    }
}
