using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int _hp;
    public EnemiesController Controller;
    public Transform fireEffect;


    public void ApplyDamage(int dmg)
    {
        if (_hp <= 0)
            return;
        _hp -= dmg;
        if (_hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Boom();
        GetComponent<Rigidbody2D>().gravityScale = 2;

        Controller.Died(this);
    }

    private void Boom()
    {
        var fire = Instantiate(fireEffect, transform);
        fire.transform.localScale = new Vector2(3f, 3f);
        Debug.Log("Booom!");
    }
}
