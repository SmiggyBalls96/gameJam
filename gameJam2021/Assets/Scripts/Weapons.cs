using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [Header("Gameobjects and sprite images")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject weapon_holder;
    private SpriteRenderer weaponSR;

    [SerializeField] private Sprite[] weapon_sprites;

    [Header("Animations")]
    [SerializeField] private Animator Animations;

    //what type the object is
    public enum WeaponTypes { Empty, Axe, Sword };
    private WeaponTypes type;

    [Header("Stats")]
    [SerializeField] private float swordSpeed;
    [SerializeField] private float swordDamage;
    [SerializeField] private float swordRange;

    [Space]

    [SerializeField] private float axeSpeed;
    [SerializeField] private float axeDamage;
    [SerializeField] private float axeRange;

    [Space] //double spacing for more room and easier to understand how things are separated in the inspector
    [Space]

    //current stats of the player
    [SerializeField] private float attackSpeed;
    [SerializeField] private float damage;
    [SerializeField] private float range;

    private float timeSinceLastAttack;

    //private methods
    private void update_weapon()
    {
        //update the sprite image based off of what type of weapon it is
        //also updates any stats that the weapon has

        switch(type) 
        {
            case WeaponTypes.Empty:
                weaponSR.sprite = null;
                break;

            case WeaponTypes.Sword:
                weaponSR.sprite = weapon_sprites[0];

                attackSpeed = swordSpeed;
                damage = swordDamage;
                range = swordRange;

                break;


            case WeaponTypes.Axe:
                weaponSR.sprite = weapon_sprites[1];

                attackSpeed = axeSpeed;
                damage = axeDamage;
                range = swordRange;

                break;
        }
    }

    //public methods
    public void set_type(WeaponTypes type)
    {
        this.type = type;
        update_weapon();
    }

    /// <summary>
    /// Takes the attack modifier, or how much the player has upgraded their attack, and attacks nearby enemy based on the range of the current weapon
    /// Calls the animation for the right weapon type as well.
    /// </summary>
    /// <param name="attackModifier"></param>
    public void Attack(float attackModifier)
    {
        //animate and do damage only if the character has finished its cooldown (attackSpeed variable)
        if (timeSinceLastAttack >= attackSpeed)
        {
            timeSinceLastAttack = 0f;

            switch (type)
            {
                case WeaponTypes.Sword:
                    Animations.SetTrigger("Sword");

                    //do damage to enemies right in front of the player
                    break;

                case WeaponTypes.Axe:
                    Animations.SetTrigger("Axe");

                    //do damage to enemies all around the player in a certain radius
                    break;
            }
        }
    }

    void Awake()
    {
        //set variables
        swordDamage = 10;
        swordSpeed = 0.8f;
        swordRange = 0.1f;

        axeDamage = 25;
        axeSpeed = 2f;
        axeRange = 0.3f;

        weaponSR = weapon_holder.GetComponent<SpriteRenderer>();
        type = WeaponTypes.Empty;
        update_weapon();
    }

    void Update()
    {
        timeSinceLastAttack += Time.deltaTime; //update the attack cooldown for the player
    }

    void LateUpdate()
    {
        //move to the player's position
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -0.23f);
    }
}