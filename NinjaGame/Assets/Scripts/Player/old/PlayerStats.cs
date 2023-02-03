using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHp;

    [SerializeField]
    private GameObject 
        deathPiecesParticle, 
        deathBloodParticle;

    private GameManager GM;
    private float currentHp;

    private void Start()
    {
        currentHp = maxHp;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;

        if(currentHp <= 0.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathPiecesParticle, transform.position, deathPiecesParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);

        GM.Respawn();

        Destroy(gameObject);
    }
}