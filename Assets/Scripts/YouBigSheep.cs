using UnityEngine;
using UnityEngine.InputSystem;
using AdeliesGayDialogueSystem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
public class YouBigSheep : MonoBehaviour
{
    [TextArea]
    public string[] dialogues;

    public GameObject firstPersonCam;
    public float speed = 1f;
    public float sensitivity = 1f;
    public float x;
    public float z;

    float xRot;
    float yRot;

    public List<char> charIds = new List<char>();
    public List<Sprite> sprites = new List<Sprite>();
    public List<string> names = new List<string>();

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
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        transform.position = transform.position + new Vector3(firstPersonCam.transform.forward.x, 0f, firstPersonCam.transform.forward.z) * z * speed * Time.deltaTime;
        transform.position = transform.position + new Vector3(firstPersonCam.transform.right.x, 0f, firstPersonCam.transform.right.z) * x * speed * Time.deltaTime;
    }
    private void RageModeACTIVATE()
    {
        float newSpeed = PwnageManager.rageMeter % 20;
        if (newSpeed <= 1f)
        {
            speed = 1f;
        }
        else
        {
            speed = newSpeed;
        }
    }
    public void OnNotify()
    {

    }

}
