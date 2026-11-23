using UnityEngine;
using UnityEngine.InputSystem;
public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private float mouseSensitivity = 100f;
    private float xRotation = 0f;
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
        mouseX = Mouse.current.delta.x.ReadValue() * mouseSensitivity * Time.deltaTime;
        mouseY = Mouse.current.delta.y.ReadValue() * mouseSensitivity * Time.deltaTime;
    }
    void LateUpdate()
    {
        playerBody.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);
        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
