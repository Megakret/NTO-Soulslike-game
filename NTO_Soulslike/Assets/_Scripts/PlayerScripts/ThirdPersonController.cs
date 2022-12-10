using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoCache
{
    public PlayerStates playerStates;
    public CharacterController controller;
    public AnimatorScript animatorScript;
    [Header("SpeedStats")]
    public float WalkSpeed;
    private float speed;
    public float runSpeed;
    public float FromWalkToRunTime;
    public float ChangingSpeed;
    [Header("Turning")]
    public float TurnSmooth;
    //Направление движения игрока
    [HideInInspector]public Vector3 movDir;
    [Header("Gravity")]
    public float GravityValue = 10f;
    public Transform GroundCheck;
    public float GroundCheckRadius;
    public LayerMask Ground;

    private bool IsGrounded;
    private float fallSpeed = 12f;

    //Остальное
    
    float TurnSmoothVel;
    private Transform CameraPos;
    private float currentTick;

    private void Start()
    {
        
        CameraPos = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        
    }
    public override void OnTick()
    {
        GravityFall();
        animatorScript.RunAnimation(speed);
        float XVel = Input.GetAxisRaw("Horizontal");
        float ZVel = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(XVel, 0, ZVel).normalized;
        if(direction.magnitude >= 0.1f && (playerStates.currentState == PlayerStates.States.Idle || playerStates.currentState == PlayerStates.States.Attack))
        {
            if(playerStates.currentState == PlayerStates.States.Attack)
            {
                SlowDown();
            }
            currentTick += Time.deltaTime;
            float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + CameraPos.eulerAngles.y;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref TurnSmoothVel,TurnSmooth);
            movDir = Quaternion.Euler(0f, Angle, 0f) * Vector3.forward;
            transform.rotation = Quaternion.Euler(0f, Angle, 0);
            controller.Move(movDir.normalized * speed * Time.deltaTime);
            if(currentTick >= FromWalkToRunTime)
            {
                SpeedInc();
            }
            
        }
        else
        {
            SlowDown();
        }



        

    }
    private void SpeedInc()
    {
        speed = Mathf.Clamp(Mathf.SmoothDamp(speed, runSpeed, ref speed, ChangingSpeed), WalkSpeed, runSpeed);
        
    }
    public void SlowDown()
    {
        speed = WalkSpeed;
        currentTick = 0;
    }
    public void MaxSpeed()
    {
        speed = runSpeed;
        currentTick = 0;
    }
    private void GravityFall()
    {
        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundCheckRadius, Ground);
        if (IsGrounded)
        {
            fallSpeed = 2f;
        }
        else
        {
            fallSpeed += GravityValue * Time.deltaTime;
            
        }
        controller.Move(Vector3.up * -fallSpeed * Time.deltaTime);
        
    }
    
    
    

}
