using UnityEngine;

public class SmallEnemy : BaseEnemy
{
    void Start()
    {
        
    }

    //----------------------------------------------------------------

    public override void OnHit()
    {
        Debug.Log($"I've been hit!");
    }
    public override void OnBlock()
    {
        Debug.Log($"TINK!");
    }

    public override void OnDamage(int damage)
    {
        Debug.Log($"FUCK! I've taken {damage} damage!");
    }

    public override void OnDeath()
    {
        Debug.Log($"I am dead now.");
    }
}
