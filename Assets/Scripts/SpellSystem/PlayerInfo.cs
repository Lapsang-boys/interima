using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Core/PlayerInfo")]
public class PlayerInfo : ScriptableObject {
    // Current info
    public int currentHealth;
    public int maxHealth;
    public int currentMovementSpeed;
    public int maxMovementSpeed;
    public bool isAlive = true;

    // States
    public bool isCasting = false;
    public bool isSilenced = false;
    public bool isStunned = false;
    public bool isInterrupted = false;

    // Gameplay
    //public enum team;
}
