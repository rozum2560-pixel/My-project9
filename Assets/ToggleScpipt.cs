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

    public void OnValueChanged(bool doPlayer)
    {
        if (doPlayer) { _checkmark.sprite = _sprite; }
        else { _checkmark.sprite = sprite2; }
        toggle.isOn = true;
        toggle.interactable = false;
        WriteToggleScript.Instance.WriteToggle(_togglePosX, _togglePosY, doPlayer);
        BotAScript.instance.BotTurn(_togglePosX, _togglePosY);
    }
}
