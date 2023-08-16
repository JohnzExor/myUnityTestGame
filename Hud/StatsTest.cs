using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class StatsTest : MonoBehaviour
{

    public string playerName;
    public int level;

    public HealthBarTest healthbar { get; private set; }

    public Text nameText;
    public Text lvlText;
    public Text healthText;
    public Text maxHealthText;

    public Canvas canvas;
    public GameObject deadScreen;

    bool isDead = false;

    public GameObject stats;

    private void Awake()
    {
        healthbar = GetComponent<HealthBarTest>();
    }

    private void Update()
    {
        nameText.text = playerName;
        lvlText.text = level.ToString();
        healthText.text = healthbar.health.ToString("0");
        maxHealthText.text = healthbar.maxHealth.ToString("0");


        if(Input.GetKeyDown(KeyCode.G))
        {
            healthbar.rawHealth -= 10f;
        }


        if(healthbar.health <= 0) 
        {
            if (!isDead)
            {
                Instantiate(deadScreen, canvas.transform);
                isDead = true;
            }
            stats.SetActive(false);
        }
    }
}
