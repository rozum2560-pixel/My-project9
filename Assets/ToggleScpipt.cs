using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScpipt : MonoBehaviour
{
    private Toggle toggle;
    private isPlayerDoScript isPlayerDoScript;
    public int _togglePosX;
    public int _togglePosY;
    [SerializeField] Sprite _sprite;
    [SerializeField] Sprite sprite2;
    [SerializeField] Image _checkmark;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        toggle = GetComponent<Toggle>();
        isPlayerDoScript = GetComponentInChildren<isPlayerDoScript>();
    }

    public void OnValueChanged()
    {
        Debug.Log("toggle was pressed");
        toggle.interactable = false;
        enumerator();
        if (isPlayerDoScript) 
        {
            _checkmark.sprite = _sprite;
            toggle.isOn = true;
            WriteToggleScript.Instance.WriteToggle(_togglePosX, _togglePosY, true);
        }
    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
