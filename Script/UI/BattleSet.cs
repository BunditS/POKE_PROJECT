using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSet : MonoBehaviour
{
    public List<Image> icon = new();
    public List<GameObject> ButtonUI  = new() ;
    public List<GameObject> hpUI = new();
    public static BattleSet instance;
    public bool Setkey = true;
    private readonly Color[] ButtonColor = new Color[4];
    private readonly bool[] ButtonEnable = new bool[4];
    private void Awake()
    {
        instance = this;
        for (int i = 0; i < icon.Count / 2; i++)
        {
            icon[i].sprite = Choose.instance.PlayerMonster[i].GetComponentsInChildren<SpriteRenderer>()[1].sprite; 
            icon[i + 3].sprite = Choose.instance.ComMonster[i].GetComponentsInChildren<SpriteRenderer>()[1].sprite;

        }
    }

    private void Start()
    {
        Setkey = true;
    }
    public void Update()
    {
        for (int i = 0; i < icon.Count; i++)
        {
            icon[i].enabled = false;
        }
        for (int i = 0; i < Choose.instance.PlayerMonster.Count; i++) icon[2 - i].enabled = true;   
        for (int i = 0; i < Choose.instance.ComMonster.Count; i++) icon[2 + 3 - i].enabled = true;

        
      
            if (Setkey)
            {
            for (int i = 0; i < ButtonUI.Count; i++)
                {
                    ButtonColor[i] = Color.white;
                    ButtonEnable[i] = true;
                }
                if (PlayerScript.instance.StackHit < 5)
                {
                    ButtonColor[1] = Color.gray;
                    ButtonEnable[1] = false;
                }
                if (PlayerScript.instance.CoolDown_Heal > GameData.instance.CurrentTurn)
                {
                    ButtonColor[2] = Color.gray;
                    ButtonEnable[2] = false;
                }
                if (PlayerScript.instance.CoolDown_Buff > GameData.instance.CurrentTurn)
                {
                    ButtonColor[3] = Color.gray;
                    ButtonEnable[3] = false;
                }
            }
            else if (!Setkey)
            {
                for (int i = 0; i < ButtonUI.Count; i++)
                { 
                    ButtonColor[i] = Color.gray;
                    ButtonEnable[i] = false;
                }
            }
            
            for (int i = 0; i < ButtonUI.Count; i++)
            {
                ButtonUI[i].GetComponent<Image>().color = ButtonColor[i];
                ButtonUI[i].GetComponent<Button>().enabled = ButtonEnable[i];
            }
        
        

        hpUI[0].GetComponentsInChildren<Transform>()[1].localScale = new Vector3(1, PlayerScript.instance.HP/PlayerScript.instance.CharacterDB.HP, 1);
        hpUI[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Mathf.FloorToInt(PlayerScript.instance.HP) + "/" + PlayerScript.instance.CharacterDB.HP;
        hpUI[1].GetComponentsInChildren<Transform>()[1].localScale = new Vector3(1, ComScript.instance.HP / ComScript.instance.CharacterDB.HP, 1);
        hpUI[1].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Mathf.FloorToInt(ComScript.instance.HP) + "/" + ComScript.instance.CharacterDB.HP;
    }
}
