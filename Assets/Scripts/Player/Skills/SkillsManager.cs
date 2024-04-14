using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
   public static SkillsManager instance;
   // public Player player = Player.instance;

   [Header("Skills")]
   public Dash dash;
   public Mirage mirage;
   public ThrowSword throwSword;
   [Header("Bool")]
   public bool MirageAttack;
   public bool haveThrowSword;
   void Awake()
   {
    instance = this;
    dash = GetComponent<Dash>();
    mirage = GetComponent<Mirage>();
    throwSword = GetComponent<ThrowSword>();
    throwSword.generateDots();
   }

  

   
}
