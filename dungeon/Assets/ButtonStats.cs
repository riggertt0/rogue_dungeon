using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonStats : MonoBehaviour
{
    public void Button(GameObject stats_panel)
    {
        if(stats_panel.activeSelf) stats_panel.SetActive(false);
        else stats_panel.SetActive(true);
    }
}
