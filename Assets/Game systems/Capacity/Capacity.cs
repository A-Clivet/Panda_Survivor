using UnityEngine;


public enum CapacityName
{
    ultrasound,
    wingtip
}

public abstract class Capacity : MonoBehaviour
{
    public CapacityName capacityName;
    public float cooldown;
    protected float timer;

    protected virtual void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ExecuteAttack();
            timer = cooldown;
        }
    }

    protected abstract void ExecuteAttack();
}
