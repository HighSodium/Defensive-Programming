using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BaseModule : PlaceableObject
{
    public List<BaseTower> connectedTowers = new();

    public override void Start()
    {
        base.Start();
    }

    public void RefuseConnection()
    {
        Debug.Log("Not a valid Connection");
    }

    public virtual void OnConnect(BaseTower tower) { }
    public BaseTower ConnectTower(BaseTower tower)
    {
        if (connectedTowers.Contains(tower)) 
            RefuseConnection();
        else
        {
            OnConnect(tower);
            connectedTowers.Add(tower);
            tower.connectedModules.Add(this);
        }
        return tower;
    }

    public virtual void OnDisconnect(BaseTower tower) { }
    public BaseTower DisconnectTower(BaseTower tower)
    {
        OnDisconnect(tower);
        tower.connectedModules.Remove(this);
        connectedTowers.Remove(tower);
        return tower;
    }

    public void DisconnectAllTowers()
    {
        foreach(BaseTower tower in connectedTowers) DisconnectTower(tower);
    }

    public void OnDestroy()
    {
        DisconnectAllTowers();
    }

}
