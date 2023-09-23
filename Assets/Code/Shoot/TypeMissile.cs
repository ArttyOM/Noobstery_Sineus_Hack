using UnityEngine;

public class TypeMissile : MonoBehaviour
{
    /* Сокрость (force)
     1 - низкая
    2 - средняя
    3 - высокая
    4 - очень высокая
    p.s: Как вы будите использовать я без понятия :D (ваш любимый джун ^^)
     */

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
            case typeOfMissile.cutlery:
                level = 2; numberOfShells = 10; damage = 1; numberOfRes = 2; force = 3;
                break;
            case typeOfMissile.ray:
                level = 2; numberOfShells = 1; damage = 10; numberOfRes = 5; force = 4;
                break;
            case typeOfMissile.lemon:
                level = 2; numberOfShells = 1; damage = 2; numberOfRes = 4; force = 1;
                break;
            case typeOfMissile.shuriken:
                level = 2; numberOfShells = 3; damage = 1; numberOfRes = 2; force = 2;
                break;
            case typeOfMissile.spear:
                level = 1; numberOfShells = 1; damage = 1; numberOfRes = 1; force = 1;
                break;
            case typeOfMissile.drone:
                level = 3; numberOfShells = 1; damage = 4; numberOfRes = 8; force = 2;
                break;
            case typeOfMissile.aliens:
                level = 3; numberOfShells = 1; damage = 3; numberOfRes = 15; force = 2;
                break;
            case typeOfMissile.octopus:
                level = 1; numberOfShells = 1; damage = 1; numberOfRes = 1; force = 1;
                break;
            case typeOfMissile.alienRokect:
                level = 3; numberOfShells = 1; damage = 4; numberOfRes = 9; force = 3;
                break;
            case typeOfMissile.rocket2:
                level = 3; numberOfShells = 1; damage = 7; numberOfRes = 6; force = 4;
                break;
        }
    }
}
