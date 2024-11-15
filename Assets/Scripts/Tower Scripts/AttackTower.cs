using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackTower : BaseTower
{    
    


    public Transform turret;
    public Transform target = null;

    public int targetPosX;
    public int targetPosY;
    protected Vector3 shootPos = Vector3.zero;

    public AudioSource speaker;
    public AudioClip shootSound;

    [SerializeField]
    protected Transform debugPosCube;
    [SerializeField]
    protected List<Transform> potentialEnemies = new();

    // ========================================================

    public override void Start()
    {
        base.Start();
        speaker = GetComponent<AudioSource>();
        debugPosCube.gameObject.SetActive(Globals.DEBUG_MODE);
    }

    // ===================== ATTACKING =====================\
    public virtual void AttackEnemy()
    {
        if (!target) return;
        OnAttack();
    }
    public virtual void OnAttack() { }


    protected void AttackArea(Vector3 areaPosition, float areaRange, int areaDamage)
    {
        //use a spherecast at shootPos with bulletDamageRange and output results to an array
        //Collider[] hitColliders = Physics.OverlapSphere(areaPos, areaRange);
        Collider[] hitColliders = Physics.OverlapBox(areaPosition, new Vector3(areaRange, 1, areaRange) / 2);
        foreach (Collider other in hitColliders)
        {
            if (other.CompareTag("Enemy"))
            {
                if (other.transform.root.TryGetComponent(out IDamageable hit))
                {
                    Debug.Log(hit);
                    hit.ApplyHit(areaDamage);
                }
            }
        }

        debugPosCube.position = areaPosition;
        debugPosCube.localScale = new Vector3(areaRange, 1, areaRange);
    }

    // ===================== ENEMY HANDLING ===================== 
    public virtual void OnEnemyEnter() { }
    public virtual void OnEnemyExit() { }
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

    

}
