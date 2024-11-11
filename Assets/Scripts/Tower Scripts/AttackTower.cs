using System.Collections.Generic;
using UnityEngine;

public class AttackTower : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float tickRate = 0.5f;
    public int damage = 1;
    public float range = 10f;

    public Transform turret;
    public Transform target = null;

    protected List<Transform> potentialEnemies = new List<Transform>();

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
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            potentialEnemies.Add(other.transform);
            OnEnemyEnter();
            Debug.Log($"{other.transform} entered!");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            potentialEnemies.Remove(other.transform);
            OnEnemyExit();
            Debug.Log($"{other.transform} exited!");
        }
    }

    public virtual void OnEnemyEnter() { }
    public virtual void OnEnemyExit() { }

}
