using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerSetts : MonoBehaviour
{
    public static PlayerSetts playerStats;

    public GameObject player;

    public float MaxHealth;

    public float Health;

    public GameObject healthBar;

    public Slider healthBarSlider;

    public GameObject fill;

    public Text healthPercent;

    public GameObject die_light;

    public GameObject tomb;

    public float evasionChance = 0.01f;
    public float criticalChance = 0.05f;
    public float criticalDamageMultiplier = 1.5f;
    public int xp = 0;
    public int level = 1;
    public int maxLevel = 50;
    public float armor = 0.0f;
    public float magicalResistance = 0.02f;

    public GameObject PlayerStats;

    public bool IsEvaded()
    {
        return Random.Range(0f, 1f) < evasionChance;
    }

    public float GetDamageMultiplier()
    {
        if (Random.Range(0f, 1f) < criticalChance)
        {
            return criticalDamageMultiplier;
        }
        return 1;
    }

    public int XpNeededToLevelUp()
    {
        if (level == maxLevel)
        {
            return Int32.MaxValue;
        }
        return 5 + 5 * level;
    }

    public void LevelUp()
    {
        xp -= XpNeededToLevelUp();
        ++level;

        evasionChance += 0.005f;
        criticalChance += 0.01f;
        criticalDamageMultiplier += 0.05f;
    }

    public void AddXp(int addXp)
    {
        xp += addXp;
        while (xp > XpNeededToLevelUp())
        {
            LevelUp();
        }
    }

    void Awake()
    {
        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        Health = MaxHealth;
        healthBar.SetActive(true);
        fill.GetComponent<Image>().color = new Color(0.06260932f, 0.8313726f, 0.01176468f, 1f);
    }

    private void CheckDeath()
    {
        if (Health <= 0)
        {
            Debug.Log("Die*");
            fill.GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
            Vector3 pos = player.transform.position;
            pos.z = -2;
            Instantiate(die_light, pos, Quaternion.identity);
            Instantiate(tomb, pos, Quaternion.identity);
            Destroy(player);
            Health = 0f;
        }
    }

    public void HealCharacter(float heal)
    {
        Health += heal;
        CheckOverHeal();
        healthPercent.text = "" + Health + "%";
        healthBarSlider.value = CalculateHealthPercentage();
        if (Health / MaxHealth > 0.6)
        {
            fill.GetComponent<Image>().color = new Color(0.06260932f, 0.8313726f, 0.01176468f, 1f);
        }
        else if (Health / MaxHealth > 0.3)
        {
            fill.GetComponent<Image>().color = new Color(0.8509804f, 0.8154773f, 0.08235291f, 1f);
        }
    }

    private void CheckOverHeal()
    {
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public void DealDamage(float Damage)
    {
        Health -= Damage;
        CheckDeath();
        healthPercent.text = "" + Health + "%";
        healthBarSlider.value = CalculateHealthPercentage();
        if (Health/MaxHealth < 0.6)
        {
            fill.GetComponent<Image>().color = new Color(0.8509804f, 0.8154773f, 0.08235291f, 1f);
        }
        if (Health / MaxHealth < 0.3)
        {
            fill.GetComponent<Image>().color = new Color(0.8301887f, 0.01174793f, 0.01174793f, 1f);
        }
    }

    private float CalculateHealthPercentage()
    {
        return (Health / MaxHealth);
    }

    public void ChangeArmor(float delta_armor)
    {
        armor += delta_armor;
        PlayerStats.GetComponent<PlayerStats>().UpdateStats();
    }
}
