using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   //Каждый кадр отображает информацию о том,сколько осталось времени в правильном формате(Две точки после запятой или просто 0)
    void Update()
    {
        if (Manager3x3.manager3x3.timer.ToString().Length > 4)
            GetComponent<Text>().text = Manager3x3.manager3x3.timer.ToString().Substring(0, 4);
        else
            GetComponent<Text>().text = Manager3x3.manager3x3.timer.ToString();

    }
}
