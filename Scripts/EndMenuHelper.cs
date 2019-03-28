using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenuHelper : MonoBehaviour
{
    public Text MyGold;
    public Text RecordText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowEndGame(int gold)
    {
        MyGold.text = gold.ToString();

        if(Setting.GoldRecord<= gold)
        {
            Setting.GoldRecord = gold;
        }
        RecordText.text = Setting.GoldRecord.ToString(); 
    }
    public void ButtonRestartClick()
    {
        SceneManager.LoadScene("Main");
    }
}
