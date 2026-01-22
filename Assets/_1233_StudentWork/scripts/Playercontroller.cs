using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;

    [SerializeField] private float smoothTime = 0.05f;
    private float _currentVelocity;

    [SerializeField] private float speed = 5.0f; // Set a default speed value
    private float _velocity;

    [SerializeField] private float jumpPower = 5.0f; // Declare jump power
    [SerializeField] private float _gravity = -9.81f;
    private float gravityMultiplier = 2.0f;

    [SerializeField]

    private Animator _animator;

    private static readonly int Speed =
        Animator.StringToHash("Speed");


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
        AnimationParameters();


    }

    private void ApplyGravity()
    {
        if (_characterController.isGrounded && _velocity < 0.0f)
        {
            _velocity = -1.0f; // Small downward force to keep grounded
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime; // Apply gravity
        }

        _direction.y = _velocity;
    }

    private void ApplyRotation()
    {
        if (_input != Vector2.zero)
        {
            var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        }
    }

    private void ApplyMovement()
    {
        _characterController.Move(_direction * speed * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started || !IsGrounded()) return;

        _velocity += jumpPower; // Jump
    }

    private bool IsGrounded() => _characterController.isGrounded;

    private void AnimationParameters()

    {
        if (_animator != null)
        
        { 
            _animator.SetFloat(

            Speed, _input.sqrMagnitude);
        
        }
       
    }



}