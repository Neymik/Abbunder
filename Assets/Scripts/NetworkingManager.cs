using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

using static SpawnSquare;

namespace Networking {
    public class NetworkingManager : MonoBehaviour
    {

        public GameObject newObj;


        public void NetworkingSpawn(float x, float y)
        {

            Debug.Log(NetworkManager.Singleton.IsServer);

            if (NetworkManager.Singleton.IsServer)
            {
                SpawnActionClientRpc(x, y);
            }
            else
            {
                SpawnActionServerRpc(x, y);
            }
        }


        [ClientRpc ]
        void SpawnActionClientRpc(float x, float y, ClientRpcParams rpcParams = default)
        {

            Vector2 worldPosition = new Vector2(x, y);
            SpawnSquare.Spawn(worldPosition, newObj);

            

        }

        [ServerRpc]
        void SpawnActionServerRpc(float x, float y, ServerRpcParams rpcParams = default)
        {
            Vector2 worldPosition = new Vector2(x, y);
            SpawnSquare.Spawn(worldPosition, newObj);

            if (!NetworkManager.Singleton.IsServer) {
                SpawnActionClientRpc(x, y);
            }
            
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0)) {

                Debug.Log("Update");

                Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

                worldPosition.x = (float)(Math.Round(worldPosition.x));
                worldPosition.y = (float)(Math.Round(worldPosition.y));

                NetworkingSpawn(worldPosition.x, worldPosition.y);

                Debug.Log("UpdateEnd");

            }
        }
    }
}


