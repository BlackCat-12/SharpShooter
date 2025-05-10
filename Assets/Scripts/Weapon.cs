using System;
using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public void Shoot(WeaponSO weaponSo)
    {
        RaycastHit raycastHit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, 
                out raycastHit, Mathf.Infinity))
        {
            Debug.Log(raycastHit.collider.transform.name);
            
            Instantiate(weaponSo.HitEffectPrefab, raycastHit.point, Quaternion.identity);
            EnemyHealth enemyHealth = raycastHit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSo);
        }
    }
}
