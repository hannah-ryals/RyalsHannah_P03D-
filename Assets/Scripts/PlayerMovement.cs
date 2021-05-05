using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float sprintSpeed = 2f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float health = 3;
    [SerializeField] GameObject _hitOne = null;
    [SerializeField] GameObject _hitTwo = null;
    [SerializeField] GameObject _hitThree = null;
    [SerializeField] GameObject _GameOverText = null;
    [SerializeField] AudioSource feedbackAudioLose;
    [SerializeField] AudioSource feedbackAudioWin;
    [SerializeField] AudioSource feedbackAudioHurt;
    [SerializeField] AudioSource end;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * speed * Time.deltaTime * sprintSpeed);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void Health()
    {
        Debug.Log("Player lost a hit point");
        health -= 1;
        if (health == 2)
        {
            _hitOne.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
            feedbackAudioHurt.Play();
        }
        if (health == 1)
        {
            _hitTwo.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
            feedbackAudioHurt.Play();
        }
        if (health <= 0)
        {
            feedbackAudioHurt.Play();
            Kill();
            _hitThree.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
            _GameOverText.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void Kill()
    {
        end.Play();
        Debug.Log("Player was killed!");
        speed = 0f;
        sprintSpeed = 0f;
        jumpHeight = 0f;
        feedbackAudioLose.Play();
    }

}
