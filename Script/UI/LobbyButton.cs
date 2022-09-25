using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyButton : MonoBehaviour
{
    public void ChooseClick()
    {
        Color Clr = this.GetComponent<Image>().color;
        if (Clr == Color.white)
        {
            if (Choose.instance.count)
            {
                this.GetComponent<Image>().color = Color.gray;
                Choose.instance.Add(this.name);
            }
            
        }
        else
        {
            this.GetComponent<Image>().color = Color.white;
            Choose.instance.Remove(this.name);
        }       
    }
}
