using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private Slider health;
    [SerializeField] private Slider armor;

    public int maxHealth;
    public int maxArmor;

    public int curHealth;
    public int curArmor;

    public int attack;

    public string nameCharacter;

    public int initiative;

    public int criticalChance;
    public int stunChance;

    public int poisonDamageDeal;
    public int poisonDamageTake;
    public int poisonChance;

    public int bleedDamageDeal;
    public int bleedDamageTake;
    public int bleedChance;

    private void Awake()
    {
        health.value = maxHealth;
        armor.value = maxArmor;

        curHealth = maxHealth;
        curArmor = maxArmor;
    }

    private void Update()
    {
        health.value = curHealth;
        armor.value = curArmor;

        if(curArmor < 0)
        {
            armor.value = 0;
        }
    }
}
