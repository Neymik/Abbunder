using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;


public class WorldObjects : MonoBehaviour {

    public static Dictionary<int, Dictionary<int, GameObject>> WorldMatrix = new Dictionary<int, Dictionary<int, GameObject>>();

    public static bool getObjFromDict(int x, int y, GameObject obj) {

        Dictionary<int, GameObject> jopa;
        bool retValue = false;

        if (WorldMatrix.TryGetValue(x, out jopa)) {
            if (WorldMatrix[x].TryGetValue(y, out obj)) {
                retValue = true;
                //retValue = WorldMatrix[x][y];
            }
        }

        return retValue;

    }


    public static void Add (int x, int y, GameObject obj) {

        Vector2 pos = new Vector2();
        pos.x = x;
        pos.y = y;

        obj = Instantiate(obj, pos, Quaternion.identity);
        obj.GetComponent<NetworkObject>().Spawn();

        Dictionary<int, GameObject> jopa;

        if (!WorldMatrix.TryGetValue(x, out jopa)) {
            jopa = new Dictionary<int, GameObject>();
            WorldMatrix.Add(x, jopa);
        }

        WorldMatrix[x].Add(y, obj);

    }

    public static void Delete(int x, int y) {

        Destroy(WorldMatrix[x][y]);
        WorldMatrix[x].Remove(y);    

    }


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

}
