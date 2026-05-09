using UnityEngine;
using UnityEngine.UI;

public class BotAScript : MonoBehaviour
{
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
        
        try
        {
            if (WriteToggleScript.Instance.toggles[0,y] == 0) { BotPress(0, y); }
            else { if (WriteToggleScript.Instance.toggles[2,y] == 0) { BotPress(2, y); } else { } }
        }
        catch
        {
            foreach(int toggle in WriteToggleScript.Instance.toggles)
            {
                if(toggle == 0) {BotPressFor(toggle);break;  }
                else { Debug.Log("The position" +  toggle); }
            }
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
}
