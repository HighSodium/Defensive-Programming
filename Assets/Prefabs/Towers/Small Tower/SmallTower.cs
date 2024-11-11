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
        if (target)
        {
            turret.LookAt(target.transform);
        }
        else
        {
            turret.LookAt(turret.position + Vector3.forward);
        }
    }

    override public void OnEnemyEnter()
    {
        target = potentialEnemies.Last();
    }

    public override void OnEnemyExit()
    {
        if (potentialEnemies.Count < 1)
        {
            target = null;
            return;
        }
        target = potentialEnemies.Last();
    }
}
