using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoCache
{
    public CharacterController controller;
    public float speed;
    public float TurnSmooth;
    float TurnSmoothVel;
    private Transform CameraPos;
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
            float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + CameraPos.eulerAngles.y;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref TurnSmoothVel,TurnSmooth);
            Vector3 movDir = Quaternion.Euler(0f, Angle, 0f) * Vector3.forward;
            transform.rotation = Quaternion.Euler(0f, Angle, 0);
            controller.Move(movDir.normalized * speed * Time.deltaTime);
        }

    }
}
