using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveStats : MonoBehaviour
{
    public GameObject statsPanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (statsPanel.activeSelf) statsPanel.SetActive(false);
            else statsPanel.SetActive(true);
        }
    }
}
