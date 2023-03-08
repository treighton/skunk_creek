using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] float playerSpeed = 1f;
    Vector2 moveInput;
    Rigidbody2D playerRigidBody;
    Animator playerAnimator;
    CapsuleCollider2D playerCollider;
    LayerMask plantable;
    private PlayerControls playerControls;

    void Awake() {
        playerControls = new PlayerControls();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        playerControls.Player.Fire.performed += _ => {
            Debug.Log("WHY");
        };
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        plantable = LayerMask.GetMask("Plantable");
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Run();
    }

    void Move() 
    {
        moveInput = playerControls.Player.Move.ReadValue<Vector2>();
    }

    void Run() 
    {
        playerAnimator.SetFloat("WalkX", moveInput.x);
        playerAnimator.SetFloat("WalkY", moveInput.y);

        Vector2 playerVelocity = new Vector2(playerSpeed * moveInput.x, playerSpeed * moveInput.y);

        playerRigidBody.velocity = playerVelocity;
        
    }

    void ActionPlant() {
        Debug.Log("Planted!");
    }
}
