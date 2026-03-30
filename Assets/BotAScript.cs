using UnityEngine;
using UnityEngine.UI;

public class BotAScript : MonoBehaviour
{
    public static BotAScript instance;

    private void Awake()
    {
        instance = this;
    }
    public void BotTurn(int x, int y)
    {
        
        try
        {
            try { WriteToggleScript.Instance.WriteToggle(0, y, false); }
            catch { try { WriteToggleScript.Instance.WriteToggle(2, y, false); } catch { } }
        }
        catch
        {
            foreach(int toggle in WriteToggleScript.Instance.toggles)
            {
                if(toggle == 0) {WriteToggleScript.Instance.WriteToggle(toggle,toggle,false);break;  }
            }
        }
    }
}
