using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    private UnarmedCharacter player;
    private Animator animator;
    public Image image;
    public Sprite[] allImage;
    public bool spell;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponentInChildren<UnarmedCharacter>();
        animator = GameObject.FindWithTag("Player").GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spell)
            image.sprite = allImage[animator.GetInteger("Spell")];
        else
            image.sprite = allImage[animator.GetInteger("Weapon")];
    }
}
