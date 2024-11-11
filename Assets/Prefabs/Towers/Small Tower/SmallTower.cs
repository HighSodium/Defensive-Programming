using System.Linq;
using UnityEngine;

public class SmallTower : AttackTower
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    private void Awake()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (target)
        //{
        //    turret.LookAt(target.transform);
        //}
        //else
        //{
        //    turret.LookAt(turret.position + Vector3.forward);
        //}
    }

    public Transform FindTarget()
    {
        Transform foundEnemy = null;
        while (potentialEnemies.Count > 0 && !foundEnemy)
        {
            foundEnemy = potentialEnemies.Last();
            if (!foundEnemy)
                potentialEnemies.Remove(potentialEnemies.Last());
        }
        return foundEnemy;
    }

    public override void Attack()
    {
        //if no target, we need to stop attacking
        //if (!target) return;
        target = FindTarget();
        if (!target)
        {
            CancelInvoke(nameof(Attack));
            return;
        }

        turret.LookAt(target.position);

        base.Attack();
        if (target.root.TryGetComponent(out IDamageable hit))
        {
            speaker.PlayOneShot(shootSound, 0.2f);
            hit.ApplyHit(damage);
            
        }
    }
    public override void OnAttack()
    {
        base.OnAttack();
        Debug.Log("BOOM!");
    }

    override public void OnEnemyEnter()
    {
        if (!IsInvoking(nameof(Attack)))
        {
            InvokeRepeating(nameof(Attack), 0, tickRate);
        }
    }

    public override void OnEnemyExit()
    {

    }
}
