using System;
using UnityEngine;

public abstract class Ennemies : MonoBehaviour
{
   [Header("Movement")]
   [SerializeField] GameObject target;
   [SerializeField] float speed = 1.0f;
   private float step;
   
   [Header("Stats")]
   [SerializeField] float health = 100.0f;
   [SerializeField] float damage = 10.0f;
   
   protected virtual void Update()
   {
      Move();
   }

   protected virtual void Move()
   {
      step = speed * Time.deltaTime;
      transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
   }

    void OnTriggerEnter(Collider other)
   {
      print(other.name + " took " + damage + " damage");
      if(other.CompareTag("Player"))
      {
         //other.GetComponent<Player>().TakeDamage(damage);
         
         Destroy(this.gameObject);
      }
   }
}
