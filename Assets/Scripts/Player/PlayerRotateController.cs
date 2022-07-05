using UnityEngine;

public class PlayerRotateController : MonoBehaviour
{
    [Header("Camera rotation")]
    [SerializeField] private float rotateSensetivity;

    [Header("References")]
    [SerializeField] private Camera characterCamera;

    private float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotateSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotateSensetivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        characterCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

    }
}
