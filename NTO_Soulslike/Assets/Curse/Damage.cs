using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
   
    public static bool gameOver;
    public Transform plrPos;
    public static bool prok;
    private float CorXP;
    private float CorXM;
    private float CorYP;
    private float CorYM;
    void Start()
    {
        
        
        prok = false;
        CorXP = plrPos.position.x + 3f;
        CorXM = plrPos.position.x - 3f;
        CorYP = plrPos.position.y + 3f;
        CorYM = plrPos.position.y - 3f;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameOver)
        {
            SceneManager.LoadScene("Level");
        }
        if (CorXM < plrPos.position.x && CorXP > plrPos.position.x &&
        CorYM < plrPos.position.y && CorYP > plrPos.position.y)
        {

            prok = true;
        }
      
    }
    public static void damage(int damageCount, ManaHandler mana)
    {

        mana.Mana -= damageCount;
        
    }
    private IEnumerator Curse(ManaHandler mana)
    {
        while (true)
        {
            yield return null;
            
        }
    }
}