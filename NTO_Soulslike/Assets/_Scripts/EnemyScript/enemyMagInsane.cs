using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMagInsane : Enemy // Это класс где хранятся хп мобов и функция для нанесения им урона
{
    [SerializeField] float speed = 10;
    public float parryWindow;
    NavMeshAgent agent;
    public Transform player;
    [SerializeField] float stoppingDistanse, stopPlayerDistanse;
    float stoppingDistanseSave = 0;
    [SerializeField] private float moveDistance = 10f;
    float waitTime;
    [SerializeField] float startWaitTime;
    public GameObject stunParticles;
    bool angry,noDrag, stun,goBack;
    public StatesEnemy statesEnemy;
    public enum StatesEnemy{
            angry,
            attack,
            goBack,
            noDrag,
            parry
        }
    Vector3 randomDirection;
    public Transform head;
    public Animator knifeAnim;

    
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        stoppingDistanseSave = stoppingDistanse;
    }
    
    Vector3 RandomNavSphere(float distance)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;

        this.randomDirection += transform.position;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, -1);

        return navHit.position;
    }
    public override void OnTick() // Замена методу Update(Так надо)
    {
        if(Vector3.Distance(transform.position, player.position) > stoppingDistanse && stun == false )
        {
            noDrag = true;
            statesEnemy = StatesEnemy.noDrag;
            
        }
        if (Vector3.Distance(transform.position, player.position) < stoppingDistanse && stun ==false)
        {
            angry = true;
            noDrag = false;
            statesEnemy = StatesEnemy.angry;
        }

        if (noDrag)
        {
            
        }
        else if (angry)
        {
            AngryForPlayer();
        }
        else if (goBack)
        {
            GoBack();
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
            statesEnemy = StatesEnemy.angry;
            StartCoroutine(goback());
        }
        var dir = player.position-transform.position;
        var angle = Mathf.Atan2(dir.x,dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, angle, 0);
        
    }
        
        

    IEnumerator Stun()
    {
        GameObject stunPart = Instantiate(stunParticles, head.position, Quaternion.identity);
        Destroy(stunPart, parryWindow);
        stun = true;
        yield return new WaitForSeconds(parryWindow);
        stun = false;
        yield return null;
    }
      IEnumerator ParryCor()
      {
          yield return new WaitForSeconds(parryWindow);
          IsParrying = false;
      }
      IEnumerator goback()
      {
        stoppingDistanse = 0;
        goBack = true;
        statesEnemy = StatesEnemy.goBack;
        yield return new WaitForSeconds(5);
        stoppingDistanse = stoppingDistanseSave;
        noDrag = true;
        goBack = false;
    }
    void GoBack()
    {
        var dir = player.position;
        transform.Translate(-dir * speed/10 * Time.deltaTime);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            int rand = Random.Range(0, 4);
            if (rand == 1)
            {
                IsParrying = true;
                StartCoroutine(ParryCor());
            }
        }
    }
    /*В первую очередь пропиши до конца логику ближнику. Сделай все как написано в дизайн документе. 
     * Мои советы:
     * Статус игрока можешь посмотреть в классе PlayerStates туда записано парирует ли игрок, оглушен ли он, атакует, делает рывок или ничего из этого (Idle)
     * Оружие с мечом лежит в папке weapons. Как воспользоваться свойствами оружия придумай сам(я предлагаю например использовать переменную afterComboCd для временных промежутков между ударами).
     * Все таки я решил упростить тебе задачу лучше не давай возможность врагам делать комбо(так может даже играться лучше будет:)), чтобы потратить больше времени на гибрида или босса.
     * Для того чтобы враг отходил от игрока можешь тупо отрицательную скорость поставить.
     * Если вдруг понадобится назначить игроку оглушение используй функцию в классе Stun под названием GetStun(я туда спецэффект поставил, но он пока что должен вертется вокруг центра игрока)
     
     * В самую последнюю очередь можешь добавить NavMeshAgent для врага(это штука которая добавляет PathFinding). НО В САМУЮ ПОСЛЕДНЮЮ ОЧЕРЕДЬ!
     * 
     */

}
