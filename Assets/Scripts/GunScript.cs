using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private string gunType;

    private bool canPickUp = false;

    private GameController gc;

    private GameObject player;

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GC").GetComponent<GameController>();
    }

    private void Update()
    {
        if (canPickUp == true && Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<PlayerMovement>().gunType = gunType;
            
            if(gunType == "Pistol")
            {
                gc.PickUpPistol();
                player.GetComponent<PlayerMovement>().gunSprite.GetComponent<SpriteRenderer>().sprite = player.GetComponent<PlayerMovement>().pistol;
                player.GetComponent<PlayerMovement>().magSize = 8;
                player.GetComponent<PlayerMovement>().ammo = 8;
            } else if(gunType == "AK")
            {
                gc.PickUpAK();
                player.GetComponent<PlayerMovement>().gunSprite.GetComponent<SpriteRenderer>().sprite = player.GetComponent<PlayerMovement>().ak;
                player.GetComponent<PlayerMovement>().magSize = 30;
                player.GetComponent<PlayerMovement>().ammo = 30;
            }
            else
            {
                gc.PickUpShotgun();
                player.GetComponent<PlayerMovement>().gunSprite.GetComponent<SpriteRenderer>().sprite = player.GetComponent<PlayerMovement>().shotgun;
                player.GetComponent<PlayerMovement>().magSize = 3;
                player.GetComponent<PlayerMovement>().ammo = 3;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player = collision.gameObject;
            canPickUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canPickUp = false;
        }
    }
}
