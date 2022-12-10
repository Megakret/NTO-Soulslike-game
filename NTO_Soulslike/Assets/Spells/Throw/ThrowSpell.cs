using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ThrowSpell : Spell
{
    [Header("Stats")]
    public float distance;
    public float Damage;
    [Header("ThrowableObject")]
    public GameObject ThrowObjectPrefab;

    private Transform CameraPos;
    // Получение LayerMask с врагом и землей
    private int GroundLayerIndex;
    private int EnemyLayerIndex;
    private int layerMask;
    private void OnEnable()
    {
        GroundLayerIndex = LayerMask.NameToLayer("Ground");
        EnemyLayerIndex = LayerMask.NameToLayer("Enemy");
        layerMask = (1 << GroundLayerIndex) | (1 << EnemyLayerIndex);
        
    }
    public override void Activate(ManaHandler manaHandler, HitboxShow hitboxShow, Transform plrCenter)
    {
        CameraPos = Camera.main.GetComponent<Transform>();
        plrCenter.parent.transform.rotation = Quaternion.Euler(0, CameraPos.eulerAngles.y, 0);
        RaycastHit hit;
        GameObject ThrowObject = Instantiate(ThrowObjectPrefab, plrCenter.position, plrCenter.rotation, null);
        ThrowableObject brain = ThrowObject.GetComponent<ThrowableObject>();
        
        if (Physics.Raycast(plrCenter.position,CameraPos.forward,out hit,distance,layerMask))
        {
            if(hit.collider.gameObject.tag == "Enemy")
            {
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                enemy.TakeDamage(Damage);
                
            }
            brain.StartCoroutine(brain.Throwing(hit.point));
        }
        else
        {

            brain.StartCoroutine(brain.Throwing(plrCenter.position + CameraPos.forward.normalized * distance));
            Debug.Log(plrCenter.position + CameraPos.forward.normalized * distance);
        }




    }
    
    
}
