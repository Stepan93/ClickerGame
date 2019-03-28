using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpButtonHelper : MonoBehaviour
{
    public bool IsRuby;

    public bool IsHero;
    public GameObject UpPrefab;
    public GameObject HeroPrefab;

    public Text DamageText;
    public Text PriceText;
    public Image IconImage;


    public int Damage = 15;
    public int Price = 100;
    GameHelper _gameHelper;
    // Start is called before the first frame update
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();

        DamageText.text = "+" + Damage.ToString();
        PriceText.text = Price.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpClick()
    {
        if (!IsRuby && _gameHelper.PlayerGold >= Price ||
            IsRuby && _gameHelper.PlayerRuby >= Price)
        {
            if (!IsRuby)
            {
                _gameHelper.PlayerGold -= Price;
            }  
            else
            {
                _gameHelper.PlayerRuby -= Price;
            }

            if(IsHero == false)
            {
                _gameHelper.PlayerDamage += Damage;
            }
            else
            {
                GameObject hero = Instantiate(HeroPrefab) as GameObject;
                Vector3 heroPos = new Vector3(
                    Random.Range(3.0f, 7.0f),
                    Random.Range(-2.2f, -1.3f),
                    -0.3f);
                hero.transform.position = heroPos;
            }
           

            GameObject upEffect = Instantiate(UpPrefab) as GameObject;

            Transform canvas = GameObject.Find("Canvas").transform;
            upEffect.transform.SetParent(canvas);
            upEffect.GetComponent<Image>().sprite = IconImage.sprite;

            Destroy(upEffect,1);
            if(IsHero == false)
            {
                Destroy(gameObject);
            }
                
        }
    }
}
