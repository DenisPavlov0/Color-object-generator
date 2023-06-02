using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeCreator : MonoBehaviour
{
   [SerializeField] 
   private GameObject _cube;

   private void Update()
   {
      if (Input.GetKey(KeyCode.Space))
      {
         var newCube = Instantiate(_cube);
         newCube.transform.position = new Vector3(Random.Range(-15, 15), 25, 10);
      }
   }
}
