﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parallax : MonoBehaviour
{

    public Transform[] backgrounds;         // Array (list) of all the backgrounds and foregrounds to be parallaxed
    private float[] parallaxScales;         // the proportion of the cameras movement to move the backgrounds by
    public float smoothing = 1f;            // how smooth the parallax is going to be. Must be above 0.

    private Transform cam;                  // reference to the main cameras transform
    private Vector3 previousCamPos;         // the position of the camera in the previous frame


    // Is called before Start(). Great for references.
    void Awake()
    {
        // set up camera reference

        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        // the previous frame had the current frames' camera position

        previousCamPos = cam.position;

        parallaxScales = new float[backgrounds.Length];

        // asigning corresponding parallaxScales

        for (int i = 0; i < backgrounds.Length; i++)
        {

            parallaxScales[i] = backgrounds[i].position.z * -1;

        }
    }

    // Update is called once per frame
    void Update()
    {
        // for each background

        for (int i = 0; i < backgrounds.Length; i++)
        {

            // the parallax is the opposite of the camera movement because the previous frame multiplied by the scale

            float parallax = (previousCamPos.y - cam.position.y) * parallaxScales[i];

            // ... set a target y position which is the current position plus the parallax

            float backgroundTargetPosY = backgrounds[i].position.y + parallax;

            // create a target position which is the background'S current position with it's target x position ... TODO also for y position

            Vector3 backgroundTargetPos = new Vector3(backgrounds[i].position.x, backgroundTargetPosY, backgrounds[i].position.z);

            // fade between current position and the target position using lerp

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }

        // set the previousCamPos to the camera's position at the ende of the frame

        previousCamPos = cam.position;


    }
}