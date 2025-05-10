using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem muzzleFlash;  
    [SerializeField] public WeaponSO weaponSo;

    
    private StarterAssetsInputs _inputs;
    private Animator _animator;
    private Weapon _weapon;
    private float _coolDown;
    
    private const string WEAPON_SHOOT = "Shoot";
    

    private void Start()
    {
        _inputs = GetComponentInParent<StarterAssetsInputs>();  // 从父类获取脚本组件
        _animator = GetComponentInParent<Animator>();
        _weapon = GetComponentInChildren<Weapon>();

        _coolDown = -1;
    }

    void Update()
    {
        HandleShoot();
        if (_coolDown >= 0)
        {
            _coolDown -= Time.deltaTime;
        }
    }

    // 左键点击的回调函数
    void HandleShoot()
    {
        if (!_inputs.shoot) return;
        if (_coolDown >= 0)
        {
            return;
        }

        _coolDown = weaponSo.FireRate;
        muzzleFlash.Play();
        _animator.Play(WEAPON_SHOOT, 0, 0f);
        _weapon.Shoot(weaponSo);
        _inputs.ShootInput(false);
    }
}
