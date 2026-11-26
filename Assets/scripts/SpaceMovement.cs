using UnityEngine;
using UnityEngine.InputSystem;
public class SpaceMovement : MonoBehaviour
{ 
    [SerializeField] private float thrustPower = 10f;
    [SerializeField] private float brakeStrength = 5f;
    private float verticalInput;
    private Rigidbody rb;
    private PlayerControls controls;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new PlayerControls();
    }
    void OnEnable()
    {
        controls.Enable();
    }
    void OnDisable()
    {
        controls.Disable();
    }
    void FixedUpdate()
    
    {
        if (Keyboard.current.vKey.isPressed)
        {
            rb.AddForce(-rb.linearVelocity * brakeStrength, ForceMode.Acceleration);
        }
        Vector3 movement = new Vector3(
            moveInput.x,
            verticalInput,
            moveInput.y
        ).normalized;
        Vector3 worldMovement = transform.TransformDirection(movement);
        rb.AddForce(worldMovement * thrustPower);
    }
    void Update()
    {
        moveInput = controls.Player.Move.ReadValue<Vector2>();
        verticalInput = controls.Player.Vertical.ReadValue<float>();
    }
}
