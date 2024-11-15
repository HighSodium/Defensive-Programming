using System.Linq;
using UnityEngine;

public class SmallTower : AttackTower
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
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
            foundEnemy = potentialEnemies.First();
            if (!foundEnemy)
                potentialEnemies.Remove(potentialEnemies.First());
        }
        return foundEnemy;
    }

    public override void AttackEnemy()
    {
        //if no target, we need to stop attacking
        //if (!target) return;
        target = FindTarget();
        if (!target)
        {
            CancelInvoke(nameof(AttackEnemy));
            return;
        }

        targetPosX = (int)target.position.x;
        targetPosY = (int)target.position.z;

        shootPos.x = targetPosX;
        shootPos.z = targetPosY;

        

        //get manhattan distance of current postion to target position
        int cellDistance = Grid.GetGridDistance(transform.position, target.position);
        Debug.Log($"Dist to target: {cellDistance}");
        if(cellDistance > towerStats[TowerStats.Stat.TowerRange].Total)
        {
            CancelInvoke(nameof(AttackEnemy));
            return;
        }
        turret.LookAt(shootPos);

        int damageArea = (int)towerStats[TowerStats.Stat.DamageArea].Total;
        int damage = (int)towerStats[TowerStats.Stat.Damage].Total;
        AttackArea(shootPos, damageArea, damage);
        Debug.Log($"Hit for {damage} damage in {damageArea} area at {shootPos}");

        speaker.PlayOneShot(shootSound, 0.2f);

    }
    public override void OnAttack()
    {
        base.OnAttack();
        Debug.Log("BOOM!");
    }

    override public void OnEnemyEnter()
    {
        if (!IsInvoking(nameof(AttackEnemy)))
        {
            InvokeRepeating(nameof(AttackEnemy), 0, 1 / towerStats[TowerStats.Stat.TickRate].Total);
        }
    }

    public override void OnEnemyExit()
    {

    }
}
