using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BotAScript : MonoBehaviour
{
    int[] fistPointOnVector = {0,0};
    int botCount = 0;
    public static BotAScript instance;
    public ToggleScpipt toggle1;
    public ToggleScpipt toggle2;
    public ToggleScpipt toggle3;
    public ToggleScpipt toggle4;
    public ToggleScpipt toggle5;
    public ToggleScpipt toggle6;
    public ToggleScpipt toggle7;
    public ToggleScpipt toggle8;
    public ToggleScpipt toggle9;

    private void Awake()
    {
        instance = this;
    }
    public void BotTurn(int x, int y)
    {
        botCount++;
        switch (botCount) {
            case 1 :
                WriteTheFirstTurn();
                if(WriteToggleScript.Instance.toggles[1,1] == 1)
                {
                    int rd = UnityEngine.Random.Range(1, 5);
                    switch(rd)
                    {
                        case 1 :
                            BotPressFor(1);
                            break;
                        case 2 :
                            BotPressFor(3);
                            break;
                        case 3 :
                            BotPressFor(7);
                            break;
                        case 4 :
                            BotPressFor(9);
                            break;
                    }  
                }
                else if(WriteToggleScript.Instance.toggles[0 ,2] == 1 || WriteToggleScript.Instance.toggles[2 ,2] == 1 || WriteToggleScript.Instance.toggles[0, 0] == 1 || WriteToggleScript.Instance.toggles[2, 0] == 1)
                {
                    BotPressFor(5);
                }
                else
                {
                    RandomOnFirstTurn();
                }
                break;
            case 2:
                OnSecondTurn();
                break;
        }
    }
    private void BotPress(int x,int y)
    {
        if (x == 0 && y == 2)
            toggle1.Bot(x, y);
        else if (x == 1 && y == 2)
            toggle2.Bot(x, y);
        else if (x == 2 && y == 2)
            toggle3.Bot(x, y);
        else if (x == 0 && y == 1)
            toggle4.Bot(x, y);
        else if (x == 1 && y == 1)
            toggle5.Bot(x, y);
        else if (x == 2 && y == 1)
            toggle6.Bot(x, y);
        else if (x == 0 && y == 0)
            toggle7.Bot(x, y);
        else if (x == 1 && y == 0)
            toggle8.Bot(x, y);
        else if (x == 2 && y == 0)
            toggle9.Bot(x, y);
        else
            toggle2.Bot(78, 5);

    }
    private void BotPressFor(int num)
    {
        if(num == 1) { toggle1.Bot(0, 2); }
        else if(num == 2) { toggle2.Bot(1, 2); }
        else if (num == 3) { toggle3.Bot(2, 2); }
        else if (num == 4) { toggle4.Bot(0, 1); }
        else if (num == 5) { toggle5.Bot(1, 1); }
        else if (num == 6) { toggle6.Bot(2, 1); }
        else if (num == 7) { toggle7.Bot(0, 0); }
        else if (num == 8) { toggle8.Bot(1, 0); }
        else if (num == 9) { toggle9.Bot(2, 0); }
    }
    private void RandomOnFirstTurn()
    {
        bool doTurned = false;
        ToggleScpipt[] togless = {toggle1,toggle2,toggle3,toggle4,toggle5,toggle6,toggle7,toggle8,toggle9};
        foreach(var randomToggle in togless)
        {
            int rd = UnityEngine.Random.Range(0, 9);
            if(rd == 4 && WriteToggleScript.Instance.toggles[randomToggle._togglePosX ,randomToggle._togglePosY] == 0)
            {
                doTurned = true;
                randomToggle.Bot(randomToggle._togglePosX ,randomToggle._togglePosY);
                break;
            }
        }
        if (!doTurned)
        {
            RandomOnFirstTurn();
        }
    }

    private void OnSecondTurn()
    {
        int[] point1 = {5,5};
        
        ToggleScpipt[] togless = { toggle1, toggle2, toggle3, toggle4, toggle5, toggle6, toggle7, toggle8, toggle9 };
        foreach (var e in togless)
        {
            if(WriteToggleScript.Instance.toggles[e._togglePosX,e._togglePosY] == 1)
            {
                if(e._togglePosX != fistPointOnVector[0] || e._togglePosY != fistPointOnVector[1])
                {
                    point1[0] = e._togglePosX;
                    point1[1] = e._togglePosY;
                }
            }
        }
        Debug.Log("start");
        int[] vector = { 0, 0 };
        vector[0] = point1[0] - fistPointOnVector[0];
        vector[1] = point1[1] - fistPointOnVector[1];
        vector[0] *= 2;
        vector[1] *= 2;
        int[] lastPoint = { fistPointOnVector[0] + vector[0], fistPointOnVector[1] + vector[1] };
        if(lastPoint[0] > 2 || lastPoint[1] > 2 || lastPoint[0] < 0 || lastPoint[1] < 0)
        {
            Debug.Log("start");
            int[] vector1 = { 0, 0 };
            vector1[0] = fistPointOnVector[0] - point1[0];
            vector1[1] = fistPointOnVector[1] - point1[1];
            vector1[0] *= 2;
            vector1[1] *= 2;
            int[] lastPoint1 = { point1[0] + vector1[0], point1[1] + vector1[1] };
            if(lastPoint1[0] > 2 || lastPoint1[1] > 2 || lastPoint1[0] < 0 || lastPoint1[1] < 0)
            {
                int[] sum = { 0, 0};
                sum[0] = fistPointOnVector[0] + point1[0];
                sum[1] = fistPointOnVector[1] + point1[1];
                sum[0] /= 2;
                sum[1] /= 2;
                if(WriteToggleScript.Instance.toggles[sum[0],sum[1]] != 2)
                {
                    BotPress(sum[0], sum[1]);
                }
                else
                {
                    RandomOnFirstTurn();
                }
            }
            else
            {
                if(WriteToggleScript.Instance.toggles[lastPoint1[0],lastPoint1[1]] != 2)
                {
                    BotPress(lastPoint1[0], lastPoint1[1]);
                }
                else
                {
                    RandomOnFirstTurn();
                }  
            }
        }
        else
        {
            if(WriteToggleScript.Instance.toggles[lastPoint[0],lastPoint[1]] != 2)
            {
                BotPress(lastPoint[0], lastPoint[1]);
            }
            else
            {
                RandomOnFirstTurn();
            }
        }
    }

    void WriteTheFirstTurn()
    {
        ToggleScpipt[] togless = { toggle1, toggle2, toggle3, toggle4, toggle5, toggle6, toggle7, toggle8, toggle9 };
       foreach(var i in togless )
       {
            if(WriteToggleScript.Instance.toggles[i._togglePosX,i._togglePosY] == 1)
            {
                fistPointOnVector[0] = i._togglePosX;
                fistPointOnVector[1] = i._togglePosY;
            }
       }
    }
    
}
