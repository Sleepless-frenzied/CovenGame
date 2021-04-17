using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class TipsManager : MonoBehaviour
{
    [SerializeField] private List<string> Tips = new List<string>();
    List<string> tmp = new List<string>();
    private int _index = 0;
    private GameObject scene;
    private Random rand = new Random();

    public TMP_Text CurrentTip;
    // Start is called before the first frame update
    // Update is called once per frame
    [ReadOnly] public  float Timer;
    public float test;
    
    void Start()
    {
        CurrentTip.text = "Handy Tips: "+Tips[_index];
        Timer = test;
    }

    void Update()
    {
        //if (scene.activeSelf)
        {
            if (Timer > 0)
            {
                Timer -= Time.deltaTime;
            }
            else
            {
                /*if (_index >= Tips.Count-1)
                {
                    _index = 0;
                }
                else
                {
                    _index += 1;
                }*/
                if (tmp.Count == 0)
                {
                    tmp = new List<string>(Tips);
                }
                _index = rand.Next(0,tmp.Count);
                CurrentTip.text = "Handy Tips: "+tmp[_index];
                tmp.RemoveAt(_index);
                Timer = test;
            }
        }
    }
}
