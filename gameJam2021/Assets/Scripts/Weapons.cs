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

    [Space]

    [SerializeField] private float axeSpeed;
    [SerializeField] private float axeDamage;

    [Space] //double spacing for more room and easier to understand how things are separated in the inspector
    [Space]

    [SerializeField] private float attackSpeed;
    [SerializeField] private float damage;

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
                break;

            case WeaponTypes.Axe:
                weaponSR.sprite = weapon_sprites[1];
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
                    break;

                case WeaponTypes.Axe:
                    break;
            }
        }
    }

    void Awake()
    {
        weaponSR = weapon_holder.GetComponent<SpriteRenderer>();
        type = WeaponTypes.Empty;
        update_weapon();
    }

    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
    }
}