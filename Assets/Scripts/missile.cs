using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 5)
            Destroy(this);
    }
}
