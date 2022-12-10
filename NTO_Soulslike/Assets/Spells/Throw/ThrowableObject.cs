using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public float speed;
    public float DespawnTime;
    
    
    public IEnumerator Throwing(Vector3 lastPosition)
    {
        while((gameObject.transform.position - lastPosition).magnitude > 1)
        {
            yield return null;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,lastPosition,speed * Time.deltaTime);
        }
        gameObject.transform.position = lastPosition;
        yield return new WaitForSeconds(DespawnTime);
        Destroy(gameObject);
        yield break;

    }
}
