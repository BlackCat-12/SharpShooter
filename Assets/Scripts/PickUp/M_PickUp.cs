using System;
using UnityEngine;

public abstract class M_PickUp : MonoBehaviour
{
    [SerializeField] private float RotateSpeed = 100;

    private void Update()
    {
        this.transform.Rotate(Vector3.up, RotateSpeed * Time.deltaTime);
    }

    const string PLAYER_STRING = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PLAYER_STRING)
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            OnPickup(activeWeapon);
            Destroy(this.gameObject);
        }
    }
    protected abstract void OnPickup(ActiveWeapon active);
}
