using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{

    [SerializeField]
    private bool deactivateGameObject;

    GameObject player;
    private PlayerMovement playerMovement;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_TAG))
        {
            collision.GetComponent<PlayerHealth>().SubtractHealth();

            if (deactivateGameObject)
                gameObject.SetActive(false);

        }

        if (collision.CompareTag(TagManager.ENEMY_TAG) && playerMovement.attack)
        {
            collision.GetComponent<EnemyHealth>().TakeDamage();
            playerMovement.attack = false;
        }

        if (collision.CompareTag(TagManager.OBSTACLE_TAG) && playerMovement.attack)
        {
            collision.GetComponent<EnemyHealth>().TakeDamage();
            playerMovement.attack = false;
        }

    }
}
