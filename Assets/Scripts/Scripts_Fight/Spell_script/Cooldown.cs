using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    public GameObject ThePlayer;
    private UnarmedCharacter player;
    private Animator animator;
    public Image image;
    

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
        if (animator.GetBool("isAttacking"))
        {
            image.fillAmount = 1;
        }
        
        image.fillAmount -= Time.deltaTime * 1/player.attackCooldown;
    }
}
