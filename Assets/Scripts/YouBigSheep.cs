using UnityEngine;
using UnityEngine.InputSystem;
using AdeliesGayDialogueSystem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
public class YouBigSheep : MonoBehaviour
{
    public RealEvent eventMan;

    [TextArea]
    public string[] dialogues;

    public GameObject firstPersonCam;
    public float speed = 1f;
    public float sensitivity = 1f;
    public float x;
    public float z;
    public float ragelevel =0f;

    public GameObject dialogueboximage;

    public Command command;
    public Color[] floorcolors;
    public Color[] skycolors;

    float xRot;
    float yRot;

    public List<char> charIds = new List<char>();
    public List<Sprite> sprites = new List<Sprite>();
    public List<string> names = new List<string>();

    public TMP_Text rageText;
    public TMP_Text hornyText;
    public bool movementLock = true;
    public GameObject dialoguebox;
    int counter=0;

    int paused = 0;
    

    public DialogueDeliverer dialogue;

    private void Awake()
    {
        dialogue = new DialogueDeliverer(charIds, sprites, names, dialoguebox);
        eventMan.OnGamePaused += PauseControl;
        eventMan.OnGameUnpaused += UnpauseControl;
    }

    private void OnDestroy()
    {
        eventMan.OnGamePaused -= PauseControl;
        eventMan.OnGameUnpaused -= UnpauseControl;
    }

    private void Start()
    {
        eventMan.GamePaused();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        dialogue.StartDialogue(dialogues[0]);
        FindFirstObjectByType<CameraScript>().paused = true;
        FindFirstObjectByType<PwnageManager>().paused = true;
    }

    private void PauseControl()
    {
        movementLock = true;
    }

    private void UnpauseControl()
    {
        movementLock = false;
        if (paused == 0)
        {
            paused++;
        }
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (paused ==1)
            {
                eventMan.GamePaused();
                paused++;
            }
            else if (paused==2)
            {
                eventMan.GameUnpaused();
                paused--;
            }
        }

        if (!movementLock)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                command.NewDimension(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                command.NewDimension(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                command.NewDimension(2);
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                command.UndoDimension();
            }

            hornyText.text = "Your current horniness is at: " + PwnageManager.hornyMeter + "%!";
            rageText.text = "YOUR CURRENT RAGE IS AT " + PwnageManager.rageMeter + "%!";
            ragelevel = PwnageManager.rageMeter / 20f;

            x = Input.GetAxisRaw("Horizontal");
            z = Input.GetAxisRaw("Vertical");


            

            transform.position = transform.position + new Vector3(firstPersonCam.transform.forward.x, 0f, firstPersonCam.transform.forward.z) * z * speed * Time.deltaTime * (1f + ragelevel * 0.1f);
            
            transform.position = transform.position + new Vector3(firstPersonCam.transform.right.x, 0f, firstPersonCam.transform.right.z) * x * speed * Time.deltaTime * (1f + ragelevel * 0.1f);

            if (transform.position.x > 58f)
            {
                transform.position = new Vector3(58f, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -58f)
            {
                transform.position = new Vector3(-58f, transform.position.y, transform.position.z);
            }
            if (transform.position.z > 28.5f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 28.5f);
            }
            if (transform.position.z < -48.5f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -48.5f);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                counter++;
                dialogue.AdvanceDialogue();
                if (counter > 2)
                {
                    eventMan.GameUnpaused();
                    dialogueboximage.SetActive(false);
                    FindFirstObjectByType<CameraScript>().paused = false;
                    FindFirstObjectByType<PwnageManager>().paused = false;
                }
            }
            
        }
    }
    
    private void RageModeACTIVATE()
    {
        
    }
    public void OnNotify()
    {

    }

}
