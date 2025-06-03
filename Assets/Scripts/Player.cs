using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 6f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;

    [Header("Swimming Settings")]
    public float swimSpeed = 3f;
    public float swimUpSpeed = 2f;
    private bool isInWater = false;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    [Header("Stats")]
    public float wood;
    public float health = 20;
    public float hunger = 10;
    public Text healthText;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Update health UI
        float roundedHealth = Mathf.Round(health);
        healthText.text = roundedHealth.ToString();

        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Keeps grounded player "stuck" to ground
        }

        // Movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (isInWater)
        {
            // Swimming movement
            move.y = 0;
            if (Input.GetKey(KeyCode.Space))
            {
                move.y = swimUpSpeed;
            }

            controller.Move(move * swimSpeed * Time.deltaTime);

            // Reset gravity effects while swimming
            velocity = Vector3.zero;
        }
        else
        {
            // Ground / Air movement
            controller.Move(move * speed * Time.deltaTime);

            // Jumping
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            // Apply gravity over time
            velocity.y += gravity * Time.deltaTime;

            // Apply vertical movement from gravity or jump
            controller.Move(velocity * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = true;
            velocity = Vector3.zero; // reset vertical velocity when entering water
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = false;
            // Don't reset velocity here — gravity should resume naturally
        }
    }
}
