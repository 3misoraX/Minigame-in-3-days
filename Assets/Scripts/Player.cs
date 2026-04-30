using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Variables
    public float speed = 6f;
    [SerializeField]private Transform cameraTransform;
    [SerializeField]private InputActionReference moveActions;
    [SerializeField] private InputActionReference JumpAction;
    private Vector2 movement;
    private CharacterController charControl;
    private bool isGrounded;
    private float verticalVelocity = 0f;
    public float jumpForce = 7f;
    public float gravity = -12f;
    public float iFallVelocity = -2f;
    //health related
    public int hp = 3;
    private bool canTakeDmg = true;

    void Awake()
    {
        //gets the character controller at the beginning
        charControl = GetComponent<CharacterController>();
    }

    //input detection, didnt understand why but i'm sure its for connecting it with the new input system easily
    private void OnEnable()
    {
        moveActions.action.performed += storeInput;
        moveActions.action.canceled += storeInput;
        JumpAction.action.performed += Jump;
    }

    private void OnDisable()
    {
        moveActions.action.performed -= storeInput;
        moveActions.action.canceled -= storeInput;
        JumpAction.action.performed -= Jump;
    }

    //detects the player input and stores it on a vector2
    private void storeInput(InputAction.CallbackContext call)
    {
        movement = call.ReadValue<Vector2>();
    }
    
    private void Jump(InputAction.CallbackContext call)
    {
        //player on the ground will jump
        if (isGrounded)
        {
            verticalVelocity = jumpForce;
        }
    }
    
    private void HandleGravity()
    {
        //basic code for gravity handling
        if(isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = iFallVelocity;
        }

        verticalVelocity += gravity * Time.deltaTime;
    }
   
    // Update is called once per frame
    void Update()
    {
        //killing the player
        if(hp <= 0)
        {
            //Player death
            this.gameObject.SetActive(false);
            //summoning the game over screen
        }

        //gravity
        isGrounded = charControl.isGrounded;
        HandleGravity();
        //movement method
        Move();
    }
    //Movement, makes the camera direction "forward" and moves the character according to where they are facing
    void Move()
    {
        var mover = cameraTransform.TransformDirection(new Vector3(movement.x, 0, movement.y)).normalized;
        var fMove = mover * speed;
        fMove.y = verticalVelocity;
        charControl.Move(fMove * Time.deltaTime);
    }

    public void TakeDmg()
    {
        //if player can take damage, they will do so and enter on iframes
        if (canTakeDmg)
        {
            hp--;
            canTakeDmg = false;
            //this coroutine is the IFrames
            StartCoroutine(Iframes());
        }
    }
    IEnumerator Iframes()
    {
        yield return new WaitForSeconds(2f);
        canTakeDmg = true;
    }
}
// :P