using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    private GameObject[] healthBars;

    private int currentHealthBarIndex;

    [SerializeField]
    private int health;

    private void Awake()
    {
        healthBars = GameObject.FindWithTag(TagManager.HEALTH_BAR_HOLDER_TAG)
            .GetComponent<HealthBarHolder>().healthBars;
    }

    private void Start()
    {
        health = healthBars.Length;
        currentHealthBarIndex = health - 1;
    }

    public void SubtractHealth()
    {

        healthBars[currentHealthBarIndex].SetActive(false);

        currentHealthBarIndex--;
        health--;

        if (health <= 0)
        {

            // game over
            GameObject.FindWithTag(TagManager.GAMEPLAY_CONTROLLER_TAG)
                .GetComponent<GameOverController>().GameOverShowPanel();

            Destroy(gameObject);

        }

    }

    void AddHealth()
    {

        if (health == healthBars.Length)
            return;

        health++;

        currentHealthBarIndex = health - 1;

        healthBars[currentHealthBarIndex].SetActive(true);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag(TagManager.HEALTH_TAG))
        {
            SoundManager.instance.Play_CollectableSound_Sound();
            AddHealth();
            collision.gameObject.SetActive(false);
        }

    }

} // class




























