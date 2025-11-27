using UnityEngine;
using UnityEngine.Rendering;

public class Command : MonoBehaviour
{
    public RealEvent events;

    public Color defaultFloor;
    public Color defaultSky;


    public Color[] floorcolors;
    public Color[] skycolors;

    public GameObject[] setDressings;


    public Receiver receiver;
    public Camera cam;
    public MeshRenderer floor;

    private void Awake()
    {
        this.defaultFloor = floor.material.color;
        this.defaultSky = RenderSettings.skybox.GetColor("_SkyTint");
        
    }
    public Command(int newDim)
    {
        this.defaultFloor = floorcolors[newDim];
        this.defaultSky = skycolors[newDim];
        events.SceneSwitched(newDim);
    }

    public void NewDimension(int newDim)
    {
        if (floorcolors[newDim] != this.floor.material.color)
        {
            this.floor.material.color = floorcolors[newDim];
            if (RenderSettings.skybox.HasProperty("_SkyTint"))
            {
                RenderSettings.skybox.SetColor("_SkyTint", skycolors[newDim]);
                DynamicGI.UpdateEnvironment();
            }
            /*
            var spawners = FindObjectsOfType(typeof(EnemySpawner));
            foreach(EnemySpawner spawner in spawners)
            {
                if (spawner.dimension != newDim)
                {
                    foreach (MonoBehaviour e in spawner.enemies)
                    {

                        e.gameObject.SetActive(false);
                    }
                }
                else
                {
                    foreach (MonoBehaviour e in spawner.enemies)
                    {

                        e.gameObject.SetActive(true);
                    }
                }
            }
            */
            receiver.NewDim(newDim);
            
            }
        
        events.SceneSwitched(newDim);
    }

    public void UndoDimension()
    {
        if (!receiver.EmptyCheck())
        {
            receiver.GoBack();
            if (!receiver.EmptyCheck())
            {
                int oldDim = receiver.DimensionCheck();
                this.floor.material.color = floorcolors[oldDim];
                if (RenderSettings.skybox.HasProperty("_SkyTint"))
                {
                    RenderSettings.skybox.SetColor("_SkyTint", skycolors[oldDim]);
                };
                events.SceneSwitched(oldDim);
            }
            else
            {
                floor.material.color = defaultFloor;
                if (RenderSettings.skybox.HasProperty("_SkyTint"))
                {
                    RenderSettings.skybox.SetColor("_SkyTint", defaultSky);
                }
                events.SceneSwitched(-1);

            }
        }
        else
        {
            floor.material.color = defaultFloor;
            if (RenderSettings.skybox.HasProperty("_SkyTint"))
            {
                RenderSettings.skybox.SetColor("_SkyTint", defaultSky);
            }
            events.SceneSwitched(-1);
        }
    }
}
