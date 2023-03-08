using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarrotCase : MonoBehaviour
{
   public int currentCarrots;
    
    [SerializeField] private TMP_Text carrotText;

    private void Update() {
        UpdateCarrotText();
    }

    public void UpdateCarrotText() {
        carrotText.text = currentCarrots.ToString("D3");
    }

    public void IncreaseCarrotCount(int amount) {
        currentCarrots += amount;
    }
}
