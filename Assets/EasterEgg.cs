using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class EasterEgg : MonoBehaviour
{
    // Start is called before the first frame update
    private readonly KeyCode[] _code = new[] {KeyCode.S, KeyCode.L,KeyCode.E,KeyCode.E,KeyCode.P};
    private int _index = 0;
    private bool _yeay = false;
    [FormerlySerializedAs("Secret")] public GameObject secret;

    void Update()
    {
        
        if (!_yeay)
        {
            if (_index == _code.Length)
            {
                secret.SetActive(true);
                _yeay = true;
            }
            if (!Input.anyKeyDown) return;
            if (Input.GetKeyDown(_code[_index]))
            {
                _index += 1;
            }
            else 
            { 
                _index = 0;
            }
        }
    }
}
