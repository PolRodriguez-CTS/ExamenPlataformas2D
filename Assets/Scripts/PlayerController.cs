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

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        //_moveInput = InputSystem.actions[]
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
