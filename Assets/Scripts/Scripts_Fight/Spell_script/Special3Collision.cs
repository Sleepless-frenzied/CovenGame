using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special3Collision : MonoBehaviour
{
    public float spellDamage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("mob"))
        {
            Debug.Log("Ennemi touché ! special 3"); //il faut appliquer les dégâts et les debuffs ( knockback)
        }
    }
}
