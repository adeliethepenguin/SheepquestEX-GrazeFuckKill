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
        this.defaultSky = RenderSettings.skybox.GetColor("_SkyTint");
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
        if (floor != this.floor.material.color)
        {
            this.floor.material.color = floor;
            if (RenderSettings.skybox.HasProperty("_SkyTint"))
            {
                RenderSettings.skybox.SetColor("_SkyTint", sky);
                DynamicGI.UpdateEnvironment();
            }
            receiver.NewColor(floor, sky, newEnemies);
            currentEnemies.SetActive(false);
            currentEnemies = newEnemies;
            currentEnemies.SetActive(true);
        }
    }

    public void UndoDimension()
    {
        if (receiver.EnemyCheck() != null)
        {
            
            receiver.UnColor();
            if (receiver.EnemyCheck() != null)
            {
                this.floor.material.color = receiver.FloorCheck();
                if (RenderSettings.skybox.HasProperty("_SkyTint"))
                {
                    RenderSettings.skybox.SetColor("_SkyTint", receiver.SkyCheck());
                };
                currentEnemies.SetActive(false);
                currentEnemies = receiver.EnemyCheck();
                currentEnemies.SetActive(true);
            }
            else
            {
                floor.material.color = defaultFloor;
                if (RenderSettings.skybox.HasProperty("_SkyTint"))
                {
                    RenderSettings.skybox.SetColor("_SkyTint", defaultSky);
                }
                currentEnemies.SetActive(false);
                currentEnemies = defaultEnemies;
                currentEnemies.SetActive(true);

            }
        }
        else
        {
            floor.material.color = defaultFloor;
            if (RenderSettings.skybox.HasProperty("_SkyTint"))
            {
                RenderSettings.skybox.SetColor("_SkyTint", defaultSky);
            }
            currentEnemies.SetActive(false);
            currentEnemies = defaultEnemies;
            currentEnemies.SetActive(true);
        }
    }
}
