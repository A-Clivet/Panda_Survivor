using UnityEngine;
using UnityEngine.Serialization;

public enum EnnemyType
{
    LittleFlame
}
public class EnemiesSpawner : MonoBehaviour
{
    private GameObject NewEnemy;
    private Vector2 ennemyPosition;
    [SerializeField] private float cooldown = 2.0f;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform TopWall;
    [SerializeField] private Transform DownWall;
    [SerializeField] private Transform LeftWall;
    [SerializeField] private Transform RightWall;
    
    private void Start()
    {
        SpawnEnnemy();
    }

    //TODO: rajouter un systeme de vague et de spawn d'ennemis differents
    
    
    private void SpawnEnnemy()
    {
        NewEnemy = Instantiate(enemy, SpawnPosition(), Quaternion.identity);
        NewEnemy.GetComponent<Enemy>().target = target;
        TimerManager.StartTimer(cooldown, SpawnEnnemy);
    }
    
    
    private Vector2 SpawnPosition()
    {
        ennemyPosition = new Vector2(
            Random.Range(LeftWall.position.x, RightWall.position.x),
            Random.Range(DownWall.position.y, TopWall.position.y));
        
        if(Mathf.Abs(ennemyPosition.x) - Mathf.Abs(target.transform.position.x) < 10 |
           Mathf.Abs(ennemyPosition.y) - Mathf.Abs(target.transform.position.y) < 10)
        {
            SpawnPosition();
        }

        return ennemyPosition;
    }
}
