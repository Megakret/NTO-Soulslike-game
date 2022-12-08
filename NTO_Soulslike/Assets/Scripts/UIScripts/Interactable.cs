using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interactable : MonoBehaviour
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
    public virtual void Interacting()
    {
        Debug.Log("Interact");
    }
}
