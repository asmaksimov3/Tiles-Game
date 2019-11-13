using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //Обновляет каждый кадр количество набранных очков
    void Update()
    {
        GetComponent<Text>().text = Manager3x3.manager3x3.score.ToString();
      
    }
}
