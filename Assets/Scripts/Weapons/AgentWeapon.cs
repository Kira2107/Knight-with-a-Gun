using System;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected float desiredAngle;
    [SerializeField] protected WeaponRenderer weaponRenderer;
    [SerializeField] protected Weapon weapon;

    void Awake()
    {
        AssignWeapon();
    }

    private void AssignWeapon()
    {
        weaponRenderer = GetComponentInChildren<WeaponRenderer>();
        if (weaponRenderer == null)
        {
            Debug.LogError("WeaponRenderer component is missing on " + gameObject.name);
        }

        weapon = GetComponentInChildren<Weapon>();
    }

    public virtual void AimWeapon(Vector2 pointerPosition)
    {
        var aimDirection = (Vector3)pointerPosition - transform.position;
        desiredAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        AdjustWeaponRendering();
        transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);
    }

    protected void AdjustWeaponRendering()
    {
        if (weaponRenderer != null)
        {
            weaponRenderer?.FlipSprite(desiredAngle > 90 || desiredAngle < -90);
            weaponRenderer?.RenderBehindHead(desiredAngle < 180 && desiredAngle > 0);
        }
    }

    public void Shoot()
    {
        if(weapon != null)
        {
            weapon.TryShooting();
        }
    }

    public void StopShooting()
    {
        if(weapon != null)
        {
            weapon.StopShooting();
        }
    }
}
