using UnityEngine;
using System.Collections;
public class ran_dom :
{
    public Vector3 center; // координаты центра
    public Vector3 size; // координаты в которых будут появляться объекты
    public GameObject kub; // наш куб
    public GameObject sphere;
    Transform myItem = (Instantiate(Resources.Load("cube")) as kub).transform;
    Transform myItem = (Instantiate(Resources.Load("cylinder")) as sphere).transform;
    void Start() { Spawn(); } 
    public void Spawn() { 
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2)); 
        Instantiate(kub, pos, Quaternion.identity); // осуществляем появление объекта в заданных случайных позициях в диапазоне заданных координат
        Vector3 pos2 = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        Instantiate(sphere, pos2, Quaternion.identity); 
    } 
    void OnDrawGizmosSelectes() { 
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.localPosition + center, size);
    }
}