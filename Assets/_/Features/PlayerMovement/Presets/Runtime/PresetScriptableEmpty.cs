using System;
using UnityEngine;

public enum Preset
{
   None, 
   Basic
}
[CreateAssetMenu(menuName = "Player Value Presets/Empty")]
public class PresetScriptableEmpty : ScriptableObject
{
   public Preset m_presets;
   
   public float m_moveSpeed;
   public float m_sprintMultiplicator;

   public float m_dashForce;
   public float m_dashTime;

   public float m_jumpForce;
   public float m_gravityMultiplier;
   
   private void OnValidate()
   {
      switch (m_presets)
      {
         case Preset.None:
            Reset();
            break;
         case Preset.Basic:
            Basic();
            break;
         default:
            throw new ArgumentOutOfRangeException();
      }
   }

   private void Reset()
   {
      m_moveSpeed = 0f;
      m_sprintMultiplicator = 0f;
      
      m_dashForce = 0f;
      m_dashTime = 0f;
      
      m_jumpForce = 0f;
      m_gravityMultiplier = 0f;
   }
   
   private void Basic()
   {
      m_moveSpeed = 25f;
      m_sprintMultiplicator = 2f;
      
      m_dashForce = 75;
      m_dashTime = 0.2f;
      
      m_jumpForce = 8f;
      m_gravityMultiplier = 4f;
   }
   
}
