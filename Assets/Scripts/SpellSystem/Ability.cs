using UnityEngine;
using System.Collections;

public abstract class Ability : ScriptableObject {

    //public string aName = "New Ability";
    //public AudioClip aSound;
    //public float aBaseCoolDown = 3f;

    //[HideInInspector]
    private Sprite abilityIcon;
    //[HideInInspector]
    public float CD;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();

    public void setCoolDown(float CD) {
        this.CD = CD;
    }

    public float getCoolDown() {
        return this.CD;
    }

    public void setAbilityIcon(Sprite abilityIcon) {
        this.abilityIcon = abilityIcon;
    }

    public Sprite getAbilityIcon() {
        return this.abilityIcon;
    }

}