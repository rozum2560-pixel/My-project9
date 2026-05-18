using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScpipt : MonoBehaviour
{
    public Toggle toggle;
    public int _togglePosX;
    public int _togglePosY;
    public Sprite _sprite;
    public Sprite sprite2;
    public Image _checkmark;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    public void Player()
    {
        Debug.Log(_togglePosX + " " + _togglePosY);
        _checkmark.sprite = _sprite;
        toggle.interactable = false;
        bool isEmpty = WriteToggleScript.Instance.WriteToggle(_togglePosX,_togglePosY, true);
        if (!isEmpty) 
        {
            Debug.Log("You press in used window,try agin");
        }
        else{
            BotAScript.instance.BotTurn(_togglePosX,_togglePosY);
        }
    }
    public void Bot(int x,int y)
    {
        _checkmark.sprite = sprite2;
        toggle.SetIsOnWithoutNotify(true);
        toggle.interactable = false;
        WriteToggleScript.Instance.WriteToggle(x, y, false);
    }
    

    
}
