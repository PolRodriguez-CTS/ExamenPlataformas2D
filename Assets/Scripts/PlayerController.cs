using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    //Inputs
    private InputAction _moveAction;
    private Vector2 _moveInput;

    private InputAction _jumpAction;

    //Parámetros

    [SerializeField] private int _playerSpeed = 5;
    [SerializeField] private int _jumpForce = 2;

    //Sensor
    [SerializeField] private Transform _sensorPosition;
    [SerializeField] private Vector2 _sensorSize = new Vector2(0.5f, 0.5f);

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _moveAction = InputSystem.actions["Move"];
        _jumpAction = InputSystem.actions["Jump"];
    }

    void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();

        Movement();

        _animator.SetBool("isJumping", !IsGrounded());

        if(_jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        _rigidbody.linearVelocity = new Vector2(_moveInput.x * _playerSpeed, _rigidbody.linearVelocityY);
    }

    void Movement()
    {
        if (_moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("isRunning", true);
        }
        else if (_moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }

    void Jump()
    {
        _rigidbody.AddForce(transform.up * Mathf.Sqrt(_jumpForce * -2 * Physics2D.gravity.y), ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        Collider2D[] sensor = Physics2D.OverlapBoxAll(_sensorPosition.position, _sensorSize, 0);
        foreach (Collider2D collision in sensor)
        {
            if (collision.gameObject.layer == 3)
            {
                return true;
            }
        }
        return false;
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_sensorPosition.position, _sensorSize);
    }
}
