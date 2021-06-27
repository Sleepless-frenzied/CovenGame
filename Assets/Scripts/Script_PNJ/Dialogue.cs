using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    public Occupation occupation;
    
    
    [TextArea(3,10)]
    public string[] sentences;
    
}

public enum Occupation
{
    Chômeur,
    QuestGiver,
    ShopKeeper,
    GrosTardos
}
