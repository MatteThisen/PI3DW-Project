using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float gravity = -1f;
    public int playerHealth = 100;

    private CharacterController controller;
    private Transform cameraTransform;
    private Vector3 velocity;
    [SerializeField] private Animator animator;
    public float jumpHeight = 2f;
    private bool groundedPlayer;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {

        // Horizontal Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction relative to camera's global y-rotation
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Quaternion rotation = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0f);
        direction = rotation * direction;

        velocity.y += gravity * Time.deltaTime;

        // Move the player
        controller.Move((direction * speed + velocity) * Time.deltaTime);

        // Update the animator
        if (direction.magnitude > 0.1f)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        playerHealth -= damage;
        Debug.Log("Player Health: " + playerHealth);
        if (playerHealth <= 0)
        {
            animator.enabled = false;
            controller.enabled = false;
            Debug.Log("Player is dead!");
        }
    }

}