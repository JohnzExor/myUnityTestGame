using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSwordTest : MonoBehaviour
{
    public GameObject weapon;
    public GameObject weaponSheath;
    public GameObject weaponHolder;

    GameObject currentWeaponSheath;
    GameObject currentWeaponOnHold;
    public Animator anim;

    public bool onCombatState = false;

    private void Start()
    {
        currentWeaponSheath = Instantiate(weapon, weaponSheath.transform);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            onCombatState = !onCombatState;
        }

        anim.SetBool("combatState", onCombatState);
    }

    private void SheathWeapon()
    {
        currentWeaponSheath = Instantiate(weapon, weaponSheath.transform);
        Destroy(currentWeaponOnHold);
    }

    private void DrawWeapon()
    {
        currentWeaponOnHold = Instantiate(weapon, weaponHolder.transform);
        Destroy(currentWeaponSheath);
    }
}
