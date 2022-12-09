using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMagInsane : MonoBehaviour
{
    [SerializeField] float speed = 10;

    public int positionPatrol;
    int RandInt;

    Transform player;
    [SerializeField] float stoppingDistanse, stopPlayerDistanse;

    public Transform[] movePoints;
    float waitTime;
    [SerializeField]float startWaitTime;
    public GameObject stunParticles;
    bool angry, goBack, noDrag,stun;

    public Transform head;
    public Animator knifeAnim;
    void Start()
    {
        RandInt = Random.Range(0,movePoints.Length);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, movePoints[RandInt].position) < positionPatrol && angry == false && stun == false)
        {
            noDrag = true;
            goBack = false;
        }
        if (Vector3.Distance(transform.position, player.position) < stoppingDistanse && stun ==false)
        {
            angry = true;
            noDrag = false;
            goBack = false;
        }
        else if (Vector3.Distance(transform.position, player.position) > stoppingDistanse && stun == false)
        {
            goBack = true;
            angry = false;
        }
        if (noDrag)
        {
            NoDrag();
        }
        else if (goBack)
        {
            GoBack();
        }
        else if (angry)
        {
            AngryForPlayer();
        }
    }
    void NoDrag()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoints[RandInt].position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position,movePoints[RandInt].position) <0.5)
        {
            if(waitTime <= 0)
            {
                RandInt = Random.Range(0, movePoints.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime-=Time.deltaTime;
            }
        }
    }
    void AngryForPlayer()
    {
        if (Vector3.Distance(transform.position,player.position) > stopPlayerDistanse)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            knifeAnim.SetTrigger("Play");
        }
        transform.LookAt(player.position);
    }
    IEnumerator Stun()
    {
        GameObject stunPart = Instantiate(stunParticles, head.position, Quaternion.identity);
        Destroy(stunPart, 3);
        stun = true;
        yield return new WaitForSeconds(3);
        stun = false;
        yield return null;
    }
    void StunFinish() { stun = false; }
    void GoBack()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoints[RandInt].position, speed * Time.deltaTime);
    }
}
