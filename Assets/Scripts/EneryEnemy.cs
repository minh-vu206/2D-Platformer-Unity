using UnityEngine;

public class EnergyEnemy : Enemy
{
    [SerializeField] private GameObject energyObject;

    private float damageCooldown = 1f;
    private float nextDamageTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(enterDamage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Time.time >= nextDamageTime)
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(stayDamage);
                nextDamageTime = Time.time + damageCooldown;
            }
        }
    }

    protected override void Die()
    {
        Debug.Log("EnergyEnemy Die");

        if (energyObject != null)
        {
            Instantiate(energyObject, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("energyObject NULL");
        }

        base.Die();
    }
}