using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager ui;
    public Slider healthBar;
    public Text sector, Money;

    void Awake()
    {
        ui = this;
    }

    private void Start()
    {
        healthBar.value = PlayerStats.stats.health;
    }


    void Update()
    {
        
    }

    public void SetHealtbarValue()
    {
        healthBar.value = PlayerStats.stats.health;
    }
}
