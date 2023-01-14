using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using static UnityEditor.PlayerSettings;

public class SpawnTrees : MonoBehaviour
{
    public GameObject[] trees;
    //public Terrain terrain;


    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < 90; i++)
            RandomPoint();

    }

    //void PlantTrees()
    //{
    //    Vector3[] meshPoints = transform.GetComponent<MeshFilter>().mesh.vertices;
    //    int[] tris = transform.GetComponent<MeshFilter>().mesh.triangles;
    //    int triStart = Random.Range(0, meshPoints.Length / 3) * 3; // get first index of each triangle

    //    float a = Random.value;
    //    float b = Random.value;

    //    if (a + b >= 1)
    //    { // reflect back if > 1
    //        a = 1 - a;
    //        b = 1 - b;
    //    }

    //    Vector3 newPointOnMesh = meshPoints[triStart] + (a * (meshPoints[triStart + 1] - meshPoints[triStart])) + (b * (meshPoints[triStart + 2] - meshPoints[triStart])); // apply formula to get new random point inside triangle

    //    newPointOnMesh = transform.TransformPoint(newPointOnMesh); // convert back to worldspace

    //    Vector3 rayOrigin = ((Random.onUnitSphere * 1f) + transform.position); // put the ray randomly around the transform

    //    RaycastHit hitPoint;
    //    Physics.Raycast(rayOrigin, newPointOnMesh - rayOrigin, out hitPoint, 100f, LayerMask.GetMask("Default"));
    //            Instantiate(trees[0], newPointOnMesh-new Vector3(0,0.5f,0), Quaternion.identity);
            
        
    //}

    void RandomPoint()
    {
        int j = 0;
        //Vector3 rayOrigin = ((Random.onUnitSphere * 120f) + transform.position); // put the ray randomly around the transform
        Vector3 rayOrigin = new Vector3(Random.Range(-150, 150), 10, Random.Range(-150, 150));
        RaycastHit hitPoint;
        for (int i=0; i<1000;i++)
        {
           // -150    150 z
            if (Physics.Raycast(rayOrigin, Vector3.down, out hitPoint, 50f, LayerMask.GetMask("Terrain")))
            {
                if (hitPoint.collider!=null)
                {
                    Debug.Log(hitPoint.collider);
                    Instantiate(trees[0], hitPoint.point, Quaternion.identity);
                    j++;
                }
            }
        }
        Debug.Log(j);
    }

}
