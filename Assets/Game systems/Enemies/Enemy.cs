using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
   [Header("Movement")]
   public Transform target;
   [SerializeField] private float speed = 1.0f;
   private float _step;
   
   [Header("Stats")]
   [SerializeField] protected int health = 10;
   [SerializeField] protected int damage = 2;
   [SerializeField] protected int dropXP = 2;
   [SerializeField] protected GameObject soul;
   [SerializeField] protected GameObject xpOrbe;
   //TODO : faire un SO pour les stats des ennemis
   
   protected virtual void Update()
   {
      Move();
   }

   protected virtual void Move()
   {
      _step = speed * Time.deltaTime;
      transform.position = Vector2.MoveTowards(transform.position, target.position, _step);
   }

   protected virtual void OnTriggerEnter2D(Collider2D other)
   {
      if(other.CompareTag("Player"))
      {
         other.GetComponent<IDamageable>().TakeDamage(damage);
         
         Destroy(this.gameObject);
      }
   }
   
   public void TakeDamage(int pDamage)
   {
      health -= pDamage;
      if (health <= 0)
      {
         SoulDrop();
         XPDrop();
         Destroy(gameObject);
      }
   }
   
   protected void SoulDrop()
   {
      Instantiate(xpOrbe, transform.position, Quaternion.identity);
   }
   
   protected void XPDrop()
   {
      GameObject xp = Instantiate(xpOrbe, transform.position, Quaternion.identity);
      xp.GetComponent<XPOrbe>().xpValue = dropXP;
   }
}
