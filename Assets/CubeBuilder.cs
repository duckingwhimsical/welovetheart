using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBuilder : MonoBehaviour
{
    int numCubes = 100;

    float size = 0.25f;
    float padding = 0.05f;

    float spawnDelay = 0.05f;

    public GameObject cubePrefab;

    private void Start()
    {
        StartCoroutine(DoSpawn());
    }

    IEnumerator DoSpawn()
    {
        List<CubeMover> cubes = new List<CubeMover>();

        int row = (int)Mathf.Sqrt(numCubes);
        float halfRow = (float)row / 2f;

        float startX = 0 - (halfRow*size) - ((halfRow-1)*padding);
        float startY = startX;

        for (int xIndex = 0; xIndex < 10; xIndex++)
        {
            for (int yIndex = 0; yIndex < 10; yIndex++)
            {
                yield return new WaitForSeconds(spawnDelay);
                GameObject cubeGO = GameObject.Instantiate<GameObject>(cubePrefab);
                cubeGO.transform.parent = this.transform;
                cubeGO.transform.localScale = Vector3.one * size;

                float x = startX + ((xIndex+0.5f) * (size)) + ((xIndex - 1) * padding);
                float y = startY + ((yIndex + 0.5f) * (size)) + ((yIndex - 1) * padding);
                cubeGO.transform.localPosition = new Vector3(x, y, 0);

                var cube = cubeGO.GetComponent<CubeMover>();
                cube.Initialize(x, y);

                cubes.Add(cube);
            }
        }

        CubeManager.Initialize(cubes);
    }
}
