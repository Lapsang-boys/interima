using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellInfo : MonoBehaviour {
    // ###################################################################################################
    // This class is used to pass all neccecary info for interaction between a spell and it targets/caster
    // ###################################################################################################

    // ---------------------------------------------------------------------------------------------------
    // Player objects
    // ---------------------------------------------------------------------------------------------------

    // GameObject that casted the spell, can be used to find position at impact etc
    public GameObject caster;
    // GameObject that was targeted by the spell, can be used to continiously update a homing missile etc
    public GameObject target;

    // ---------------------------------------------------------------------------------------------------
    // Positions
    // ---------------------------------------------------------------------------------------------------
    
    // Use this for the poistion of the caster at the time of casting
    public Vector3 casterPosition;
    // Use this for the origin of the spell/projectile (for instance if it is offset from the caster)
    public Vector3 spellOrigin;
    // Use this for the target point of the spell
    public Vector3 spellTargetPoint;

    // ---------------------------------------------------------------------------------------------------
    // Spell data
    // ---------------------------------------------------------------------------------------------------
    
    // --- Damage ---
    // True = friends and self will be damaged / affected
    public bool friendlyFire;
    // Damage
    public float damage;
    // Area of effect
    public float radius;
    // DoT damage (amount of damage each time dot ticks)
    public float dotDamage;
    // DoT interval (how often the DoT amount will be applied) [Seconds between each tick]
    public float dotInterval;
    // Dot duration (how many seconds the DoT will persist)
    public float dotDuration;

    // --- Effects (slow etc) ---
    // The effect applied, for instance ["slow"]
    public string effect;
    // Effect duration (how many seconds the effect will persist)
    public float effectDuration;
    // Effect amount percent, for instance [-30] for -30% slow
    public float effectAmountPercent;
    // Effect amount value, for instance [-30] for -30 attack or -30 movementspeed
    public float effectAmountValue;
}
