using UnityEngine;
using UnityEngine.Rendering;

public class Command : MonoBehaviour
{
    public Color defaultFloor;
    public Color defaultSky;
    public GameObject defaultEnemies;

    public GameObject currentEnemies;

    public Receiver receiver;
    public Camera cam;
    public MeshRenderer floor;

    private void Awake()
    {
        this.defaultFloor = floor.material.color;
        this.defaultSky = RenderSettings.skybox.color;
        currentEnemies = defaultEnemies;
        
    }
    public Command(Color defaultFloor, Color defaultSky, GameObject defaultEnemies)
    {
        this.defaultFloor = defaultFloor;
        this.defaultSky = defaultSky;
        this.defaultEnemies = defaultEnemies;
    }

    public void NewDimension(Color floor, Color sky, GameObject newEnemies)
    {
        this.floor.material.color = floor;
        RenderSettings.skybox.color=sky;
        receiver.NewColor(floor, sky, newEnemies);
        currentEnemies.SetActive(false);
        currentEnemies = newEnemies;
        currentEnemies.SetActive(true);

    }

    public void UndoDimension()
    {
        if (receiver.FloorCheck() != null)
        {
            
            receiver.UnColor();
            if (receiver.FloorCheck() != null)
            {
                this.floor.material.color = receiver.FloorCheck();
                RenderSettings.skybox.color = receiver.SkyCheck();
                currentEnemies.SetActive(false);
                currentEnemies = receiver.EnemyCheck();
                currentEnemies.SetActive(true);
            }
            else
            {
                floor.material.color = defaultFloor;
                RenderSettings.skybox.color = defaultSky;
                currentEnemies.SetActive(false);
                currentEnemies = defaultEnemies;
                currentEnemies.SetActive(true);

            }
        }
        else
        {
            floor.material.color = defaultFloor;
            RenderSettings.skybox.color = defaultSky;
            currentEnemies.SetActive(false);
            currentEnemies = defaultEnemies;
            currentEnemies.SetActive(true);
        }
    }
}
