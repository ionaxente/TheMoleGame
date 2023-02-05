using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dig : MonoBehaviour { 

    private bool _hasAnObjectToDestroy = false;
    private Collider2D _ObjectToDestroy;

    private float _lastTimeCheck = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_hasAnObjectToDestroy && (Time.unscaledTime - _lastTimeCheck >= 0.5))
        {
            _hasAnObjectToDestroy = false;
            _ObjectToDestroy = null;
        }
    }

    public bool destroyThatObject()
    {
        bool _result = false;
        if (_hasAnObjectToDestroy)
        {
            if(_ObjectToDestroy.tag == "Soil")
            {
                Soil _soil = _ObjectToDestroy.GetComponent<Soil>();
                Debug.Log("DestroySoil");
                _soil.Destroy();
                _hasAnObjectToDestroy = false;
                _result = true;
            }
        }
        return _result;
    }

    public bool isAnObjectToDestroy()
    {
        return _hasAnObjectToDestroy;
    }

    public Collider2D getObjectToDestroy()
    {
        return _ObjectToDestroy;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _hasAnObjectToDestroy = true;
        _lastTimeCheck = Time.unscaledTime;
        _ObjectToDestroy = collision;
    }
}
