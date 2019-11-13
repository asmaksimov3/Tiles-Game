using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager3x3 : MonoBehaviour
{
    //Статический экземпляр менеджера для облегчения доступа к нему
    public static Manager3x3 manager3x3;

    //Счётчик таймера
    public float timer;

    //Количество набранных очков
    public int score;

    //Количесвто пройденных уровней для подсчёта очков
    int levelpassed;

    //Параметр,показывающий,началась ли игра
    public bool gamebegun=false;

    //Массив,который хранит в себе все плитки
    [SerializeField] Tile[] tiles;

    //Объект,на котором лежат все плитки,облегчает отключене и включение доски
    [SerializeField] GameObject board;

    //Номер,который должен быть на следующей правильной плитке
    int nextcorrect;

    //Объект,облегчающий включение и отключение GameUI
    [SerializeField] GameObject GameUI;

    //Объект,облегчающий включение и отключение LoseUI
    [SerializeField] GameObject LoseUI;

    //Текст с поздравлением,если игрок побил свой рекорд
    [SerializeField] Text Winner;

    //Панель с текстом,на которой отображаются очки,которые набрал игрок
    [SerializeField] Text EndScore;
    
    //Инициализрует статический экземпляр менеджера
    public void Start()
    {
        manager3x3 = this;
    }

    //Метод,начинающий игру.Вызывается полсе окончания обратного таймера или после нажатия на конпку рестарт.
    //Возвращает параметрам начальные значения,перемешивает плитки,включает UI игры и включает доску с плитками.
    public void StartGame()
    {
        GameUI.SetActive(true);
        LoseUI.SetActive(false);
        gamebegun = true;
        timer = 5;
        score = 0;
        levelpassed = 0;
        nextcorrect = 1;
        Shuffle();
        board.SetActive(true);
        ShowAll();
    }

    //Обновляет таймер после закрытия игроком всех плиток
    public void updateTimer()
    {
        timer += 4;
    }

    //Обновляет количество очков,после закрытия игроком всех плиток
    public void updateScore()
    {
        score+=++levelpassed;
    }

    //Вызывается после окончания таймера,Выключает доску и GameUI,включает LoseUI.
    //Если игрок побил свой рекорд,то сохраняет результат в Score.txt в папке Assets/Resources
    public void Lose()
    {
        gamebegun = false;
        board.SetActive(false);
        GameUI.gameObject.SetActive(false);
        LoseUI.gameObject.SetActive(true);
        EndScore.text = score.ToString();
        if (score > GameManager.GM.GetHighScore())
        {
            Winner.gameObject.SetActive(true);
            GameManager.GM.SaveHighScore(score);
        }
        else
            Winner.gameObject.SetActive(false);
    }

    //Если игра идёт,то обновляет каждый кадр таймер,проверяет,закрыл ли игрок все плитки.
    //Если таймер закончился,то вызывает Lose(),завершающий игру.
    public void Update()
    {
        if (gamebegun)
        {
            if (nextcorrect == 10)
                UpdateLevel();
            if (timer <= 0)
                Lose();
            timer -= Time.deltaTime;
        }
    }

    //Обновляет очки,таймер,перемешивает плитки,вновь показывает все плитки после того,как игрок закрыл их все.
    public void UpdateLevel()
    {
        updateScore();
        updateTimer();
        Shuffle();
        ShowAll();
        nextcorrect = 1;
        
    }

    //Перемешивает плитки,а именно их id.Создаётся массив из элементов 1..9 и делается 100 перестановок.
    public void Shuffle()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        System.Random rnd = new System.Random();
        for (int i = 0; i < 100; i++)
        {
            int first = rnd.Next(0, 9);
            int second;
            do
            {
                second = rnd.Next(0, 9);
            }while(second == first);
            int k = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = k;
        }
        for (int i = 0; i < 9; i++)
            tiles[i].UpdateTile(numbers[i]);
    }

    //Включает все плитки(когда игрок нажимает на правильную плитку,те исчезают)
    public void ShowAll()
    {
        for (int i = 0; i < 9; i++)
            tiles[i].gameObject.SetActive(true);
    }

    //Проверяет,правильная ли плитка была нажата,если правильная,то выключает её и обновляет номер следующей правильной плитки.
    public void CheckCorrect(int id,Tile tile)
    {
        if(id==nextcorrect)
        {
            tile.gameObject.SetActive(false);
            nextcorrect++;
        }
    }
}
