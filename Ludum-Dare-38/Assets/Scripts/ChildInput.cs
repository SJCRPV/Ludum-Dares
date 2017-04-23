﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildInput : MonoBehaviour {

    [Range(0, 1)]
    public float force = 0.1f;
    [SerializeField]
    private int brushRadius = 10;
    [SerializeField]
    private bool isAlteringTerrain = true;
    [SerializeField]
    private bool isAlteringLiquids = false;
    [SerializeField]
    private bool isAlteringTemperature = false;
    [SerializeField]
    private bool isAlteringLife = false;

    private void alterLife(int buttonPressed, Ray inputRay)
    {
        throw new NotImplementedException();
    }

    private void alterTemperature(int buttonPressed, Ray inputRay)
    {
        throw new NotImplementedException();
    }

    private void alterLiquids(int buttonPressed, Ray inputRay)
    {
        bool isItWater;
        RaycastHit hit;

        if(Physics.Raycast(inputRay, out hit))
        {
            LiquidDeform deformer = hit.collider.GetComponent<LiquidDeform>();
            if(deformer && buttonPressed != 1)
            {
                Vector3 point = hit.point;
                point += hit.normal * brushRadius;
                deformer.deformLiquids(point, force, brushRadius);
            }

            isItWater = hit.collider.gameObject.layer == 4;
            if(isItWater && buttonPressed == 1)
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

    private void alterTerrain(int buttonPressed, Ray inputRay)
    {
        if (buttonPressed == 1)
        {
            force *= -1;
        }

        RaycastHit hit;

        if (Physics.Raycast(inputRay, out hit))
        {
            TerrainDeform deformer = hit.collider.GetComponent<TerrainDeform>();
            if (deformer)
            {
                Vector3 point = hit.point;
                point = deformer.getHeightMapPosition(point);
                deformer.deformTerrain(point, force, brushRadius);
            }
        }

        if (buttonPressed == 1)
        {
            force *= -1;
        }
    }

    private void handleInput(int buttonPressed)
    {

        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (isAlteringTerrain)
        {
            alterTerrain(buttonPressed, inputRay);
        }
        else if(isAlteringLiquids)
        {
            alterLiquids(buttonPressed, inputRay);
        }
        else if(isAlteringTemperature)
        {
            alterTemperature(buttonPressed, inputRay);
        }
        else if(isAlteringLife)
        {
            alterLife(buttonPressed, inputRay);
        }
        else
        {
            Debug.LogError("No alteration mode is selected");
        }
        
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //MouseButton(0) - Left Mouse
        //MouseButton(1) - Right Mouse
        if (Input.GetMouseButton(0))
        {
            handleInput(0);
        }
        else if(Input.GetMouseButton(1))
        {
            handleInput(1);
        }
    }
}
