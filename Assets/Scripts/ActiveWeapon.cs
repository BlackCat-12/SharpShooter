using System;
using Cinemachine;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class ActiveWeapon : MonoBehaviour
{
    private const string WEAPON_SHOOT = "Shoot";
    
    [SerializeField] private WeaponSO startWeaponSO;
	[SerializeField] private CinemachineVirtualCamera  virtualCamera;
    [SerializeField] private GameObject zoomVignette;
    [SerializeField] private TMP_Text ammoText;

    private ParticleSystem muzzleFlash;  
    private WeaponSO _currentWeaponSo;
    private StarterAssetsInputs _inputs;
    private Animator _animator;
    private Weapon _currentWeapon;
    private FirstPersonController _controller;

    private float _coolDown;
    private float defaultZoom;
    private float defaultRotateSpeed;
    private int _currentAmmonAmount;
    
    private void Awake()
    {
        _inputs = GetComponentInParent<StarterAssetsInputs>();  // 从父类获取脚本组件
        _animator = GetComponentInParent<Animator>();
        _controller = GetComponentInParent<FirstPersonController>();
    }

    private void Start()
    {
        _coolDown = -1;
        defaultZoom = virtualCamera.m_Lens.FieldOfView;
        defaultRotateSpeed = _controller.RotationSpeed;
        
        SwitchWeapon(startWeaponSO);
        adjustAmmon(_currentAmmonAmount);
    }

    void Update()
    {
        if (_coolDown >= 0)
        {
            _coolDown -= Time.deltaTime;
        }
        HandleShoot();
        HandleZoom();
    }

    // 左键点击的回调函数
    void HandleShoot()
    {
        if (!_inputs.shoot) return;
        if (_coolDown >= 0 || _currentAmmonAmount <= 0)
        {
            return;
        }
        _coolDown = _currentWeaponSo.FireRate;
        muzzleFlash.Play();
        _animator.Play(WEAPON_SHOOT, 0, 0f);
        adjustAmmon(-1);
        _currentWeapon.Shoot(_currentWeaponSo);
        
        if (!_currentWeaponSo.IsAutomatic)
        {
            _inputs.ShootInput(false);
        }
    }

    void HandleZoom()
    {
        if (!_currentWeaponSo.canZoom) return;
        if (_inputs.zoom)
        {
            virtualCamera.m_Lens.FieldOfView = _currentWeaponSo.zoomVal;
            zoomVignette.SetActive(true);
            _controller.ChangeRotationSpeed(_currentWeaponSo.RotateSpeed);
        }else
        {
            virtualCamera.m_Lens.FieldOfView = defaultZoom;
            zoomVignette.SetActive(false);
            _controller.ChangeRotationSpeed(defaultRotateSpeed);
        }
    }

    public void adjustAmmon(int amount)
    {
        _currentAmmonAmount += amount;
        if (_currentAmmonAmount >= _currentWeaponSo.AmmonAmount)
        {
            _currentAmmonAmount = _currentWeaponSo.AmmonAmount;
        }
        ammoText.text = _currentAmmonAmount.ToString("D2");
    }
    
    public void SwitchWeapon(WeaponSO weaponSo)
    {
        Debug.Log(weaponSo.name);
        if (_currentWeapon != null)
        {
            Destroy(_currentWeapon.gameObject);
        }
        Weapon newWeapon = Instantiate(weaponSo.weaponPrefab, transform).GetComponent<Weapon>();
        muzzleFlash = newWeapon.transform.Find("Muzzle Weapon").gameObject.GetComponent<ParticleSystem>();
        _currentWeapon = newWeapon;
        _currentWeaponSo = weaponSo;
        
        adjustAmmon(weaponSo.AmmonAmount);
    }
}

