using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCreator : MonoBehaviour
{
    [SerializeField] 
    private GameObject _sphere;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var newSphere = Instantiate(_sphere);
            newSphere.transform.position = new Vector3(Random.Range(-15, 15), 25, 10);
        }
    }
}
