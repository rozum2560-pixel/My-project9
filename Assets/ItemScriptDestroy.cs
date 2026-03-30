using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class ItemScriptDestroy : MonoBehaviour
{
    
   

    void OnMouseDown()
    { 
        ItemScript.instance._inInventory = true;
        Destroy(gameObject);
    }
}
