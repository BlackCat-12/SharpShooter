using System;
using UnityEngine;

public class WeaponPickup : M_PickUp
{
    [SerializeField] private WeaponSO weaponSo;
    const string PLAYER_STRING = "Player";

    protected override void OnPickup(ActiveWeapon activeweapon)
    {
        activeweapon.SwitchWeapon(weaponSo);
    }
}
