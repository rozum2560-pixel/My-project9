using System;
using UnityEngine;
using UnityEngine.UI;

public class WriteToggleScript : MonoBehaviour
{
    public static WriteToggleScript Instance;
    [SerializeField] private Text text;
    [SerializeField] private GameObject @object;

        public int[,] toggles =
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };

    void Awake() {Instance = this; }
    void Win(string who)
    {
        @object.SetActive(false);
        if (who == "Player")
            text.text = "You win";
        else if (who == "Bot")
            text.text = "You lose";
        restartScr.rest.image.enabled = true;
    }
    public bool WriteToggle(int x,int y,bool doPLayer)
    {
        if (toggles[x,y] == 0)
        {
            if (doPLayer)
            {
                toggles[x, y] = 1;
            }
            else
            {
                toggles[x, y] = 2;
            }
            bool a = WinPlayer();
            if (!a)
                WinBot();
            return true;
        }
        else
            return false;
    }

    bool WinPlayer()
    {
        if (toggles[0, 2] == 1 && toggles[1, 2] == 1 && toggles[2, 2] == 1)
        { Debug.Log("You win"); Win("Player"); return true; }
        else if (toggles[2, 2] == 1 && toggles[2, 1] == 1 && toggles[2, 0] == 1)
        { Debug.Log("You win"); Win("Player"); return true; }
        else if (toggles[0, 0] == 1 && toggles[1, 0] == 1 && toggles[2, 0] == 1)
        { Debug.Log("You win"); Win("Player"); return true; }
        else if (toggles[0, 0] == 1 && toggles[0, 1] == 1 && toggles[0, 2] == 1)
        { Debug.Log("You win"); Win("Player"); return true; }
        else if (toggles[1, 2] == 1 && toggles[1, 1] == 1 && toggles[1, 0] == 1)
        { Debug.Log("You win"); Win("Player"); return true; }
        else if (toggles[0, 1] == 1 && toggles[1, 1] == 1 && toggles[2, 1] == 1)
        { Debug.Log("You win"); Win("Player"); return true; }
        else if (toggles[0, 2] == 1 && toggles[1, 1] == 1 && toggles[2, 0] == 1)
        { Debug.Log("You win"); Win("Player"); return true; }
        else if (toggles[0, 0] == 1 && toggles[1, 1] == 1 && toggles[2, 2] == 1)
        { Debug.Log("You win"); Win("Player"); return true; }
        return false;
    }

    void WinBot()
    {
        if (toggles[0, 2] == 2 && toggles[1, 2] == 2 && toggles[2, 2] == 2)
        { Debug.Log("You lose"); Win("Bot"); }
        else if (toggles[2, 2] == 2 && toggles[2, 1] == 2 && toggles[2, 0] == 2)
        { Debug.Log("You lose"); Win("Bot"); }
        else if (toggles[0, 0] == 2 && toggles[1, 0] == 2 && toggles[2, 0] == 2)
        { Debug.Log("You lose"); Win("Bot"); }
        else if (toggles[0, 0] == 2 && toggles[0, 1] == 2 && toggles[0, 2] == 2)
        { Debug.Log("You lose"); Win("Bot"); }
        else if (toggles[1, 2] == 2 && toggles[1, 1] == 2 && toggles[1, 0] == 2)
        { Debug.Log("You lose"); Win("Bot"); }
        else if (toggles[0, 1] == 2 && toggles[1, 1] == 2 && toggles[2, 1] == 2)
        { Debug.Log("You lose"); Win("Bot"); }
        else if (toggles[0, 2] == 2 && toggles[1, 1] == 2 && toggles[2, 0] == 2)
        { Debug.Log("You lose"); Win("Bot"); }
        else if (toggles[0, 0] == 2 && toggles[1, 1] == 2 && toggles[2, 2] == 2)
        { Debug.Log("You lose"); Win("Bot"); }
    }
}
