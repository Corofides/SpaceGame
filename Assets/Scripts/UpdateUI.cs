using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{

    public PlayerController Player;
    public Text CollectablesText;
    public Text HealthText;

    // Update is called once per frame
    private void FixedUpdate()
    {
        int playerCollectables = Player.TotalCollectables();
        int playerHealth = Player.GetHealth();
        
        CollectablesText.text = "Collectables: " + playerCollectables;
        HealthText.text = "Health: " + playerHealth;
    }
}
