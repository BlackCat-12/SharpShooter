using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject _hitEffectPrefab;
    
    public float FireRate => fireRate;
    public int Damage => damage;
    public GameObject HitEffectPrefab => _hitEffectPrefab;
}
