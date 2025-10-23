using UnityEngine;
using UnityEngine.InputSystem;
using AdeliesGayDialogueSystem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
public class YouBigSheep : MonoBehaviour
{
    [TextArea]
    public string[] dialogues;

    public GameObject firstPersonCam;
    public float speed = 1f;
    public float sensitivity = 1f;
    public float x;
    public float z;
    public float ragelevel =0f;



    public Command command;
    public Color[] floorcolors;
    public Color[] skycolors;
    public GameObject[] enemies;

    float xRot;
    float yRot;

    public List<char> charIds = new List<char>();
    public List<Sprite> sprites = new List<Sprite>();
    public List<string> names = new List<string>();

    public TMP_Text rageText;
    public TMP_Text hornyText;

    

    public DialogueDeliverer dialogue;

    private void Awake()
    {
        dialogue = new DialogueDeliverer(charIds, sprites, names);
    }

    private void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            command.NewDimension(floorcolors[0], skycolors[0], enemies[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            command.NewDimension(floorcolors[0], skycolors[0], enemies[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            command.NewDimension(floorcolors[0], skycolors[0], enemies[0]);
        }


        hornyText.text = "Your current horniness is at: "+PwnageManager.hornyMeter + "%!";
        rageText.text = "YOUR CURRENT RAGE IS AT "+PwnageManager.rageMeter + "%!";
        ragelevel = PwnageManager.rageMeter / 20f;

        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        transform.position = transform.position + new Vector3(firstPersonCam.transform.forward.x, 0f, firstPersonCam.transform.forward.z) * z * speed * Time.deltaTime * (1f + ragelevel * 0.1f);
        transform.position = transform.position + new Vector3(firstPersonCam.transform.right.x, 0f, firstPersonCam.transform.right.z) * x * speed * Time.deltaTime * (1f+ragelevel*0.1f);
    }
    
    private void RageModeACTIVATE()
    {
        
    }
    public void OnNotify()
    {

    }

}
