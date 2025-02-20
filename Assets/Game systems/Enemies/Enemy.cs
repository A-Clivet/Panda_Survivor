using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
   [Header("Movement")]
   public GameObject target;
   [SerializeField] private float speed = 1.0f;
   private float _step;
   
   [Header("Stats")]
   [SerializeField] protected int health = 10;
   [SerializeField] protected int damage = 2;
   
   protected virtual void Update()
   {
      Move();
   }

   protected virtual void Move()
   {
      _step = speed * Time.deltaTime;
      transform.position = Vector2.MoveTowards(transform.position, target.transform.position, _step);
   }

   protected virtual void OnTriggerEnter2D(Collider2D other)
   {
      if(other.CompareTag("Player"))
      {
         other.GetComponent<PlayerStats>().TakeDamage(damage);
         
         Destroy(this.gameObject);
      }
   }
   
   public void TakeDamage(int pDamage)
   {
      health -= pDamage;
      if (health <= 0)
      {
         Destroy(gameObject);
      }
   }
}
