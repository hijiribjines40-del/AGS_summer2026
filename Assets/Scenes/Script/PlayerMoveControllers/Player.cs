using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float Speed = 5f;
    public float Power = 10f;

    public GameObject Coin;
    public Transform CreatePoint;

    private PlayerInputActions inputActions;

    private Vector2 moveInput;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        inputActions.Player.Move.performed += ctx =>
        {
            moveInput = ctx.ReadValue<Vector2>();
        };

        inputActions.Player.Move.canceled += ctx =>
        {
            moveInput = Vector2.zero;
        };

        inputActions.Player.Shoot.performed += Shoot;
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        Vector3 move =
            new Vector3(moveInput.x, 0, 0);

        transform.position +=
            move * Speed * Time.deltaTime;
    }

    private void Shoot(InputAction.CallbackContext ctx)
    {
        var create_coin =
            Instantiate(Coin,
            CreatePoint.position,
            Quaternion.identity);

        var rb = create_coin.GetComponent<Rigidbody>();

        rb.AddForce(
            CreatePoint.forward * Power,
            ForceMode.Impulse);
    }
}