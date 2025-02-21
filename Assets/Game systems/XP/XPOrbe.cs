using UnityEngine;

public class XPOrbe : MonoBehaviour
{
    public int xpValue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().AddXP(xpValue);
            Destroy(gameObject);
        }
    }
}
