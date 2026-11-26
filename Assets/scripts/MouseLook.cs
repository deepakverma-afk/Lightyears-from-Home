using UnityEngine;
using UnityEngine.InputSystem;
public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private float mouseSensitivity = 100f;
    
    [SerializeField] private float smoothTime = 0.05f;
    private Vector2 currentMouseDelta;
    private Vector2 currentMouseDeltaVelocity;
    private float mouseX;
    private float mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        Vector2 targetMouseDelta = Mouse.current.delta.ReadValue();
        currentMouseDelta = Vector2.SmoothDamp(
            currentMouseDelta,
            targetMouseDelta,
            ref currentMouseDeltaVelocity,
            smoothTime
            );
        mouseX = currentMouseDelta.x * mouseSensitivity * Time.deltaTime;
        mouseY = currentMouseDelta.y * mouseSensitivity * Time.deltaTime;
    }
    void LateUpdate()
    {
        playerBody.Rotate(Vector3.up, mouseX, Space.Self);
        playerBody.Rotate(Vector3.right, -mouseY, Space.Self);
    }
}
