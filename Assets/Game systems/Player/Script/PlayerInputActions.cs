using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputActions : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private PlayerInputs inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputs();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputActions.Gameplay.Move.performed += OnMovePerformed;
        inputActions.Gameplay.Move.canceled += OnMoveCanceled;
        inputActions.Gameplay.Enable();
    }

    private void OnDisable()
    {
        inputActions.Gameplay.Move.performed -= OnMovePerformed;
        inputActions.Gameplay.Move.canceled -= OnMoveCanceled;
        inputActions.Gameplay.Disable();
    }

    private void Update()
    {
        Move();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        moveDirection = Vector2.zero;
    }

    private void Move()
    {
        rb.MovePosition(rb.position + moveDirection * (moveSpeed * Time.fixedDeltaTime));
    }
}