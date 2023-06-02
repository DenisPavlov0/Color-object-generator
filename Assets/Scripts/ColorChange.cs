using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorChange : MonoBehaviour
{
   [SerializeField] 
   private float _recoloringDuration = 2f;
   [SerializeField] 
   private float _dalayTime = 1f;
   [SerializeField] 
   private float _hueMin = 0f;
   [SerializeField] 
   private float _hueMax = 1f;
   [SerializeField] 
   private float _saturationMin = 0.6f;
   [SerializeField] 
   private float _saturationMax = 1f;
   [SerializeField] 
   private float _brightnessMin = 1f;
   [SerializeField] 
   private float _brightnessMax = 1f;

   private Color _startColor;
   private Color _nextColor;
   private Renderer _renderer;
   private float _recoloringTime;
   private float _delayTimeLeft;
  

   private void Awake()
   {
      _delayTimeLeft = _dalayTime;
      _renderer = GetComponent<Renderer>();
      GenerationNextColor();
   }
   private void GenerationNextColor()
   {
      _startColor = _renderer.material.color;
      _nextColor = Random.ColorHSV(_hueMin, _hueMax, 
         _saturationMin, _saturationMax, 
         _brightnessMin, _brightnessMax);
   }
   private void Update()
   {
      if (_delayTimeLeft > 0)
      {
         _delayTimeLeft -= Time.deltaTime;
         return;
      }
      _recoloringTime += Time.deltaTime;
      var progress = _recoloringTime / _recoloringDuration;
      var currentColor = Color.Lerp(_startColor, _nextColor, progress);
      _renderer.material.color = currentColor;
      if (_recoloringTime >= _recoloringDuration)
      {
         _recoloringTime = 0f;
         GenerationNextColor();
         _delayTimeLeft = _dalayTime;
      }
   }
}
