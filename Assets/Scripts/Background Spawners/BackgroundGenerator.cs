using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{

    [SerializeField]
    private GameObject groundPrefab, tree_1_Prefab, tree_2_Prefab;

    [SerializeField]
    private int groundsToSpawn = 5, treesToSpawn = 2;

    [SerializeField]
    private float ground_Y_Pos = -6f, tree_Y_Pos = -0.18f;

    [SerializeField]
    private float ground_X_Distance = 17.85f, tree_X_Distance = 41.2f;

    private float lastGroundXPos, lastTreeXPos;

    [SerializeField]
    private float generateLevelWaitTime = 3f;

    private float waitTimer;

    private void Start()
    {
        //StartCoroutine(SpawnGrounds());
    }

    private void Update()
    {
        CheckToSpawnLevelParts();
    }

    void CheckToSpawnLevelParts()
    {

        if (Time.time > waitTimer)
        {
            GenerateGrounds();
            GenerateTrees();

            waitTimer = Time.time + generateLevelWaitTime;
        }

    }

    IEnumerator SpawnGrounds()
    {
        while (true)
        {

            GenerateGrounds();
            GenerateTrees();

            yield return new WaitForSeconds(generateLevelWaitTime);

        }
    }

    void GenerateGrounds()
    {

        Vector3 groundPosition = Vector3.zero;

        for (int i = 0; i < groundsToSpawn; i++)
        {

            groundPosition = new Vector3(lastGroundXPos, ground_Y_Pos, 0f);

            Instantiate(groundPrefab, groundPosition, Quaternion.identity)
                .transform.SetParent(transform);

            lastGroundXPos += ground_X_Distance;


        }

    }

    void GenerateTrees()
    {

        Vector3 treePosition = Vector3.zero;

        for (int i = 0; i < treesToSpawn; i++)
        {

            treePosition = new Vector3(lastTreeXPos, tree_Y_Pos, 0f);

            if (Random.Range(0, 2) > 0)
            {

                Instantiate(tree_1_Prefab, treePosition, Quaternion.identity)
                    .transform.SetParent(transform);

                Instantiate(tree_2_Prefab, treePosition, Quaternion.identity)
                    .transform.SetParent(transform);

            }
            else
            {

                Instantiate(tree_2_Prefab, treePosition, Quaternion.identity)
                    .transform.SetParent(transform);

                Instantiate(tree_1_Prefab, treePosition, Quaternion.identity)
                    .transform.SetParent(transform);

            }

            lastTreeXPos += tree_X_Distance;

        }

    }

} // class










































