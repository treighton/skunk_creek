using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    // Keeping Bomb as placeholder if you wanted to implement something like item limited amounts 
    public enum TypeOfPickUp{ Carrot };
    public TypeOfPickUp typeOfPickUp;

    private const string playerString = "Player";

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(playerString)) {
            if (typeOfPickUp == TypeOfPickUp.Carrot) {
                PickupCarrot();
            }
        }
    }

    private void PickupCarrot() {
        bool isHarvestable = gameObject.GetComponent<Plant>().IsHarvestable();
        
        if (!isHarvestable) {
            return;
        }

        FindObjectOfType<CarrotCase>().IncreaseCarrotCount(1);
        Destroy(gameObject);
    }
}
