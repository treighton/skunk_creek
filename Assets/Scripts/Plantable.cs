using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plantable : MonoBehaviour
{
    [SerializeField] GameObject plant;
    [SerializeField] GameObject dialog;
    // Start is called before the first frame update
    private bool canActivate;
    private bool hasPlant = false;
    private PlayerControls playerControls;

    void Awake() {
        playerControls = new PlayerControls();
    }
    private void OnEnable() {
        playerControls.Enable();
    }
    // Update is called once per frame
    void Start() {
        playerControls.Player.Fire.performed += _ => Plant();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        canActivate = true;
        if (!hasPlant) {
            dialog.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        canActivate = false;
        dialog.SetActive(false);
    }

    void Plant() {
        if (canActivate && !hasPlant) {
            Instantiate(plant, transform.position, Quaternion.identity, transform);
            hasPlant = true;
        }
    }

    public void ToggleHasPlant () {
        hasPlant = !hasPlant;
    }
}
