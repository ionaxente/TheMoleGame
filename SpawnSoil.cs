using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSoil : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject _Soil;

    private float LeftLimit = -8.5f;
    private float RightLimit = 8.5f;
    private float UpLimit = 2.0f;
    private float DownLimit = -3f;

    void Start()
    {
        //Debug.Log("Instantiate _soil");
        for (float i = DownLimit; i <= UpLimit; i += 1f)
        {
            for(float j = LeftLimit; j <= RightLimit; j += 1f)
            {
                GameObject _soil = Instantiate(_Soil, new Vector3(j,i,0), Quaternion.identity);
                _soil.transform.parent = transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
