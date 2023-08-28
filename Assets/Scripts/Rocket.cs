using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update


    private void FixedUpdate()
    {
        Rigidbody2D b = GetComponent<Rigidbody2D>();
        b.AddForce(transform.up * 20, ForceMode2D.Force);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        collision.gameObject.GetComponent<Enemy>().ApplyDamage(1000);
        Destroy(gameObject);
        
        //_enimiesController.GetComponent<Enimies>().removeEnemy(collision.gameObject);
      //  Destroy(collision.gameObject, 1f);

    }
}
