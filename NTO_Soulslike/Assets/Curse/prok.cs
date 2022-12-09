using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prok : MonoCache
{
    public int damageCount = 10;
    public int damageMana = 1;
    /*private void OnCollisionEnter(Collision collision)// Я так понял этот скрипт вешается на проклятие
    {
        if(collision.gameObject.tag == "Player")
        {
            Damage.damage(damageMana, collision.gameObject.GetComponent<ManaHandler>());
        }
        Damage.damage(damageCount);// Сделай корутину которая будет отнимать у игрока ману, мана на
        

    }
    /*Сделай корутину которая будет отнимать у игрока ману, мана игрока находится в классе manaHandler
     * Обязательно меняй ману через Mana(просто это геттер и сеттер на который тригерится шкала маны) с большой буквы. Сделай, чтобы проклятие тригернулось нормально. 
     * Сделай так, чтобы корутина вызывалась, когда игрок вошел в коллайдер(тригер) проклятия. И завершалась, когда он зашел в конус(тригер) проклятия.
     *ХП МЫ ОТНИМАТЬ ПРИ ПРОКЛЯТИИ НЕ БУДЕМ ТОЛЬКО МАНА.
     */

}
