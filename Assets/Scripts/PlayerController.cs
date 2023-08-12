using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] float speed;
    [SerializeField] Animator characterAnimator;

    List<Animator> characterAnimators = new();

    bool canMove = true;

    float horizontalInput;
    float verticalInput;

    Vector2 movement;

    Rigidbody2D rgbody;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rgbody = GetComponent<Rigidbody2D>();

        characterAnimators.Add(characterAnimator);
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
        foreach (Animator anim in characterAnimators)
        {
            anim.SetFloat("Horizontal", horizontalInput);
            anim.SetFloat("Vertical", verticalInput);
        }

        movement.x = horizontalInput;
        movement.y = verticalInput;

        rgbody.velocity = movement * speed;
    }

    public void AddCharacterAnimator(Animator animator)
    {
        characterAnimators.Add(animator);
    }

    public void RemoveCharacterAnimator(Animator animator)
    {
        characterAnimators.Remove(animator);
    }
}
