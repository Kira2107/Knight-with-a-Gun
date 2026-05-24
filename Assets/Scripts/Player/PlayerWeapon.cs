using UnityEngine;

public class PlayerWeapon : AgentWeapon
{
    [SerializeField] private AmmoUI ammoUI = null;

    public bool AmmoFull { get => weapon != null && weapon.ammoFull; }

    void Start()
    {
        if (weapon != null)
        {
            weapon.OnAmmoChange.AddListener(ammoUI.UpdateBulletText);
            ammoUI.UpdateBulletText(weapon.Ammo);
        }
    }

    public void AddAmmo(int amount)
    {
        if (weapon != null)
        {
            weapon.Ammo += amount;
        }
    }

}
