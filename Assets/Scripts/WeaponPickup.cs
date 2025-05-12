using System;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private WeaponSO weaponSo;
    const string PLAYER_STRING = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PLAYER_STRING)
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            activeWeapon.SwitchWeapon(weaponSo);
            Destroy(this.gameObject);
        }
    }
}
