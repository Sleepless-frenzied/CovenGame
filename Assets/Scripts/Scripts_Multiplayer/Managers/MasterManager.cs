using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Singeltons / MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{

    [SerializeField]
    private GameSettings _gamesettings;

    public static GameSettings GameSettings { get { return Instance._gamesettings; } } // j'ai juste suivi le tuto DON'T TOUCH



}
