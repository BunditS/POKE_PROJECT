using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartButtonControl : MonoBehaviour
{
    void Update()
    {
        if (Choose.instance.count)
        {
            this.GetComponent<Image>().color = Color.gray;
            this.GetComponent<Button>().enabled = false;
        }
        else
        {
            this.GetComponent<Image>().color = Color.white;
            this.GetComponent<Button>().enabled = true;
        }
    }
}
