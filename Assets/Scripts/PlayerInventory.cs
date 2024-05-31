using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // семена. Можно будет потом покупать через магазин.
    public int redSeeds = 5;
    public int whiteSeeds = 5;

    // фрукты. можно получить через сбор соответствующего растения. Стоимость и кол-во получаемого фрукта разнятся.
    public int redFruit; 
    public int whiteFruit;

    public int fertilizer = 500; // удобрение, исполь-я вместе с семенами.
    public int money;

    public TextMeshProUGUI RedSeedText;
    public TextMeshProUGUI RedFruitText;

    public TextMeshProUGUI WhiteFruitText;
    public TextMeshProUGUI WhiteSeedText;

    public TextMeshProUGUI FertilizerText;
    public TextMeshProUGUI MoneyText;

    private void Start()
    {
        redFruit = 0;
        whiteFruit = 0;
        RedSeedText.text = redSeeds.ToString();
        WhiteSeedText.text = redSeeds.ToString();
        FertilizerText.text = fertilizer.ToString();
    }

    public bool UseRedSeed()
    {
        if (redSeeds > 0)
        {
            redSeeds--;
            RedSeedText.text = redSeeds.ToString();
            return true;
        }
        return false;
    }

    public bool UseWhiteSeed()
    {
        if (whiteSeeds > 0)
        {
            whiteSeeds--;
            WhiteSeedText.text = whiteSeeds.ToString();
            return true;
        }
        return false;
    }

    public void AddWSeed(int wSeed)
    {
        whiteSeeds += wSeed;
        WhiteSeedText.text = whiteSeeds.ToString();
    }

    public void AddRSeed(int rSeed)
    {
        redSeeds += rSeed;
        RedSeedText.text = redSeeds.ToString();

    }

    public void AddFertilizer(int bFertilizer)
    {
        fertilizer += bFertilizer;
        FertilizerText.text = fertilizer.ToString();
        MoneyText.text = money.ToString();
    }

    public int UseFertilizer()
    {
        if (fertilizer > 0)
        {
            int usedFertilizer = Random.Range(1, 4);
            usedFertilizer = Mathf.Min(usedFertilizer, fertilizer);
            fertilizer -= usedFertilizer;
            FertilizerText.text = fertilizer.ToString();
            return usedFertilizer;
        }
        return 0;
    }

    public void AddHarvestR(int rFruit)
    {
        redFruit += rFruit;
        RedFruitText.text = redFruit.ToString();
    }

    public void AddHarvestW(int wFruit)
    {
        whiteFruit += wFruit;
        WhiteFruitText.text = whiteFruit.ToString();
    }

    public void AddMoney( int amount)
    {
        money += amount;
        MoneyText.text = money.ToString();
    }
}
