using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject muzzle;
    [SerializeField] protected WeaponDataSO weaponData;
    public int ammo = 10; // Default ammo count
    public int Ammo
    {
        get { return ammo; }
        set
        {
            ammo = Mathf.Clamp(value, 0, weaponData.AmmoCapacity); // Clamp ammo between 0 and MaxAmmo
            OnAmmoChange?.Invoke(ammo);
        }
    }
    public bool ammoFull { get => Ammo >= weaponData.AmmoCapacity; } // Check if ammo is at maximum capacity
    protected bool isShooting = false;
    protected bool reloadCoroutine = false;

    [field: SerializeField] public UnityEvent OnShoot { get; set; }
    [field: SerializeField] public UnityEvent OnShootNoAmmo { get; set; }
    [field: SerializeField] public UnityEvent<int> OnAmmoChange { get; set; }

    void Start()
    {
        Ammo = weaponData.AmmoCapacity; // Initialize ammo to maximum capacity
    }
    public void TryShooting()
    {
        // shooting
        isShooting = true;
    }

    public void StopShooting()
    {
        // stop shooting
        isShooting = false;
    }

    public void Reload(int ammo)
    {
        Ammo += ammo; // Add ammo to current ammo count

    }

    void Update()
    {
        UseWeapon();
    }

    private void UseWeapon()
    {
        if (isShooting && !reloadCoroutine)
        {
            if (Ammo > 0)
            {
                // Perform shooting logic
                Ammo--;
                OnShoot?.Invoke();
                for (int i = 0; i < weaponData.GetBulletCountToSpawn(); i++)
                {
                    ShootBullet();
                }
            }
            else
            {
                isShooting = false; // Stop shooting if no ammo
                OnShootNoAmmo?.Invoke();
                return;
            }
            FinishShooting();
        }
    }

    private void FinishShooting()
    {
        StartCoroutine(DelayNextShotCoroutine());
        if (!weaponData.AutomaticFire)
        {
            isShooting = false; // Stop shooting if not automatic fire
        }
    }

    protected IEnumerator DelayNextShotCoroutine()
    {
        reloadCoroutine = true;
        yield return new WaitForSeconds(weaponData.WeaponDelay);
        reloadCoroutine = false;
    }

    private void ShootBullet()
    {
        SpawnBullet(muzzle.transform.position, CalculateAngle(muzzle));
    }

    private Quaternion CalculateAngle(GameObject muzzle)
    {
        float spread = UnityEngine.Random.Range(-weaponData.SpreadAngle, weaponData.SpreadAngle);
        Quaternion bulletSpreadRotation = Quaternion.Euler(new Vector3(0, 0, spread));
        return muzzle.transform.rotation * bulletSpreadRotation;
    }

    private void SpawnBullet(Vector3 position, Quaternion rotation)
    {
        var bulletPrefab = Instantiate(weaponData.BulletData.BulletPrefab, position, rotation);
        bulletPrefab.GetComponent<Bullet>().bulletData = weaponData.BulletData;
    }

}
