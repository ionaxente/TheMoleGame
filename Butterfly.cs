using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    private float _speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 _rotation = new Vector3(0, 0, Random.Range(-35f, 35f));
        transform.Translate(new Vector3(Random.Range(-1.0f, 1.0f), 0, 0));
        transform.Rotate(_rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Random.Range(-1.0f, 1.0f), 1, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
        if (transform.position.y > 5.5f)
            Destroy(this.gameObject);
    }
}
