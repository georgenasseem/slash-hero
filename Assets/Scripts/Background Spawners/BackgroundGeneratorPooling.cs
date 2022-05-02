using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGeneratorPooling : MonoBehaviour
{

    [SerializeField]
    private GameObject groundPrefab, treePrefab;

    [SerializeField]
    private int groundsToSpawn = 10, treesToSpawn = 5;

    private List<GameObject> groundPool = new List<GameObject>();
    private List<GameObject> treePool = new List<GameObject>();

    [SerializeField]
    private float ground_Y_Pos = -6f, tree_Y_Pos = -0.18f;

    [SerializeField]
    private float ground_X_Distance = 17.85f, tree_X_Distance = 41f;

    private float lastGroundXPos, lastTreeXPos;

    [SerializeField]
    private float generateLevelWaitTime = 11f;

    private float waitTime;

    private void Start()
    {
        GenerateInitialGroundsAndTrees();
        waitTime = Time.time + generateLevelWaitTime;
    }

    private void Update()
    {
        CheckForGroundsAndTrees();
    }

    void GenerateInitialGroundsAndTrees()
    {

        Vector3 groundPosition = Vector3.zero;

        GameObject newGround;

        for (int i = 0; i < groundsToSpawn; i++)
        {

            groundPosition = new Vector3(lastGroundXPos, ground_Y_Pos, 0f);

            newGround = Instantiate(groundPrefab, groundPosition, Quaternion.identity);

            newGround.transform.SetParent(transform);

            groundPool.Add(newGround);

            lastGroundXPos += ground_X_Distance;

        }

        Vector3 treePosition = Vector3.zero;

        GameObject newTree;

        for (int i = 0; i < treesToSpawn; i++)
        {

            treePosition = new Vector3(lastTreeXPos, tree_Y_Pos, 0f);

            newTree = Instantiate(treePrefab, treePosition, Quaternion.identity);

            newTree.transform.SetParent(transform);

            treePool.Add(newTree);

            lastTreeXPos += tree_X_Distance;

        }

    }

    void SetNewGrounds()
    {

        Vector3 groundPosition = Vector3.zero;

        foreach (GameObject obj in groundPool)
        {

            if (!obj.activeInHierarchy)
            {

                groundPosition = new Vector3(lastGroundXPos, ground_Y_Pos, 0f);

                obj.transform.position = groundPosition;
                obj.SetActive(true);

                lastGroundXPos += ground_X_Distance;

            }

        }

        //for (int i = 0; i < groundPool.Count; i++)
        //{

        //    if (!groundPool[i].activeInHierarchy)
        //    {

        //        groundPosition = new Vector3(lastGroundXPos, ground_Y_Pos, 0f);

        //        groundPool[i].transform.position = groundPosition;
        //        groundPool[i].SetActive(true);

        //        lastGroundXPos += ground_X_Distance;

        //    }

        //}

    }

    void SetNewTrees()
    {

        Vector3 treePosition = Vector3.zero;

        foreach (GameObject obj in treePool)
        {

            if (!obj.activeInHierarchy)
            {

                treePosition = new Vector3(lastTreeXPos, tree_Y_Pos, 0f);

                obj.transform.position = treePosition;
                obj.SetActive(true);

                lastTreeXPos += tree_X_Distance;

            }

        }

        //for (int i = 0; i < treePool.Count; i++)
        //{

        //    if (!treePool[i].activeInHierarchy)
        //    {

        //        treePosition = new Vector3(lastTreeXPos, tree_Y_Pos, 0f);

        //        treePool[i].transform.position = treePosition;
        //        treePool[i].SetActive(true);

        //        lastTreeXPos += tree_X_Distance;

        //    }

        //}

    }

    void CheckForGroundsAndTrees()
    {

        if (Time.time > waitTime)
        {
            SetNewGrounds();
            SetNewTrees();

            waitTime = Time.time + generateLevelWaitTime;
        }

    }

} // class





























