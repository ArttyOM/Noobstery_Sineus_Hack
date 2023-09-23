using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeMissile : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private int numberOfShells;
    [SerializeField] private int damage;
    [SerializeField] private int numberOfRes;
    [SerializeField] private int force;

    public enum typeOfMissile
    {
        stone,
        rubberDuck,
        core,
        rocket,
        cutlery,
        ray,
        lemon,
        shuriken,
        spear,
        drone,
        aliens,
        octopus,
        alienRokect,
        rocket2
    }
    public typeOfMissile typeMissile;

    private void Update()
    {
        switch(typeMissile)
        {
            case typeOfMissile.stone:
                level = 1; numberOfShells = 1; damage = 2; numberOfRes = 1; force = 1;
                break;
            case typeOfMissile.rubberDuck:
                level = 1; numberOfShells = 1; damage = 1; numberOfRes = 1; force = 1;
                break;
            case typeOfMissile.core:
                level = 2; numberOfShells = 1; damage = 4; numberOfRes = 2; force = 2;
                break;
            case typeOfMissile.rocket:
                level = 3; numberOfShells = 3; damage = 6; numberOfRes = 2; force = 3;
                break;
        }
    }
}
