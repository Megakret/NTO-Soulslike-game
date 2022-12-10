using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void RunAnimation(float speed)
    {
        animator.SetFloat("Speed",speed);
    }
    public void Parry()
    {
        Debug.Log("Parry");
        animator.SetTrigger("Parry");
    }
    public void ParrySuccess()
    {
        
        animator.ResetTrigger("Parry");
        animator.SetTrigger("ParrySuccess");
        
    }
    public void FirstAttack()
    {
        Debug.Log("First");
        animator.SetTrigger("FirstAttack");
    }
    public void SecondAttack()
    {
        Debug.Log("Second");
        animator.ResetTrigger("FirstAttack");
        animator.SetTrigger("SecondAttack");
    }
    public void FinalSwordAttack()
    {
        Debug.Log("Final Sword");
    }
    public void Dodge()
    {
        Debug.Log("Dodge");
    }

}
