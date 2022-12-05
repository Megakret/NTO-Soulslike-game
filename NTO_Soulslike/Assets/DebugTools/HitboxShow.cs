using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxShow : MonoBehaviour
{
   

    public GameObject CubeHitbox;
    public GameObject SphereHitbox;
    
    public void BoxShow(Vector3 pos, Vector3 size, Quaternion rotation)
    {
       
        
            GameObject cube = Instantiate<GameObject>(CubeHitbox, pos, rotation,null);
            cube.transform.localScale = size;
            StartCoroutine(CdDestroy(cube));
        

    }
    public void SphereShow(Vector3 pos, float radius)
    {
        
        
            GameObject sphere = Instantiate<GameObject>(SphereHitbox, pos, new Quaternion(0, 0, 0, 0), null);
            sphere.transform.localScale = new Vector3(radius * 2, radius * 2, radius * 2);
            StartCoroutine(CdDestroy(sphere));

    }
    private IEnumerator CdDestroy(GameObject obj)
    {
        yield return new WaitForSeconds(1);
        
        Destroy(obj);
        yield break;
    }


}

