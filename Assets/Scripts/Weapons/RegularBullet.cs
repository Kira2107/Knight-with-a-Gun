using System;
using UnityEngine;

public class RegularBullet : Bullet
{
    protected Rigidbody2D bulletRb;
    private bool isDead = false;
    public override BulletDataSO bulletData
    {
        get => base.bulletData;
        set
        {
            base.bulletData = value;
            bulletRb = GetComponent<Rigidbody2D>();
            bulletRb.linearDamping = bulletData.Friction;
        }
    }

    void FixedUpdate()
    {
        if (bulletRb != null && bulletData != null)
        {
            bulletRb.MovePosition(transform.position + bulletData.BulletSpeed * transform.right * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;
        isDead = true;
        var hittable = other.GetComponent<IHittable>();
        if (hittable != null)
        {
            hittable.GetHit(bulletData.Damage, gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Debug.Log($"Hit obstacle: {other.name}");
            HitObstacle(other);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log($"Hit enemy: {other.name}");
            HitEnemy(other);
        }

        Destroy(gameObject);
    }

    private void HitEnemy(Collider2D other)
    {
        Vector2 randomOffset = UnityEngine.Random.insideUnitCircle * 0.5f;
        Instantiate(bulletData.ImpactEnemyPrefab, other.transform.position + (Vector3)randomOffset, Quaternion.identity);

        var knockback = other.GetComponent<IKnockBack>();
        if (knockback != null)
        {
            knockback.KnockBack(transform.right, bulletData.KnockBackPower, bulletData.KnockBackDelay);
        }
    }

    private void HitObstacle(Collider2D other)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1, bulletData.BulletLayerMask);
        if (hit.collider != null)
        {
            Instantiate(bulletData.ImpactObstaclePrefab, hit.point, Quaternion.identity);
        }
    }
    

}
