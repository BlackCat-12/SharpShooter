using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 0;
    private int currentHealth = 0;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(Weapon weapon)
    {
        currentHealth -= weapon.DamageAmount();
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        Destroy(this.gameObject);
    }
}
