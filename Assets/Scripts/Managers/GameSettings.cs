using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Manager / GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] 
    private string _GameVersion = "0.0.0"; // créer une variable de version du jeu
    
    public string GameVersion { get { return _GameVersion; } } // geter de la version du jeu

    [SerializeField]
    private string _username = "Player"; // var avec nom générique
    public string Username // permet de générer un username aléatoire et de le récupérer avec la method
    {
        get
        {
            int value = Random.Range(0, 9999);
            return _username + value.ToString();
        }
    }
}
