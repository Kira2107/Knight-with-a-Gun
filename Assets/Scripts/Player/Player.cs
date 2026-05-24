using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [SerializeField] private int maxHealth;
    [field: SerializeField] private int health;
    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            healthUI.UpdateUI(health);
        }
    }
    [field: SerializeField] public HealthUI healthUI { get; private set; }
    [field: SerializeField] public UnityEvent OnGetHit { get; set; }
    [field: SerializeField] public UnityEvent OnDeath { get; set; }
    private bool isDead = false;
    private PlayerWeapon playerWeapon;

    void Awake()
    {
        playerWeapon = GetComponentInChildren<PlayerWeapon>();
    }

    void Start()
    {
        Health = maxHealth;
        healthUI.Initialize(Health);
    }  


    public void GetHit(int damage, GameObject damageDealer)
    {
        if (!isDead)
        {
            Health -= damage;
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                OnDeath?.Invoke();
                isDead = true;
            }
        }
    }

      
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Resource"))
        {
            var resource = other.GetComponent<Resource>();
            if (resource != null)
            {
                switch (resource.ResourceData.resourceType)
                {
                    case ResourceTypeEnum.Health:
                        if (Health >= maxHealth)
                        {
                            return;
                        }
                        Health += resource.ResourceData.GetAmount();
                        resource.PickUpResource();

                        break;

                    case ResourceTypeEnum.Ammo:
                        if (playerWeapon.AmmoFull)
                        {
                            return;
                        }
                        playerWeapon.AddAmmo(resource.ResourceData.GetAmount());
                        resource.PickUpResource();

                        break;

                    default:
                        Debug.LogWarning("Unknown resource type picked up.");
                        break;
                }
            }
        }
    }
}
