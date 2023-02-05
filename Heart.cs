using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Random.Range(-1.0f, 1.0f), 1, 0);
        transform.Translate(direction  * Time.deltaTime);
        if (transform.position.y > 5.5f)
            Destroy(this.gameObject);
    }
}
