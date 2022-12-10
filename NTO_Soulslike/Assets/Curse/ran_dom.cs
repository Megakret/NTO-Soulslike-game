using UnityEngine;
using System.Collections;
public class ran_dom : MonoBehaviour
{
    
    public Transform center; // координаты центра
    public Vector3 size; // координаты в которых будут появляться объекты
    
    public GameObject ClearCurseObj;
    
    
    public void Spawn() {
        size = gameObject.transform.localScale;
        Vector3 pos2 = center.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        GameObject ClearCurse = Instantiate(ClearCurseObj, pos2, Quaternion.identity);
        ClearCurse.transform.SetParent(gameObject.transform);
    } 
    
}