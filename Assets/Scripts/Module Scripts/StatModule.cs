using UnityEngine;
public class StatModule : BaseModule
{

    [Space][Space][Space] //add some space in the editor lol

    [SerializeField]
    protected TowerStats.Stat modifiedStatType;
    [SerializeField]
    protected int modifierValue = 1;

    // ===================== FUNCTIONS =====================
    public override void Start()
    {
        base.Start();
        Debug.Assert(modifiedStatType != TowerStats.Stat.NULL, "Module StatType is NULL. Pick an type in the editor.");
    }
    public override void OnConnect(BaseTower tower)
    {
        base.OnConnect(tower);
        tower.towerStats[modifiedStatType].modifier += modifierValue;
    }
    public override void OnDisconnect(BaseTower tower)
    {
        base.OnDisconnect(tower);
        tower.towerStats[modifiedStatType].modifier -= modifierValue;

    }

    // ============ TEST COLLISION ===========
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tower"))
        {
            other.TryGetComponent(out BaseTower tower);
            ConnectTower(tower);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tower"))
        {
            other.TryGetComponent(out BaseTower tower);
            DisconnectTower(tower);
        }
    }
}