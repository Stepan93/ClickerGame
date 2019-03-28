using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHelper : MonoBehaviour
{
    public int RubyChanse;

    public int MaxHealth = 100;
    public int Health = 100;
    public int Gold = 90;

    bool _isDead;

    GameHelper _gameHelper;
    // Start is called before the first frame update
    void Start()
    {

        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
        _gameHelper.HealthSlider.maxValue = MaxHealth;
        _gameHelper.HealthSlider.value = MaxHealth;
        _gameHelper.TextHealth.text = MaxHealth.ToString();
       


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetHit(int damage)
    {
        if (_isDead)
        {
            return;
        }
        int health = Health - damage;

        if (health <=0)
        {
            _isDead = true;
            _gameHelper.TakeGold(Gold);

            int random = Random.Range(0, 100);
            if (random < RubyChanse)
                _gameHelper.TakeRuby(1);

            Destroy(gameObject);
        }
        GetComponent<Animator>().SetTrigger("Hit");
        Health = health;

        _gameHelper.HealthSlider.value = Health;
        _gameHelper.TextHealth.text = Health.ToString();
    

        //Debug.Log("Health = " + Health);
    }
}
