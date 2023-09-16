using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float MovimientoHorizontal; 
    public float MovimientoVertical;
    private Vector3 playerInput;

    public CharacterController player;
    
    public float playerSpeed;
    public float gravity = 9.8f;
    public float fallVelocity;
    public float jumpForce;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer;

    public bool isOnSlope = false;
    private Vector3 hitNormal;
    public float slideVelocity;
    public float slopeForceDown;
//
    private bool isCrouching = false;

    void Start()
    {   
        
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;

        player = GetComponent<CharacterController>();

        
    }

    void Update()
    {
        //Movimiento
        MovimientoHorizontal = Input.GetAxis("Horizontal");
        MovimientoVertical = Input.GetAxis("Vertical");

        playerInput = new Vector3(MovimientoHorizontal, 0, MovimientoVertical);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        movePlayer = movePlayer * playerSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();

        PlayerSkills();

        player.Move(movePlayer * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCrouch();
        }

    }

    //Camara
    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    //Gravedad
    void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }

        SlideDown();
    }

    //Habilidades
    private bool hasJumped = false;

    void PlayerSkills()
{
    if (player.isGrounded)
    {
        // Reiniciar el estado de salto si el jugador está en el suelo
        hasJumped = false;

        if (Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
            hasJumped = true; // Marcar que el jugador ha saltado
        }
    }
    else if (!player.isGrounded && !hasJumped && Input.GetButtonDown("Jump"))
    {
        // Saltar solo si no se ha saltado previamente y no está en el suelo
        fallVelocity = jumpForce;
        movePlayer.y = fallVelocity;
        hasJumped = true;
    }
}
    
    public void SlideDown(){ //si esta o no en una rampa

        isOnSlope = Vector3.Angle(Vector3.up, hitNormal) >= player.slopeLimit;

        if (isOnSlope){

            movePlayer.x += ((1f - hitNormal.y) * hitNormal.x) * slideVelocity;
            movePlayer.z += ((1f - hitNormal.y) * hitNormal.z) * slideVelocity;

            movePlayer.y += slopeForceDown;
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit){

        hitNormal = hit.normal;

    }

    void ToggleCrouch()
{
    if (isCrouching)
    {
        // Levantar al jugador
        player.height = 2f; // Ajusta la altura del jugador como prefieras
        playerSpeed *= 2;   // Ajusta la velocidad de movimiento como prefieras
        isCrouching = false;
    }
    else
    {
        // Agachar al jugador
        player.height = 1f; // Ajusta la altura agachada como prefieras
        playerSpeed /= 2;   // Ajusta la velocidad de movimiento agachada como prefieras
        isCrouching = true;
    }
}


}
