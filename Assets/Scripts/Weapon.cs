using System;
using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject hitEffectPrefab;
    [SerializeField] private ParticleSystem muzzleFlash;  
    [SerializeField] private int damageAmount;

    
    private StarterAssetsInputs _inputs;
    private Animator _animator;
    
    
    private const string WEAPON_SHOOT = "Shoot";
    

    private void Start()
    {
        _inputs = GetComponentInParent<StarterAssetsInputs>();  // 从父类获取脚本组件
        _animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
        HandleShoot();
    }

    // 左键点击的回调函数
    void HandleShoot()
    {
        if (!_inputs.shoot) return;
        
        muzzleFlash.Play();
        _animator.Play(WEAPON_SHOOT, 0, 0f);
        _inputs.ShootInput(false);
        
        RaycastHit raycastHit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, 
                out raycastHit, Mathf.Infinity))
        {
            Debug.Log(raycastHit.collider.transform.name);
            
            Instantiate(hitEffectPrefab, raycastHit.point, Quaternion.identity);
            EnemyHealth enemyHealth = raycastHit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(this);
        }
    }

    public int DamageAmount() => damageAmount;
}
