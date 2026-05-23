using System;
using System.Collections.Generic;
using UnityEngine;

public class BotAScript : MonoBehaviour
{
    public static BotAScript instance;

    // Масив для швидкого доступу до тоглів замість 9 окремих змінних у коді
    private ToggleScpipt[] allToggles;

    public ToggleScpipt toggle1;
    public ToggleScpipt toggle2;
    public ToggleScpipt toggle3;
    public ToggleScpipt toggle4;
    public ToggleScpipt toggle5;
    public ToggleScpipt toggle6;
    public ToggleScpipt toggle7;
    public ToggleScpipt toggle8;
    public ToggleScpipt toggle9;

    int botCount = 0;
    int[] fistPointOnVector = { 0, 0 };

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Ініціалізуємо масив для зручної роботи
        allToggles = new ToggleScpipt[] { toggle1, toggle2, toggle3, toggle4, toggle5, toggle6, toggle7, toggle8, toggle9 };
    }

    public void BotTurn(int x, int y)
    {
        botCount++;
        switch (botCount)
        {
            case 1:
                WriteTheFirstTurn();
                if (WriteToggleScript.Instance.toggles[1, 1] == 1)
                {
                    int rd = UnityEngine.Random.Range(1, 5);
                    switch (rd)
                    {
                        case 1: BotPressFor(1); break;
                        case 2: BotPressFor(3); break;
                        case 3: BotPressFor(7); break;
                        case 4: BotPressFor(9); break;
                    }
                }
                else if (WriteToggleScript.Instance.toggles[0, 2] == 1 || WriteToggleScript.Instance.toggles[2, 2] == 1 || WriteToggleScript.Instance.toggles[0, 0] == 1 || WriteToggleScript.Instance.toggles[2, 0] == 1)
                {
                    BotPressFor(5);
                }
                else
                {
                    MakeRandomMove();
                }
                break;

            case 2:
                OnSecondTurn();
                break;

            case 3:
            default: // Для третього і всіх наступних ходів
                OnAdvancedTurn();
                break;
        }
    }

    private void OnAdvancedTurn()
    {
        // 1. Намагаємося виграти (шукаємо лінію, де у бота вже 2 знаки, припустимо бот — це ID 2)
        Vector2Int winCell = FindWinningOrBlockingCell(2);
        if (winCell.x != -1)
        {
            BotPress(winCell.x, winCell.y);
            return;
        }

        // 2. Блокуємо гравця (шукаємо лінію, де у гравця 2 знаки, гравець — це ID 1)
        Vector2Int blockCell = FindWinningOrBlockingCell(1);
        if (blockCell.x != -1)
        {
            BotPress(blockCell.x, blockCell.y);
            return;
        }

        // 3. Якщо ніхто не перемагає на цьому ході, робимо випадковий безпечний хід
        MakeRandomMove();
    }

    // Метод шукає клітину для виграшу або блокування
    private Vector2Int FindWinningOrBlockingCell(int targetPlayerId)
    {
        // Всі 8 можливих ліній у хрестиках-нуликах (координати x, y трьох клітин)
        int[][,] lines = new int[][,]
        {
            // Горизонталі
            new int[,] {{0,0}, {1,0}, {2,0}},
            new int[,] {{0,1}, {1,1}, {2,1}},
            new int[,] {{0,2}, {1,2}, {2,2}},
            // Вертикалі
            new int[,] {{0,0}, {0,1}, {0,2}},
            new int[,] {{1,0}, {1,1}, {1,2}},
            new int[,] {{2,0}, {2,1}, {2,2}},
            // Діагоналі
            new int[,] {{0,0}, {1,1}, {2,2}},
            new int[,] {{0,2}, {1,1}, {2,0}}
        };

        foreach (var line in lines)
        {
            int targetCount = 0;
            int emptyCount = 0;
            Vector2Int emptyCell = new Vector2Int(-1, -1);

            for (int i = 0; i < 3; i++)
            {
                int px = line[i, 0];
                int py = line[i, 1];
                int cellValue = WriteToggleScript.Instance.toggles[px, py];

                if (cellValue == targetPlayerId)
                    targetCount++;
                else if (cellValue == 0) // Порожня клітина
                {
                    emptyCount++;
                    emptyCell = new Vector2Int(px, py);
                }
            }

            // Якщо в лінії дві потрібні фігури і одна порожня клітина — ми її знайшли!
            if (targetCount == 2 && emptyCount == 1)
            {
                return emptyCell; 
            }
        }

        return new Vector2Int(-1, -1); // Повертаємо прапорець, що нічого не знайдено
    }

    // Безпечний рандомний хід без рекурсії, яка викликає зависання
    private void MakeRandomMove()
    {
        List<ToggleScpipt> freeToggles = new List<ToggleScpipt>();

        foreach (var t in allToggles)
        {
            if (WriteToggleScript.Instance.toggles[t._togglePosX, t._togglePosY] == 0)
            {
                freeToggles.Add(t);
            }
        }

        if (freeToggles.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, freeToggles.Count);
            ToggleScpipt chosen = freeToggles[index];
            chosen.Bot(chosen._togglePosX, chosen._togglePosY);
        }
    }

    private void BotPress(int x, int y)
    {
        if (x == 0 && y == 2) toggle1.Bot(x, y);
        else if (x == 1 && y == 2) toggle2.Bot(x, y);
        else if (x == 2 && y == 2) toggle3.Bot(x, y);
        else if (x == 0 && y == 1) toggle4.Bot(x, y);
        else if (x == 1 && y == 1) toggle5.Bot(x, y);
        else if (x == 2 && y == 1) toggle6.Bot(x, y);
        else if (x == 0 && y == 0) toggle7.Bot(x, y);
        else if (x == 1 && y == 0) toggle8.Bot(x, y);
        else if (x == 2 && y == 0) toggle9.Bot(x, y);
    }

    private void BotPressFor(int num)
    {
        if (num == 1) toggle1.Bot(0, 2);
        else if (num == 2) toggle2.Bot(1, 2);
        else if (num == 3) toggle3.Bot(2, 2);
        else if (num == 4) toggle4.Bot(0, 1);
        else if (num == 5) toggle5.Bot(1, 1);
        else if (num == 6) toggle6.Bot(2, 1);
        else if (num == 7) toggle7.Bot(0, 0);
        else if (num == 8) toggle8.Bot(1, 0);
        else if (num == 9) toggle9.Bot(2, 0);
    }

    private void OnSecondTurn()
    {
        int[] point1 = { 5, 5 };
        foreach (var e in allToggles)
        {
            if (WriteToggleScript.Instance.toggles[e._togglePosX, e._togglePosY] == 1)
            {
                if (e._togglePosX != fistPointOnVector[0] || e._togglePosY != fistPointOnVector[1])
                {
                    point1[0] = e._togglePosX;
                    point1[1] = e._togglePosY;
                }
            }
        }

        int[] vector = { 0, 0 };
        vector[0] = point1[0] - fistPointOnVector[0];
        vector[1] = point1[1] - fistPointOnVector[1];
        vector[0] *= 2;
        vector[1] *= 2;
        int[] lastPoint = { fistPointOnVector[0] + vector[0], fistPointOnVector[1] + vector[1] };
        if (lastPoint[0] > 2 || lastPoint[1] > 2 || lastPoint[0] < 0 || lastPoint[1] < 0)
        {
            int[] vector1 = { 0, 0 };
            vector1[0] = fistPointOnVector[0] - point1[0];
            vector1[1] = fistPointOnVector[1] - point1[1];
            vector1[0] *= 2;
            vector1[1] *= 2;
            int[] lastPoint1 = { point1[0] + vector1[0], point1[1] + vector1[1] };
            if (lastPoint1[0] > 2 || lastPoint1[1] > 2 || lastPoint1[0] < 0 || lastPoint1[1] < 0)
            {
                int[] sum = { 0, 0 };
                sum[0] = fistPointOnVector[0] + point1[0];
                sum[1] = fistPointOnVector[1] + point1[1];
                sum[0] /= 2;
                sum[1] /= 2;
                if (WriteToggleScript.Instance.toggles[sum[0], sum[1]] != 2)
                {
                    BotPress(sum[0], sum[1]);
                }
                else
                {
                    MakeRandomMove();
                }
            }
            else
            {
                if (WriteToggleScript.Instance.toggles[lastPoint1[0], lastPoint1[1]] != 2)
                {
                    BotPress(lastPoint1[0], lastPoint1[1]);
                }
                else
                {
                    MakeRandomMove();
                }
            }
        }
        else
        {
            if (WriteToggleScript.Instance.toggles[lastPoint[0], lastPoint[1]] != 2)
            {
                BotPress(lastPoint[0], lastPoint[1]);
            }
            else
            {
                MakeRandomMove();
            }
        }
    }

    void WriteTheFirstTurn()
    {
        foreach (var i in allToggles)
        {
            if (WriteToggleScript.Instance.toggles[i._togglePosX, i._togglePosY] == 1)
            {
                fistPointOnVector[0] = i._togglePosX;
                fistPointOnVector[1] = i._togglePosY;
            }
        }
    }
}