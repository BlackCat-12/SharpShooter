using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject _hitEffectPrefab;
    [SerializeField] private bool isAutomatic = false;
    [SerializeField] public GameObject weaponPrefab;
    [SerializeField] public bool canZoom = false;
	[SerializeField] public float zoomVal = 40;
	[SerializeField] private float rotateSpeed = 4;
	[SerializeField] private int ammonAmount = 12;

    public float FireRate => fireRate;
    public int Damage => damage;
    public GameObject HitEffectPrefab => _hitEffectPrefab;
    public bool IsAutomatic => isAutomatic;
	public float RotateSpeed => rotateSpeed;
	public int AmmonAmount => ammonAmount;
}
