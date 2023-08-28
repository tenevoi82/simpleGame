using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    private int _enemyCount = 5;

    [SerializeField]
    private GameObject _enemyPrefub;

    [SerializeField]
    private List<GameObject> _enemies;

    // Start is called before the first frame update


    void Start()
    {
        _enemies = new List<GameObject>();
        for (int i = 0; i < _enemyCount; i++)
        {
            CreateNewEnemy();
        }
    }

    private void CreateNewEnemy()
    {
        var newEnemy = Instantiate(_enemyPrefub, gameObject.transform);
        newEnemy.GetComponent<Enemy>().Controller = this;
        newEnemy.GetComponent<Enemy>()._hp = 200;

        newEnemy.transform.position = new Vector2(13, UnityEngine.Random.Range(2f, 5f));

        float randomScale = UnityEngine.Random.Range(.6f, 1f);
        newEnemy.transform.localScale = new Vector2(randomScale, randomScale);


        var rb = newEnemy.GetComponent<Rigidbody2D>();
        float newspeed = UnityEngine.Random.Range(1f, 5f);
        int r = UnityEngine.Random.Range(0, 100);
        newspeed = r < 50 ? newspeed : (newspeed * -1);
        rb.velocity = new Vector2(newspeed, 0);
        _enemies.Add(newEnemy);
    }

    internal void Died(Enemy enemy)
    {
        _enemies.Remove(enemy.gameObject);
        Destroy(enemy.gameObject, 3f);
        CreateNewEnemy();
    }

    public void removeEnemy(GameObject gameObject)
    {
        Debug.Log(_enemies.Count);
        _enemies.Remove(gameObject);


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        foreach (var e in _enemies)
        {
            if (e == null)
                continue;
            if (Math.Abs(e.transform.position.x) > 13)
            {
                var rb = e.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(rb.velocity.x * -1, 0);
            }
        }
    }
}
