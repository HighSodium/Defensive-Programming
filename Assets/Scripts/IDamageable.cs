using System.Collections;
using UnityEngine;

public interface IDamageable
{

    int Health { get; set; }
    int Shield { get; set; }
    bool Invulnerable{get; set;}


    public void ApplyHit(int damage);
    public void OnHit();
    public void OnBlock();

    public void ApplyDamage(int damage);
    public void OnDamage(int damage);


    public void ApplyDeath();
    public void OnDeath();
}
