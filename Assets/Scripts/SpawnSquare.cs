using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static WorldObjects;
using Networking;

public class SpawnSquare : MonoBehaviour
{

    public static void Spawn (Vector2 pos, GameObject obj) {

        Debug.Log("Spawn");

        int intX = (int)pos.x;
        int intY = (int)pos.y;

        bool objFinded = WorldObjects.getObjFromDict(intX, intY, obj);

        if (!objFinded) {

            WorldObjects.Add(intX, intY, obj);

        } else {

            WorldObjects.Delete(intX, intY);

        }


    }

    public static void SpawnAll () {

        foreach(KeyValuePair<int, Dictionary<int, GameObject>> xValues in WorldObjects.WorldMatrix) {
            foreach(KeyValuePair<int, GameObject> yObj in xValues.Value) {

                Vector2 pos = new Vector2(xValues.Key, yObj.Key);
                //Spawn (pos);

            }
        }


    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
