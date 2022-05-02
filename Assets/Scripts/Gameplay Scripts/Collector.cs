using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(TagManager.GROUND_TAG) || collision.CompareTag(TagManager.TREE_1_TAG)
            || collision.CompareTag(TagManager.TREE_2_TAG))
        {

            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);

        }

        if (collision.CompareTag(TagManager.OBSTACLE_TAG) || collision.CompareTag(TagManager.ENEMY_TAG)
            || collision.CompareTag(TagManager.HEALTH_TAG))
        {
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }

    }

}




























