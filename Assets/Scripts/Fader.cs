using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    //Простой фейдер,который каждый кадр становится более прозрачным,после того.как он полностью станет прозрачным уничтожается.
    void Update()
    {
        GetComponent<Image>().color = new Color(0,0,0, GetComponent<Image>().color.a-0.01f);
        if (GetComponent<Image>().color.a <= 0)
            Destroy(this.gameObject);
    }
}
