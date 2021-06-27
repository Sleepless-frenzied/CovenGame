using UnityEngine;
using UnityEngine.UI;

public class Buffs_Icon : MonoBehaviour
{
    private UnarmedCharacter player;
    public Image image;
    public Sprite[] allImage = new Sprite[6];

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponentInChildren<UnarmedCharacter>();
        //allImage = new Sprite[Enum.GetNames(typeof(Status)).Length];
    }

    private void Update()
    {
        int SlotIndex = (int) player.buff;
        image.enabled = true;
        switch (SlotIndex)
        {
            case 0:
                image.enabled = false;
                break;
            case 1:
                image.color = Color.cyan;
                break;
            case 2:
                image.color = Color.green;
                break;
            case 3:
                image.color = Color.yellow;
                break;
            case 4:
                image.color = Color.blue;
                break;
            case 5:
                image.color = Color.magenta;
                break;
        }
        image.sprite = allImage[SlotIndex];
    }
}
