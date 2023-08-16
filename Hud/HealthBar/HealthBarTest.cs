using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarTest : MonoBehaviour
{
    public Image bar;
    public Image redBar;
    public Image filter;

    public float rawHealth;
    public float health = 250;
    public float maxHealth = 250;

    private void Awake()
    {
        rawHealth = health;
        redBar.enabled = false;
        filter.enabled = false;
    }

    private void Update()
    {
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        float healthPercent = Mathf.Sqrt(health);

        if (health > rawHealth)
        {
            health -= Time.deltaTime * healthPercent;
            if(health <= 0)
            {
                health = 0;
            }
        }

        float fillHealthBar = Mathf.Sqrt(health / maxHealth);

        bar.fillAmount = fillHealthBar;

        if (fillHealthBar <= 0.55f)
        {
            redBar.enabled = true;
            filter.enabled = true;
            redBar.color = Color.Lerp(Color.red, Color.yellow, health/maxHealth) * 10f;
        }

        else
        {
            redBar.enabled = false;
            filter.enabled = false;
        }
    }
}
