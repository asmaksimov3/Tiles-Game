using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    //Показывает рекорд игрока
    void Start()
    {
        GetComponent<Text>().text = GameManager.GM.GetHighScore().ToString();
    }

    
}
