using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static WorldObjects;

public class SpawnSquare : MonoBehaviour
{


    public GameObject obj;
    public GameObject newObj;

    public void Spawn (Vector2 pos) {

        int intX = (int)pos.x;
        int intY = (int)pos.y;

        bool objFinded = WorldObjects.getObjFromDict(intX, intY, obj);

        if (!objFinded) {

            WorldObjects.Add(intX, intY, obj);

        } else {

            WorldObjects.Delete(intX, intY);

        }

        
        

    }

    // Start is called before the first frame update
    void Start()
    {
        newObj = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {

       
        if (Input.GetMouseButtonDown(0)) {

            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            worldPosition.x = (float)(Math.Round(worldPosition.x));
            worldPosition.y = (float)(Math.Round(worldPosition.y));

            this.Spawn(worldPosition);

        }


    }
}
