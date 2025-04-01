using System;
using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    // Update is called once per frame
    private StarterAssetsInputs _inputs;
    

    private void Start()
    {
        _inputs = GetComponentInParent<StarterAssetsInputs>();  // 从父类获取脚本组件
    }

    void Update()
    {
        HandleShoot();
       
    }

    void HandleShoot()
    {
        if (!_inputs.shoot) return;
        
        RaycastHit raycastHit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, 
                out raycastHit, Mathf.Infinity))
        {
            Debug.Log(raycastHit.collider.transform.name);
            EnemyHealth enemyHealth = raycastHit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(this);
            
            _inputs.ShootInput(false);
        }
    }

    public int DamageAmount() => damageAmount;
}
