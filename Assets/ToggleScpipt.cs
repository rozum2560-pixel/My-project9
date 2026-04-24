using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScpipt : MonoBehaviour
{
    private Toggle toggle;
    public int _togglePosX;
    public int _togglePosY;
    [SerializeField] Sprite _sprite;
    [SerializeField] Sprite sprite2;
    [SerializeField] Image _checkmark;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    public void Player()
    {
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
    public void Bot(){
        _checkmark.sprite = sprite2;
        toggle.interactable = false;
    }

    
}
