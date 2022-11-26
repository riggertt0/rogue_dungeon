using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Text Health_value;
    public Text Lvl_value;
    public Text Armor_value;
    public Text Evasion_value;
    public Text MagicalResistance_value;
    public Text CriticalChance_value;
    public Text CriticalMultiplier_value;
    public Text MinDamage_value;
    public Text MaxDamage_value;
    public GameObject GameManager;

    public void Start()
    {
        UpdateStats();
    }

    public void UpdateStats()
    {
        Health_value.text = GameManager.GetComponent<PlayerSetts>().Health.ToString();
        Lvl_value.text = GameManager.GetComponent<PlayerSetts>().level.ToString();
        Armor_value.text = GameManager.GetComponent<PlayerSetts>().armor.ToString();
        Evasion_value.text = (GameManager.GetComponent<PlayerSetts>().evasionChance * 100).ToString() + "%";
        MagicalResistance_value.text = (GameManager.GetComponent<PlayerSetts>().magicalResistance * 100).ToString() + "%";
        CriticalChance_value.text = (GameManager.GetComponent<PlayerSetts>().criticalChance * 100).ToString() + "%";
        CriticalMultiplier_value.text = GameManager.GetComponent<PlayerSetts>().criticalDamageMultiplier.ToString();
    }

}
