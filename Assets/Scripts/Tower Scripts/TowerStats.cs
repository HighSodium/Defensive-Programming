using System.Collections.Generic;
using UnityEngine;

public class TowerStats : MonoBehaviour
{
    public enum Stat
    {
        NULL,
        TickRate,
        Damage,
        DamageArea,
        TowerRange,
    }
    public class StatValue
    {
        public StatValue(int startingValue) { BaseValue = startingValue; }
        public StatValue() { _baseValue = 1; }

        // clamp base value to 0 or greater
        private int _baseValue;
        public int BaseValue { get => _baseValue; set => _baseValue = Mathf.Max(0, value); }
        public int modifier = 0;
        public int Total => _baseValue + modifier;
    }

    // construction format for Towers
    //public Dictionary<Stat, StatValue> stats = new()
    //{
    //    {Stat.Damage, new StatValue() },
    //    {Stat.DamageArea, new StatValue() },
    //    {Stat.TowerRange, new StatValue() },
    //    {Stat.TickRate, new StatValue() }
    //};
}
