using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject _rocketPrefub;
    Rigidbody2D ya;
    [SerializeField]
    public GameObject _firePozition;
    [SerializeField]
    private Transform _bashnya;

    void Start()
    {
        ya = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Ray2D rai = new Ray2D(_firePozition.transform.position, Input.mousePosition);
        //Debug.DrawLine(_firePozition.transform.position, Input.mousePosition);
        float v = Input.GetAxis("Mouse X");
        if (v !=0)
        {
            _bashnya.Rotate(new Vector3(0, 0, -v*2));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            shoot();
        }
    }

    private float lastShotTime = 0;
    private void shoot()
    {
        if (Time.realtimeSinceStartup - lastShotTime < .3f)
            return;
        lastShotTime = Time.realtimeSinceStartup;

        GameObject gameObject1 = Instantiate(_rocketPrefub, _firePozition.transform.position, _firePozition.transform.rotation);
        Destroy(gameObject1, 3f);
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {

        float v = Input.GetAxis("Horizontal") * 5;
        ya.AddForce(new Vector2(v, 0));
    }
}
