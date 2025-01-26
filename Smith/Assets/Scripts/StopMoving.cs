using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMoving : MonoBehaviour
{
    [SerializeField] private MovingForHit movingForHit;
    private void OnTriggerEnter2D(Collider2D collision) //Прекращение движения, нанесение удара
    {
        if(gameObject.tag == "Enemy" && collision.gameObject.tag == "Character")
        {
            Debug.Log("Сработало");

            if(gameObject == movingForHit.curAttacker)
            {
                gameObject.GetComponentInChildren<EnemyAttackAnim>().AttackAnim();
            }
            else if(collision.gameObject == movingForHit.curAttacker)
            {
                collision.gameObject.GetComponentInChildren<PlayerAttackAnim>().AttackAnim();
            }          
            movingForHit.StopAttack();
        }
    }
}
