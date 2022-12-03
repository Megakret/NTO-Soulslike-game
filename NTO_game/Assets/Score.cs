using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public GameObject Player;
public int Score;
public class Score:
{
    
    void OnGUI()
    {
     GUI.Label(new Rect(10, 10, 100, 100), "Score: " Score);
    }
    void Start()
    {
        Player = GameObject.Find("Player");
    }
    void OnCollisionEnter(Collision variable)
    {
        if (variable.gameObject == Player)
        {
            Player.GetComponent<Score>().Score += 10;
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
}
