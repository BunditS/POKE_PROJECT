using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorValue : MonoBehaviour
{
    public List<TMPro.TextMeshProUGUI> Value = new();
    int stack;
    private void Update()
    {
        Value[0].text = ((int)PlayerScript.instance.ATK).ToString();
        Value[1].text = PlayerScript.instance.Def.ToString();
        Value[2].text = PlayerScript.instance.Spd.ToString();
        stack = 5-PlayerScript.instance.StackHit;
        Value[3].text = stack.ToString();
        if (stack < 0)
        {
            Value[3].text = "RDY";
        }
    }
}
