using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Animator characterAnimator;

    bool canMove = true;

    float horizontalInput;
    float verticalInput;

    Vector2 movement;

    Rigidbody2D rgbody;

    // Start is called before the first frame update
    void Start()
    {
        rgbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        if (canMove) PlayerMovement();
    }

    void GetPlayerInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void PlayerMovement()
    {
        characterAnimator.SetFloat("Horizontal", horizontalInput);
        characterAnimator.SetFloat("Vertical", verticalInput);

        movement.x = horizontalInput;
        movement.y = verticalInput;

        rgbody.velocity = movement * speed;
    }
}
