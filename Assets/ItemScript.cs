using UnityEngine;
using System;

public  class ItemScript : MonoBehaviour
{
    public static ItemScript instance;
    public bool _inInventory;
    public GameObject _clone;
    public GameObject _Camera;


    void Start()
    {
        _inInventory = false;
        instance = this;
    }

    void Update()

    {
        _clone.SetActive(_inInventory);
        if (Input.GetKeyUp(KeyCode.Q) && _inInventory)
        {
            GameObject _ob = Instantiate(_clone, _clone.transform);
            _ob.transform.SetParent(null);
            _ob.AddComponent<Rigidbody>();
            Debug.Log("You have a item");
            Rigidbody rigidbody = _ob.GetComponent<Rigidbody>();
            rigidbody.AddForce(_Camera .transform.forward * 7, ForceMode.Impulse);
            _inInventory = false;
            _ob.AddComponent<ItemScriptDestroy>();
        }
        if (Input.GetKeyUp(KeyCode.E) && _inInventory)
        {
            GameObject _ob = Instantiate(_clone, _clone.transform);
            _ob.transform.SetParent(null);
            _ob.AddComponent<Rigidbody>();
            Debug.Log("You have a item");
            Rigidbody rigidbody = _ob.GetComponent<Rigidbody>();
            rigidbody.AddForce(_Camera.transform.forward * 1700, ForceMode.Force);
            _inInventory = false;
            _ob.AddComponent<ItemScriptDestroy>();
        }
        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E) && !_inInventory)
            Debug.Log("You not have this item");
            

    }
}
