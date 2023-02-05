using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _EnergyPlayerOne;

    [SerializeField]
    private Text _EnergyPlayerTwo;

    [SerializeField]
    private Text _InfoText;

    private GameManager _GameManager;

    private float _lastTimeActive = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (_InfoText)
            _InfoText.gameObject.SetActive(false);
        if (!_EnergyPlayerOne)
        {
            Debug.Log("Not Energy Text attached");
        }
        else {
            _EnergyPlayerOne.text = "Energy: 10";
        }

        if (!_EnergyPlayerTwo)
        {
            Debug.Log("Not Energy Text attached");
        }
        else
        {
            _EnergyPlayerTwo.text = "Energy: 10";
        }

        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void setEnergyPlayerOne(uint _Energy)
    {
        this._EnergyPlayerOne.text = "Energy: " + _Energy;
    }

    public void setEnergyPlayerTwo(uint _Energy)
    {
        this._EnergyPlayerTwo.text = "Energy: " + _Energy;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.unscaledTime - _lastTimeActive >= 5)
        {
            _InfoText.gameObject.SetActive(false);
        }
    }

    public void GameOverPlayer(uint Player)
    {
        _InfoText.text = "Game Over Player " + Player;
        _InfoText.gameObject.SetActive(true);
        _lastTimeActive = Time.unscaledTime;
    }

    public void GameWinPlayer(uint Player)
    {
        _InfoText.text = "Game Win Player " + Player;
        _InfoText.gameObject.SetActive(true);
        _lastTimeActive = Time.unscaledTime;
    }
}
