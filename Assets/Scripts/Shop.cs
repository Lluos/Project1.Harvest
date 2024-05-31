using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public float interactionRadius = 1f; 
    public LayerMask playerLayer;

    public int redFruitPrice = 10;
    public int whiteFruitPrice = 15;

    void Update()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, interactionRadius, playerLayer);

        if (playerCollider != null)
        {
            PlayerInventory playerInventory = playerCollider.GetComponent<PlayerInventory>();

            if (playerInventory != null)
            {
                SellRFruit(playerInventory);
            }
        }
    }

    private void SellRFruit(PlayerInventory inventory)
    {
        int redFruitToSell = inventory.redFruit;
        int whiteFruitToSell = inventory.whiteFruit;
        if (redFruitToSell > 0 || whiteFruitToSell > 0)
        {
            int totalWhiteFrAmount = whiteFruitToSell * whiteFruitPrice;
            int totalRedFrAmount = redFruitToSell * redFruitPrice;
            inventory.AddMoney(totalRedFrAmount);
            inventory.AddMoney(totalWhiteFrAmount);
            inventory.redFruit = 0;
            inventory.whiteFruit = 0;
            inventory.RedFruitText.text = inventory.redFruit.ToString();
            inventory.WhiteFruitText.text = inventory.whiteFruit.ToString();
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
