﻿using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttack = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;

    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    bool playerInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject== player)
        {
            playerInRange = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttack && playerInRange && enemyHealth.currentHealth>0)
        {
            Attack();
        }
        if (playerHealth.currentHealth <= 0)
            anim.SetTrigger("PlayerDead");

    }


    void Attack ()
    {
        timer = 0;

        if (playerHealth.currentHealth > 0)
            playerHealth.TakeDamage(attackDamage);
    }
}
