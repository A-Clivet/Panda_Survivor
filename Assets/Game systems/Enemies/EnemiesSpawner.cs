using UnityEngine;
using UnityEngine.Serialization;

public enum EnnemyType
{
    LittleFlame
}
public class EnemiesSpawner : MonoBehaviour
{
    private Vector2 ennemyPosition;
    [SerializeField] private float cooldown = 2.0f;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform TopWall;
    [SerializeField] private Transform DownWall;
    [SerializeField] private Transform LeftWall;
    [SerializeField] private Transform RightWall;
    
    private void Start()
    {
        SpawnEnemy();
    }

    //TODO: rajouter un systeme de vague et de spawn d'ennemis differents
    
    
    private void SpawnEnemy()
    {
        float scale = Random.Range(0.5f, 1f);
        
        GameObject enemyGO = Instantiate(enemy, SpawnPosition(), Quaternion.identity, this.transform);
        enemyGO.transform.localScale = new Vector3(scale, scale, 1);
        enemyGO.GetComponent<Enemy>().target = target;
        TimerManager.StartTimer(cooldown, SpawnEnemy);
    }
    
    private Vector2 SpawnPosition()
    {
        ennemyPosition = new Vector2(
            Random.Range(LeftWall.position.x, RightWall.position.x),
            Random.Range(DownWall.position.y, TopWall.position.y));
        
        if(Mathf.Abs(ennemyPosition.x) - Mathf.Abs(target.position.x) < 10 |
           Mathf.Abs(ennemyPosition.y) - Mathf.Abs(target.position.y) < 10)
        {
            SpawnPosition();
        }

        return ennemyPosition;
    }
}
