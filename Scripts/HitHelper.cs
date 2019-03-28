using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHelper : MonoBehaviour
{
    GameHelper _gameHelper;
    PlayerHelper _playerHelper;
    // Start is called before the first frame update
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
        _playerHelper = GameObject.FindObjectOfType<PlayerHelper>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        Debug.Log("OnMouseDown()");
        if (_gameHelper.EndGame)
            return;
        GetComponent<Animator>().SetTrigger("Hit");

        GetComponent<HealthHelper>().GetHit(_gameHelper.PlayerDamage);

        _playerHelper.RunAttack();
    }
}
