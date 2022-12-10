using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{

    public ran_dom random;
    public Transform plrPos;
    public bool prok;
    public int DefaultValue;
    public Transform Center;
    public SphereCollider sphereCollider;
    
    void Start()
    {  
        prok = false;
    }

    // Update is called once per frame
    public void StartCurse(ManaHandler mana)
    {
        if (!prok)
        {
            prok = true;
            StartCoroutine(Curse(mana));
            random.Spawn();
            Debug.Log("Curse");
        }
            
            
        
    }
    
    /*void Update()
    {
        
        
        if (CorXM < plrPos.position.x && CorXP > plrPos.position.x &&
        CorYM < plrPos.position.y && CorYP > plrPos.position.y)
        {

            prok = true;
        }
      
    }*/
    public void damage(int damageCount, ManaHandler mana)
    {

        mana.Mana -= damageCount;
        
    }
    public void BreakCurse()
    {
        prok = false;
        Destroy(gameObject);
    }
    private IEnumerator Curse(ManaHandler mana)
    {
        while (prok)
        {
            yield return new WaitForSeconds(1f);
            Transform plrPos = mana.GetComponent<Transform>();
            int dmgValue = Mathf.RoundToInt(DefaultValue + (sphereCollider.radius - (plrPos.position - Center.position).magnitude));
            dmgValue = Mathf.Clamp(dmgValue,DefaultValue, mana.MaxMana);
            damage(dmgValue, mana);
            
        }
        yield break;
    }
}