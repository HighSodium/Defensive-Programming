using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    private int _health = 10;
    [SerializeField]
    private int _shield = 5;
    [SerializeField]
    private bool _invulnerable = false;

    
    public int Health { 
        get => _health;
        set { 

            _health = value;
            if (value <= 0)
            {
                ApplyDeath();
            }
        } 
    }
    public int Shield {
        get => _shield; 
        set => _shield = value; 
    }
    public bool Invulnerable {  
        get => _invulnerable; 
        set => _invulnerable = value; 
    }

    
    public virtual void ApplyHit(int damage)
    {
        OnHit();
        if (!Invulnerable)
        { 
            ApplyDamage(damage);
        }
        else
        {
            OnBlock();
        } 
    }
    public virtual void OnHit() { }
    public virtual void OnBlock() { }

    /// <summary>
    /// Call ApplyHit if doing damage.
    /// </summary>
    public virtual void ApplyDamage(int damage)
    {
        OnDamage(damage);
        Health -= damage;
        

    }
    public virtual void OnDamage(int damage) { }


    public virtual void ApplyDeath()
    {
        OnDeath();
        Destroy(gameObject);
    }
    public virtual void OnDeath() { }
}


