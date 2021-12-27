using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public enum EnemyTypes { Zombie, Slime };
    private EnemyTypes type;

    [SerializeField] private GameObject player;
    [SerializeField] private Sprite[] EnemySprites;
    [SerializeField] private SpriteRenderer sr;
    private AIPath path;

    [Header("Stats")]
    [SerializeField] private float ZombieSpeed;
    [SerializeField] private int ZombieDamage;
    [SerializeField] private float ZombieAttackSpeed;

    [Space]

    [SerializeField] private float SlimeSpeed;
    [SerializeField] private int SlimeDamage;
    [SerializeField] private float SlimeAttackSpeed;

    [Space]

    [Header("Current stats:")]
    [SerializeField] private float Speed;
    [SerializeField] private int Damage;
    [SerializeField] private float AttackSpeed;
    [SerializeField] private float Range; //stays constant

    private float timeSinceLastAttack;

    public void SetEnemyType(EnemyTypes type)
    {
        this.type = type;

        switch(type)
        {
            case EnemyTypes.Zombie:
                sr.sprite = EnemySprites[0];

                Speed = ZombieSpeed;
                Damage = ZombieDamage;
                AttackSpeed = ZombieAttackSpeed;

                break;

            case EnemyTypes.Slime:
                sr.sprite = EnemySprites[1];

                Speed = SlimeSpeed;
                Damage = SlimeDamage;
                AttackSpeed = SlimeAttackSpeed;

                break;
        }

        path.maxSpeed = Speed;
        Range = 0.5f;
    }

    void Awake()
    {
        ZombieSpeed = 1f;
        ZombieDamage = 1;
        ZombieAttackSpeed = 1f;

        SlimeSpeed = 1f;
        SlimeDamage = 1;
        ZombieAttackSpeed = 1f;

        timeSinceLastAttack = 0f;

        path = GetComponent<AIPath>();
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) <= Range && timeSinceLastAttack >= AttackSpeed)
        {
            //attack
            player.GetComponent<Health>().healthValue -= Damage;
            timeSinceLastAttack = 0f;
        }

        timeSinceLastAttack += Time.deltaTime;
    }
}
