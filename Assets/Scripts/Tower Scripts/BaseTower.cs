using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static TowerStats;


[RequireComponent(typeof(TowerStats))]
public class BaseTower : PlaceableObject
{
    // ============ VARIABLES ============

    public List<BaseModule> connectedModules = new();

    public Dictionary<Stat, StatValue> towerStats = new()
    {
        {Stat.Damage, new StatValue(1) },
        {Stat.DamageArea, new StatValue(1) },
        {Stat.TowerRange, new StatValue(10) },
        {Stat.TickRate, new StatValue(1) }
    };

    // ============ FUNCTIONS ============
    public override void Start()
    {
        base.Start();
    }

    public void RefuseConnection()
    {
        Debug.Log("Not a valid Connection");
    }

    public virtual void OnConnect(BaseModule module) { }
    public BaseModule ConnectModule(BaseModule module)
    {
        if (connectedModules.Contains(module))
        {
            RefuseConnection();
        }
        else
        {
            OnConnect(module);
            connectedModules.Add(module);
            module.connectedTowers.Add(this);
        } 
        return module;
    }

    public virtual void OnDisconnect(BaseModule module) { }
    public BaseModule DisconnectModule(BaseModule module)
    {
        OnDisconnect(module);
        module.connectedTowers.Remove(this);
        connectedModules.Remove(module);
        return module;
    }

    public void DisconnectAllModules()
    {
        foreach (BaseModule module in connectedModules) DisconnectModule(module);
    }

    public void OnDestroy()
    {
        DisconnectAllModules();
    }
}
