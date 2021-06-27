using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableSlotManager : MonoBehaviour
{
    #region Singleton

    public static ConsumableSlotManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("");
            return;
        }

        instance = this;
        
    }

    #endregion
    // Start is called before the first frame update
    public ConsumableSlot[] racc;
    void Start()
    {
        racc = GetComponentsInChildren<ConsumableSlot>();
        Debug.Log(racc.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (racc[0].Item != null &&Input.GetKeyDown(KeyCode.K))
        {
            dis(0);
        }

        if (racc[1].Item != null && Input.GetKeyDown(KeyCode.L))
        {
            dis(1);
        }
        if (racc[2].Item != null && Input.GetKeyDown(KeyCode.M))
        {
            dis(2);
        }
        
    }


    public void dis(int i)
    {
        racc[i].Item.Use();
        racc[i].Item = null;
        racc[i].icon.sprite = null;
        racc[i].icon.enabled = false;
    }
}
