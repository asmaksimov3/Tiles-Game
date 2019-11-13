using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    //Статический экземпляр GameManager,для облегчения доступа к нему
    static public GameManager GM;
    //Инициализирует статический экземпляр GameManager и запрещает уничтожение его при переходе на новую сцену
    public void Awake()
    {
        GM = this;
        DontDestroyOnLoad(this.gameObject);

    }
    //Загружает уровень 3x3
    public void StartGame()
    {
        SceneManager.LoadScene("3x3");
    }
    //Возвращает максимальный набранный результат
    public int GetHighScore()
    {
        int a;
        int.TryParse(File.ReadAllLines("Assets/Resources/Score.txt")[0],out a);
        return a;

    }
    //Сохраняет результат,если игрок побил свой рекорд
    public void SaveHighScore(int HighScore)
    {
        FileStream fs = new FileStream("Assets/Resources/Score.txt", FileMode.Create);
        StreamWriter sW = new StreamWriter(fs);
        sW.WriteLine(HighScore.ToString());
        sW.Close();
    }
    

}
