using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    public int GameTime = 10;
    public EndMenuHelper EndMenuHelper;

    public GameObject RubyPrefab;

    public Slider HealthSlider;

    public GameObject GoldPrefab;

    public GameObject[] MonstersPrefab;

    public Transform StartPosition;

    public Text GameTimeText;

    public Text PlayerGoldUI;
    public Text Rubytext;

    public Text TextHealth;

    public Text DamageText;

    public int PlayerGold;
    public int PlayerRuby;

    public int PlayerDamage = 10;

    public bool EndGame { get; set; }

    int _count;
    float _curentTime;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        SpawnMonster();
        InvokeRepeating("Timer",0,1);
    }
    void Timer()
    {
        _curentTime++;

        GameTimeText.text = (GameTime - _curentTime).ToString();
        if (_curentTime >= GameTime)
        {
            Time.timeScale = 0;
            EndGame = true;           
            EndMenuHelper.gameObject.SetActive(true);
            EndMenuHelper.ShowEndGame(PlayerGold);
        }
    }

        // Update is called once per frame
        void Update()
    {

        PlayerGoldUI.text = PlayerGold.ToString();
        DamageText.text = PlayerDamage.ToString();
        Rubytext.text = PlayerRuby.ToString();

    }

    public void TakeRuby(int ruby)
    {
        PlayerRuby += ruby;
        GameObject rubyObj = Instantiate(RubyPrefab) as GameObject;
        Destroy(rubyObj, 3);
    }
    public void TakeGold(int gold)
    {
        PlayerGold += gold;

        GameObject gameObj = Instantiate(GoldPrefab) as GameObject;
        Destroy(gameObj, 2);

        SpawnMonster();
    }
    public void SpawnMonster()
    {
        _count++;
        int randomMaxValue = _count / 2 + 1;
        if (randomMaxValue >= MonstersPrefab.Length)
        {
            randomMaxValue = MonstersPrefab.Length;
        }

        int index = Random.Range(0, randomMaxValue);

        GameObject monterObj = Instantiate(MonstersPrefab[index]) 
            as GameObject;
        monterObj.transform.position = StartPosition.position;

       

    }


}
