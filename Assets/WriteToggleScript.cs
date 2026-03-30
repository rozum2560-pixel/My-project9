using System;
using UnityEngine;

public class WriteToggleScript : MonoBehaviour
{
    public static WriteToggleScript Instance;

        public int[,] toggles =
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };

    void Awake() {Instance = this; }
    public void WriteToggle(int x,int y,bool doPLayer)
    {

            if (doPLayer)
                toggles[x, y] = 1;
            else
                toggles[x, y] = 2;
        
      
        WinPlayer();
        WinBot();
    }

    void WinPlayer()
    {
        Debug.Log(toggles.Length);
        if (toggles[0, 2] == 1 && toggles[1, 2] == 1 && toggles[2, 2] == 1)
            Debug.Log("You win");
        else if (toggles[2, 2] == 1 && toggles[2, 1] == 1 && toggles[2, 0] == 1)
            Debug.Log("You win");
        else if (toggles[0, 0] == 1 && toggles[1, 0] == 1 && toggles[2, 0] == 1)
            Debug.Log("You win");
        else if (toggles[0, 0] == 1 && toggles[0, 1] == 1 && toggles[0, 2] == 1)
            Debug.Log("You win");
        else if (toggles[2, 0] == 1 && toggles[2, 1] == 1 && toggles[2, 2] == 1)
            Debug.Log("You win");
        else if (toggles[0, 1] == 1 && toggles[1, 1] == 1 && toggles[2, 1] == 1)
            Debug.Log("You win");
        else if (toggles[0, 2] == 1 && toggles[1, 1] == 1 && toggles[2, 0] == 1)
            Debug.Log("You win");
        else if (toggles[0, 0] == 1 && toggles[1, 1] == 1 && toggles[2, 2] == 1)
            Debug.Log("You win");
    }

    void WinBot()
    {
        if (toggles[0, 2] == 2 && toggles[1, 2] == 2 && toggles[2, 2] == 2)
            Debug.Log("You lose");
        else if (toggles[2, 2] == 2 && toggles[2, 1] == 2 && toggles[2, 0] == 2)
            Debug.Log("You lose");
        else if (toggles[0, 0] == 2 && toggles[1, 0] == 2 && toggles[2, 0] == 2)
            Debug.Log("You lose");
        else if (toggles[0, 0] == 2 && toggles[0, 1] == 2 && toggles[0, 2] == 2)
            Debug.Log("You lose");
        else if (toggles[2, 0] == 2 && toggles[2, 1] == 2 && toggles[2, 2] == 2)
            Debug.Log("You lose");
        else if (toggles[0, 1] == 2 && toggles[1, 1] == 2 && toggles[2, 1] == 2)
            Debug.Log("You lose");
        else if (toggles[0, 2] == 2 && toggles[1, 1] == 2 && toggles[2, 0] == 2)
            Debug.Log("You lose");
        else if (toggles[0, 0] == 2 && toggles[1, 1] == 2 && toggles[2, 2] == 2)
            Debug.Log("You lose");
    }
}
