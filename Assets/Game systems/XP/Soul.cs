using UnityEngine;

public class Soul : MonoBehaviour
{
    public int soulValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().AddSoul(soulValue);
            Destroy(gameObject);
        }
    }
}
