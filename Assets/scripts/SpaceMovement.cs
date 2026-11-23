using UnityEngine;
using UnityEngine.InputSystem;
public class SpaceMovement : MonoBehaviour
{ 
    [SerializeField] private float thrustPower = 10f;
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
