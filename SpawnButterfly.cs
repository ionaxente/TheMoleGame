using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButterfly : MonoBehaviour
{
    [SerializeField]
    private GameObject _Butterflyes;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(taskForGenerateButterflyes());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator taskForGenerateButterflyes()
    {
        while(true)
        {
            if (_Butterflyes)
                Instantiate(_Butterflyes);
            yield return new WaitForSeconds(5);
        }
    }
}
