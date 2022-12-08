using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoCache
{
    private int hp;
    public int MaxHP;
    public Bar HealthBar;
    public GameObject PancakePrefab;
    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            if (value <= 0)
            {
                hp = 0;
                Dead();
            }
            else if (value <= MaxHP)
            {
                hp = value; // «десь можно прописать изменение шкалы здоровь€
                
            }
            else
            {
                hp = MaxHP;
            }
            HealthBar.ChangeSlider((double) hp/MaxHP);
            Debug.Log(value);    
        }
    }
    private void Awake()
    {
        hp = MaxHP;
    }
    public override void OnTick()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            HP -= 10;
        }
    }
    private void Dead()
    {
        GameObject pancakeChest = Instantiate(PancakePrefab,gameObject.transform.position,gameObject.transform.rotation,null);
        InteractableHeal pancakeBrain = pancakeChest.GetComponent<InteractableHeal>();
        Healing healing = gameObject.GetComponent<Healing>();
        ManaHandler mana = gameObject.GetComponent<ManaHandler>();
        mana.Mana = 0;
        pancakeBrain.PancakeCount = healing.HealCount;
        healing.HealCount = 0;
        HP = 100;
        gameObject.transform.position = new Vector3(26, 0, 1);
        


    }

}
