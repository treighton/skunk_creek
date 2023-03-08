using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] float growSpeed = 0.1f;
    [SerializeField] Sprite[] Sprites;
    [SerializeField] float age = 0.0f;
    [SerializeField] float maturity = 10;
    [SerializeField] bool harvestable = false;
    SpriteRenderer plantRenderer;
    BoxCollider2D  plantCollider;
    // Start is called before the first frame update
    void Start()
    {
        plantRenderer = GetComponent<SpriteRenderer>();
        plantCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAge();
        UpdateSprite();
    }

    void UpdateAge() {
         if (age > maturity) { 
            harvestable = true;
            return;
        }
         age += growSpeed * Time.deltaTime;
    }

    void UpdateSprite() {
        int ageIndex = Mathf.FloorToInt(age);

        if (ageIndex > Sprites.Length - 1){
           return;
        }

        plantRenderer.sprite = Sprites[ageIndex];
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(!harvestable) {
            return;
        }
        GetComponentInParent<Plantable>().ToggleHasPlant();
    }

    public bool IsHarvestable() {
        return harvestable;
    }
 }
