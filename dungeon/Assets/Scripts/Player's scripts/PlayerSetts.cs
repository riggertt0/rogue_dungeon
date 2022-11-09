using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetts : MonoBehaviour
{
    public static PlayerSetts playerStats;

    public GameObject player;

    public float Health;

    public float MaxHealth;

    public GameObject healthBar;

    public Slider healthBarSlider;

    public GameObject fill;

    public Text healthPercent;

    public GameObject die_light;

    public GameObject tomb;

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
}
