using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Enemy2forFactory : EnemyBase
{
    public EnemyData enemyData; // Reference to the EnemyData ScriptableObject
    public GameObject dieEffectPrefab; // Reference to the die effect prefab
    private int health; // Enemy health
    public int damage = 10; // Damage dealt by the enemy

    private void Awake()
    {
        // Apply data from EnemyData to set properties
        gameObject.name = enemyData.enemyName;
        health = enemyData.health;
        damage = enemyData.damage;
        // Set initial colour based on EnemyData
        GetComponent<Renderer>().material.color = enemyData.enemyColor;
    }
    private void OnEnable()
    {
        // Spawn animation: Scale from 0 to 1 over 1 second with DOTween
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce);
    }
    public override void TakeDamage(int damage)
    {
        health -= damage;
        // Trigger damage event and inherited hit effect
        HealthEventManager.OnObjectDamaged?.Invoke(gameObject.name, health);
        ShowHitEffect(); // Inherited from EnemyBase
        if (health <= 0)
        {
            Die();
            HealthEventManager.OnObjectDestroyed?.Invoke(gameObject.name, health);
        }
    }

    public override void Die()
    {
        // Play death effect and sound
        if (dieEffectPrefab != null)
        {
            Instantiate(dieEffectPrefab, transform.position, Quaternion.identity);
        }

        AudioEventManager.PlaySFX(null, "Explosion Flesh", 1.0f, 1.0f, true, 0.1f, 0f);
        Destroy(gameObject);
        Debug.Log("Enemy has died");
        // Update score based on enemy health
        GameManager.Instance.AddScore(10 * enemyData.health);
    }

    public override void Move()
    {
        // Define movement specific to this enemy, if needed
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Apply damage to other objects implementing IDamagable
        IDamagable damagableObject = collision.gameObject.GetComponent<IDamagable>();
        if (damagableObject != null && collision.gameObject.tag != "Enemy")
        {
            damagableObject.TakeDamage(damage);
            Debug.Log($"{gameObject.name} dealt {damage} damage to {collision.gameObject.name}.");
        }
    }
}
