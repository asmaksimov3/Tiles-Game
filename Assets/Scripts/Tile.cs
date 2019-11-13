using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //id плитки
    public int id;

    //Компонент,показывающий id плитки
    public TextMesh textmesh;
    
    //Инициализирует textmesh компонентом дочеренего объекта,отображающего цифры
    public void Awake()
    {
        textmesh = GetComponentInChildren<TextMesh>();
    }

    //Обновляет id и textmesh после того,как меняется её номер
    public void UpdateTile(int id)
    {
        if(textmesh==null)
            textmesh = GetComponentInChildren<TextMesh>();
        this.id = id;
        textmesh.text = id.ToString();
    }

    //Событие,которое вызывается,когда на плитку нажимают.Отправляет в Manager3x3 номер своей плитки.
    //Менеджер проверяет её корреатность.
    private void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag("Manager3x3").GetComponent<Manager3x3>().CheckCorrect(id, this);
    }

}
