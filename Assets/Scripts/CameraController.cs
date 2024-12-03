using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 100f;

    private Transform playerTransform;
    [SerializeField]private Transform CameraTransform;

    void Start()
    {
        playerTransform = GetComponentInParent<CharacterController>().transform;
    }

    void Update()
    {
        // Camera Rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        playerTransform.Rotate(Vector3.up * mouseX);

        // Calculate the desired rotation
        Vector3 forward = transform.forward;
        Quaternion rotation = Quaternion.LookRotation(forward + Vector3.up * mouseY);


        // Apply the rotation, ensuring smooth transition
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);

        // Place camera at camera transform
        transform.position = CameraTransform.position;
    }
}