using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteFlBed : MonoBehaviour
{
    public SpriteRenderer plantRenderer;
    public Sprite grownPlantSprite;
    public Sprite seedlingSprite;
    private bool isPlanted = false;
    private bool isGrown = false;
    private float growTime;

    public float interactionRadius = 1f;
    public LayerMask playerLayer;

    private PlayerInventory playerInventory;

    void Start()
    {
        plantRenderer.enabled = false;
    }

    void Update()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, interactionRadius, playerLayer);

        if (playerCollider != null)
        {
            playerInventory = playerCollider.GetComponent<PlayerInventory>();

            if (playerInventory != null)
            {
                if (!isPlanted && playerInventory.UseWhiteSeed())
                {
                    int usedFertilizer = playerInventory.UseFertilizer();
                    if (usedFertilizer > 0)
                    {
                        isPlanted = true;
                        plantRenderer.enabled = true;
                        plantRenderer.sprite = seedlingSprite;
                        growTime = Time.time + Random.Range(6f, 12f);
                    }
                }
                else if (isGrown)
                {
                    int randWhtFrCount = Random.Range(2, 4);
                    playerInventory.AddHarvestW(randWhtFrCount);
                    ResetFlowerbed();
                }
            }
        }

        if (isPlanted && !isGrown && Time.time >= growTime)
        {
            isGrown = true;
            plantRenderer.sprite = grownPlantSprite;
        }
    }

    private void ResetFlowerbed()
    {
        isGrown = false;
        isPlanted = false;
        plantRenderer.enabled = false;
        plantRenderer.sprite = null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
