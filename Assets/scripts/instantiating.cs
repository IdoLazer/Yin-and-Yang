using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiating : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public int numObjects = 2;
    void Start()
    {

        Vector3 where1 = Random.onUnitSphere;
        Vector3 where2 = Random.onUnitSphere;
        Vector3 onPlanet1 = where1 * GetComponent<SphereCollider>().radius;
        Vector3 onPlanet2 = where2 * GetComponent<SphereCollider>().radius;
        Debug.Log(where1);
        Debug.Log(where2);
        GameObject newGO1 = Instantiate(player1, onPlanet1, Quaternion.identity) as GameObject;
        GameObject newGO2 = Instantiate(player2, onPlanet2, Quaternion.identity) as GameObject;

    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

}
