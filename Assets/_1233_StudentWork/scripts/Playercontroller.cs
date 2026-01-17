using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class Playercontroller : MonoBehaviour
{

    private Vector2 _input;
    private CharacterController _CharacterController;
    private Vector3 _direction;

    [SerializeField] private float speed;

    private void Awake()
    {
        _CharacterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _CharacterController.Move(_direction * speed * Time.deltaTime);
    }
    public void Move(InputAction.CallbackContext context)
    {



        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, y: 0.0f, z: _input.y);





    







     }
}
