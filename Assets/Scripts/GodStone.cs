using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodStone : MonoBehaviour
{
    public int redSeedPrice = 7;
    public int whiteSeedPrice = 11;

    [SerializeField] GameObject seedsShopPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            
            seedsShopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            seedsShopPanel.SetActive(false);
        }
    }

    public void SellWSeeds(PlayerInventory inventory)
    {
        
        if (inventory.money > 0)
        {
            inventory.money -= whiteSeedPrice;
            inventory.MoneyText.text = inventory.money.ToString();
            inventory.AddWSeed(1);
        }
    }

    public void SellRSeeds(PlayerInventory inventory)
    {

        if (inventory.money > 0)
        {
            inventory.money -= redSeedPrice;
            inventory.MoneyText.text = inventory.money.ToString();
            inventory.AddRSeed(1);
        }
    }

    public void SellFertilizer(PlayerInventory inventory)
    {

        if (inventory.money > 0)
        {
            inventory.money -= 1;
            inventory.MoneyText.text = inventory.money.ToString();
            inventory.AddFertilizer(1);

        }
    }

    
}
