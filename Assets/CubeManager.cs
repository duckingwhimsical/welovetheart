using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    private static CubeManager instance;

    private static List<CubeMover> cubes;

    public static void Initialize(List<CubeMover> cubelist)
    {
        cubes = cubelist;
    }

    public static void TouchPoints(Vector3 one, Vector3 two)
    {
        for (int index = 0; index < cubes.Count; index++)
        {
            CubeMover cube = cubes[index];

            if (cube.TouchPointsEngage(one, two))
            {

            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
}
