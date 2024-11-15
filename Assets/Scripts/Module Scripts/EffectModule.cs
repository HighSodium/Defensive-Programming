using UnityEngine;

public class EffectModule : BaseModule
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void OnConnect(BaseTower tower)
    {
        base.OnConnect(tower);
        // ADD EFFECT TO TOWER
    }

    public override void OnDisconnect(BaseTower tower)
    {
        base.OnDisconnect(tower);
        // ADD EFFECT TO TOWER

    }
}
