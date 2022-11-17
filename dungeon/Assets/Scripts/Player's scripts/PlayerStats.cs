using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerStats : MonoBehaviour
{
    public float evasionChance = 0.01f;
    public float criticalChance = 0.05f;
    public float criticalDamageMultiplier = 1.5f;
    public float absorbedDamage = 0;
    public int xp = 0;
    public int level = 1;
    public int maxLevel = 50;

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
        absorbedDamage += 0.005f;
    }

    public void AddXp(int addXp)
    {
        xp += addXp;
        while (xp > XpNeededToLevelUp())
        {
            LevelUp();
        }
    }
}