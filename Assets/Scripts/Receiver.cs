using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{
    private Stack<Color> floors = new Stack<Color>();
    private Stack<Color> skies = new Stack<Color>();
    private Stack<GameObject> enemies = new Stack<GameObject>();


    public void NewColor(Color floor, Color sky, GameObject enemy)
    {
        floors.Push(floor);
        skies.Push(sky);
        enemies.Push(enemy);
    }

    public void UnColor()
    {
        floors.Pop(); skies.Pop() ; enemies.Pop() ;
    }

    public Color FloorCheck()
    {
        
        return floors.Peek();

    }
    public Color SkyCheck()
    {
        return skies.Peek();
    }

    public GameObject EnemyCheck()
    {
        if (enemies.Count != 0)
        {
            return enemies.Peek();
        }
        else
        {
            return null;
        }
    }

}
