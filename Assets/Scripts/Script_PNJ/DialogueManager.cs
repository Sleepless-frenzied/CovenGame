using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Realtime;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets;
using Object = System.Object;


public class DialogueManager : MonoBehaviour
{
    private  static UnarmedCharacter player;
    [Header("PNJ")]
    public GameObject DialogueBox;
    public Button Next_button;
    public TMP_Text NameText;
    public TMP_Text DialogueText;

    [Header("ShopKeeper")]
    public GameObject ShopBox;
    private Dialogue _dialogue;
    public Button YesButton;
    public Button NoButton;

    [Header("QuestGiver")] 
    public Item QuestItem;

    public int Coins_Reward;
    public Item item_Reward = null;
    private bool received = false;
    private bool given = false;

    [Header("GrosTardos")]
    public int Coins_Gift;
    public Item Item_Gift = null;

    private bool No = true ;
    private bool Yes = false;


    //public Consumable[] consumables = AssetDatabase.LoadAllAssetsAtPath <Consumable[]>("Assets/Scripts/Script_Inventory/Potions/");
    //public Equipment[] equipments = AssetDatabase.LoadAllAssetsAtPath("Assets/Scripts/Script_Inventory/equi/");
    
    private Queue<string> sentences;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponentInChildren<UnarmedCharacter>();
        ShopBox.SetActive(false);
        sentences = new Queue<string>();
        NoButton.interactable = false;
        YesButton.interactable = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StopAllCoroutines();
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _dialogue = dialogue;
        DialogueBox.SetActive(true);
        DialogueBox.GetComponent<Animator>().SetBool("IsOpen" , true);
        //Dialogue_box.SetBool("IsOpen" , true);
        NameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        if (_dialogue.occupation == Occupation.QuestGiver && received )
        {
            if (item_Reward != null&& (!given))
            {
                if (Inventory.instance.items.Count <20)
                {
                    StartCoroutine(Dommage("For you!"));
                    Inventory.instance.items.Add(item_Reward);
                    given = true;
                }
                else
                {
                    StartCoroutine(Dommage("Oh no! It seems that you don't have enough space in your inventory :("));
                    received = true;
                }
                
            }
            else
            {
                //StartCoroutine(TypeSentence("Nothing more for you. \n Bye :)"));
                StartCoroutine(Dommage("Nothing more for you. \n Bye :)"));
            }
            //EndDialogue();
        }
        else
        {
            if (_dialogue.occupation == Occupation.GrosTardos && received )
            {
                if (Item_Gift != null && (!given))
                {
                    if (Inventory.instance.items.Count <20)
                    {
                        StopAllCoroutines();
                        StartCoroutine(Dommage("For you!"));
                        Inventory.instance.items.Add(Item_Gift);
                        given = true;
                    }
                    else
                    {
                        StopAllCoroutines();
                        StartCoroutine(Dommage("Oh no! It seems that you don't have enough space in your inventory :("));
                        received = true;
                    }
                }
                else
                {
                    //StopAllCoroutines();
                    StartCoroutine(Dommage("Nothing more for you. \n Bye :)"));
                }
            }
            else
            {
                StopAllCoroutines();
                DisplayNextSentence();
            }
        }
    }

    public void DisplayNextSentence()
    {
        Next_button.interactable = true;
        if (sentences.Count <= 0)
        {
            No = true ;
            Yes = false;
            /*if (_dialogue.occupation == Occupation.ShopKeeper)
            {
                string BuyOrNot = "Would you like to buy from " + _dialogue.name + "?"+ "\n" + " yes(y) or no(n)";
                StopAllCoroutines();
                StartCoroutine(TypeSentence(BuyOrNot));
                StartCoroutine(test3());
            }
            else
            {
                EndDialogue();
                return;
            }*/
            switch (_dialogue.occupation)
            {
                case Occupation.ShopKeeper:
                    string BuyOrNot = "Would you like to buy from " + _dialogue.name + "?"+ "\n" + " Yes or No";
                    StopAllCoroutines();
                    StartCoroutine(TypeSentence(BuyOrNot));
                    Debug.Log(No);
                    StartCoroutine(Shop_YesOrNo());
                    Debug.Log(No);
                    
                    break;
                case Occupation.QuestGiver:
                    if (!given)
                    {
                        string IWant = "Give me " + QuestItem.name + "and i'll give you " + Coins_Reward + " Coins";
                        if (item_Reward != null)
                        {
                            IWant += " and " + item_Reward.name;
                        }
                        StopAllCoroutines();
                        StartCoroutine(TypeSentence(IWant));
                        StartCoroutine(QuestGiver_YesOrNo());
                        No = true ;
                        Yes = false;
                    }
                    break;
                case Occupation.GrosTardos:
                    StopAllCoroutines();
                    StartCoroutine(GrosTardos());
                    break;
                default:
                    EndDialogue();
                    break;
            }
            
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    private void EndDialogue()
    {
        DialogueBox.GetComponent<Animator>().SetBool("IsOpen" , false);
        //DialogueBox.SetActive(false);
    }

    IEnumerator TypeSentence(string sentence )
    {
        DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
            //yield return null;
        }
    }

    public void yes()
    {
          Yes = true;
          //ShopBox.SetActive(true);
          //ShopBox.GetComponent<Animator>().SetBool("IsShop",true);


          switch (_dialogue.occupation)
          {
              case Occupation.ShopKeeper:
                  StartCoroutine(Shop(Yes));
                  break;
              case Occupation.QuestGiver:
                  break;
              default:
                  break;
          }

          if (_dialogue.occupation != Occupation.ShopKeeper)
          {
              NoButton.interactable = false;
              YesButton.interactable = false;
          }
        
          
          return ;
    }
    
    
    public void no()
    {
         No = false;
         //ShopBox.GetComponent<Animator>().SetBool("IsShop", false);
         switch (_dialogue.occupation)
         {
             case Occupation.ShopKeeper:
                 StartCoroutine(Shop(No));
                 break;
             case Occupation.QuestGiver:
                 StartCoroutine(Dommage("Ok bye"));
                 break;
             default:
                 break;
         }
         
         NoButton.interactable = false;
         YesButton.interactable = false;
         
         return;
    }
    
    private IEnumerator wait()
    { 
        yield return new WaitForSeconds(15);
    }
    private IEnumerator Shop_YesOrNo()
    {
        NoButton.interactable = true;
        YesButton.interactable = true;
        yield return new WaitUntil(() => Yes == true || No == false);
        if (Yes)
        {
            StartCoroutine(TypeSentence("Select an Item"));
        }
        else
        {
            StartCoroutine(TypeSentence("Ok bye"));
            EndDialogue();
        }
    }

    private IEnumerator Shop(bool YesOrNo)
    {
        ShopBox.GetComponent<Animator>().SetBool("IsShop",!YesOrNo);
        yield return new WaitForSeconds(1); //TODO
        if (ShopBox.activeSelf)
        {
            DialogueBox.GetComponent<Animator>().SetBool("IsOpen",YesOrNo);
            yield return new WaitForSeconds(1);
            DialogueBox.SetActive(false);
        }
        ShopBox.SetActive(YesOrNo);
        //return null;
    }
    
    
    private IEnumerator QuestGiver_YesOrNo()
    {
        NoButton.interactable = true;
        YesButton.interactable = true;
        yield return new WaitUntil(() => Yes == true || No == false);
        if (Yes)
        {
            QuestGiver();
        }

        

    }

    public void QuestGiver()
    {
        Next_button.interactable = false;
        for (int i = 0; i < Inventory.instance.items.Count; i++)
        {
            Item tmp = Inventory.instance.items[i];
            if (tmp == QuestItem)
            {
                Inventory.instance.Remove(tmp);
                StartCoroutine(TypeSentence("Oh! Thank you very much! \n this is for you!"));
                string Happy = "You received " + Coins_Reward + " Coins";
                player.Coins += Coins_Reward;
                if (item_Reward != null)
                {
                    Happy += " and " + item_Reward.name;
                    if (Inventory.instance.items.Count <20)
                    {
                        Inventory.instance.items.Add(item_Reward);
                        given = true;
                    }
                    else
                    {
                        StartCoroutine(Dommage("Oh no! It seems that you don't have enough space in your inventory :("));
                        received = true;
                    }
                }
                StartCoroutine(Dommage(Happy));
                //StartCoroutine(wait());
                //EndDialogue();
                return;
            }
        }
        StartCoroutine(Dommage("If you don't have my item just say it... \n Now get lost!"));
        return;
    }

    public IEnumerator GrosTardos()
    {
        Next_button.interactable = false;
        player.Coins += Coins_Gift;
        string gift = "You reveived " + Coins_Gift + " Coins";
        received = true;
        if (Item_Gift != null)
        {
            gift += " and " + Item_Gift.name;
            if (Inventory.instance.items.Count <20)
            {
                Inventory.instance.items.Add(Item_Gift);
                given = true;
            }
            else
            {
                StartCoroutine(TypeSentence("Oh no! It seems that you don't have enough space in your inventory :("));
            }
        }
        else
        {
            given = true;
        }
       
        StartCoroutine(TypeSentence(gift));
        yield return new WaitForSeconds(2);
        EndDialogue();
    }

    public IEnumerator Dommage(string sentence)
    {
        Next_button.interactable = false;
        StartCoroutine(TypeSentence(sentence));
        yield return new WaitForSeconds(2);
        EndDialogue();
    }



}

