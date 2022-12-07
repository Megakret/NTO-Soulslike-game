using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoCache
{
    public CharacterController controller;
    [Header("SpeedStats")]
    public float WalkSpeed;
    private float speed;
    public float runSpeed;
    public float FromWalkToRunTime;
    public float ChangingSpeed;
    [Header("Turning")]
    public float TurnSmooth;
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
        
        float XVel = Input.GetAxisRaw("Horizontal");
        float ZVel = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(XVel, 0, ZVel).normalized;
        if(direction.magnitude >= 0.1f)
        {
            currentTick += Time.deltaTime;
            float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + CameraPos.eulerAngles.y;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref TurnSmoothVel,TurnSmooth);
            Vector3 movDir = Quaternion.Euler(0f, Angle, 0f) * Vector3.forward;
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
    
    

}
