using UnityEngine;
using UnityEngine.InputSystem;
public class Playercontroller : MonoBehaviour
{

    private Vector2 _input;
    public void Move(InputAction.CallbackContext context)
    {

        _input = context.ReadValue<Vector2>();
        Debug.Log(_input);
        









    







}
}
