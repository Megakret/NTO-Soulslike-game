using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interactable : MonoCache
{
    public GameObject canvas;
    public void Near()
    {
        canvas.SetActive(true);
    }
    public void Far()
    {
        canvas.SetActive(false);
    }
    public virtual void Interacting(GameObject plr)
    {
        Debug.Log("Interact");
    }
    public override void OnTick()
    {
        canvas.transform.LookAt(Camera.main.transform);
    }
}
