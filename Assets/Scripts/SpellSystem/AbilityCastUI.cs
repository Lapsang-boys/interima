using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCastUI : MonoBehaviour {
    // ###################################################################################################
    // Needs to be set in the inspector
    // ###################################################################################################
    public string triggerButton = "Fire1";                          // Button used to trigger
    public Image darkMask;                                          // Reference to the UI child element of this abilityslot
    //public Text coolDownTextDisplay;                              // If we want text indicating cooldown
    public GameObject caster;                                       // Reference to the playercontroler of this UI

    [SerializeField] private Ability ability;                       // Reference to the prefab of typ ability (script sort of)
    //[SerializeField] private GameObject weaponHolder;             // Can be used as a point to fire from

    // ###################################################################################################
 
    private Image abilityIconElement;
    //private AudioSource abilitySource;
    private float coolDown;
    private float nextReadyTime;
    private float coolDownTimeLeft;


    void Start() {
        // On load call initialize UI
        Initialize(ability); // , weaponHolder
    }

    public void Initialize(Ability ability) { // , GameObject weaponHolder
        ability.Initialize(caster);                                 // Intialize the ability prefab/script (set references and pass caster)
        abilityIconElement = GetComponent<Image>();                 // Get the image component that this script is attatched to
        abilityIconElement.sprite = ability.getAbilityIcon();            // Set the sprite (image) to the image assigned in the ability prefab/script
        darkMask.sprite = ability.getAbilityIcon();                      // Set the cooldown UI element to the same image
        coolDown = ability.getCoolDown();                                // Set the cooldown to the cooldown assigned in the ability prefab/script
        //abilitySource = GetComponent<AudioSource>();
        AbilityReady();
    }

    void Update() {
        //In the update keep track on if ability is on cooldown or not
        bool coolDownComplete = (Time.time > nextReadyTime);
        if (coolDownComplete) {
            AbilityReady();
            if (Input.GetButtonDown(triggerButton)) {
                ButtonTriggered();
            }
        } else {
            CoolDown();
        }
    }

    private void AbilityReady() {
        //coolDownTextDisplay.enabled = false;
        darkMask.enabled = false;
    }

    private void CoolDown() {
        coolDownTimeLeft -= Time.deltaTime;
        //float roundedCd = Mathf.Round(coolDownTimeLeft);
        //coolDownTextDisplay.text = roundedCd.ToString();
        darkMask.fillAmount = (coolDownTimeLeft / coolDown);
    }

    private void ButtonTriggered() {
        // If is casting return
        //Might need a disable until trigger ability response
        
        ability.TriggerAbility();

        // If ability.TriggerAbility() == success, set on cooldown
        // elif ability.TriggerAbility() == canceled, pass
        // elif ability.TriggerAbility() == interrupt, 

        nextReadyTime = coolDown + Time.time;
        coolDownTimeLeft = coolDown;
        darkMask.enabled = true;
        //coolDownTextDisplay.enabled = true;

        //abilitySource.clip = ability.aSound;
        //abilitySource.Play();
        
    }
}
