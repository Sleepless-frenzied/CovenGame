using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownSpecial : MonoBehaviour
{
    private float cooldown;
    public Image image;
    public GameObject ThePlayer;
    private UnarmedCharacter player;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        player = ThePlayer.GetComponent<UnarmedCharacter>();
        animator = ThePlayer.GetComponent<Animator>();
        image.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //update the spell
        switch (animator.GetInteger("Weapon"))
        {
            case 0:
                cooldown = 10;
                break;
            case 1:
                cooldown = 3;
                break;
            case 2:
                cooldown = 4;
                break;
            case 3:
                cooldown = 4;
                break;
            case 4:
                cooldown = 6;
                break;
        }

        if (Input.GetKeyDown(KeyCode.A) && image.fillAmount <= 0)
        {
            image.fillAmount = 1;
            Debug.Log(cooldown);
        }
        
        image.fillAmount -= Time.deltaTime * 1 / cooldown;
    }
}
