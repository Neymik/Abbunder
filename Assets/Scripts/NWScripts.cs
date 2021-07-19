using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

namespace Networking {
    public class NWScripts : NetworkBehaviour
    {
        public GameObject newObj;


        public void NetworkingSpawn(float x, float y)
        {

            Debug.Log(NetworkManager.Singleton.IsServer);

            if (NetworkManager.Singleton.IsServer)
            {
                ServerSpawn (x, y);
            }
            else
            {
                SpawnActionServerRpc(x, y);
            }
        }


        [ClientRpc]
        void SpawnActionClientRpc(float x, float y, ClientRpcParams rpcParams = default)
        {
            // Debug.Log("SpawnActionClientRpc");
            // Vector2 worldPosition = new Vector2(x, y);
            // SpawnSquare.Spawn(worldPosition, newObj);
        }

        [ServerRpc(RequireOwnership = false)]
        void SpawnActionServerRpc(float x, float y, ServerRpcParams rpcParams = default)
        {
            Debug.Log("SpawnActionServerRpc IsServer " + NetworkManager.Singleton.IsServer);

            if (NetworkManager.Singleton.IsServer) {
                ServerSpawn (x, y);

            } else {
                
                Vector2 worldPosition = new Vector2(x, y);
                SpawnSquare.Spawn(worldPosition, newObj);
            }
            
        }

        void ServerSpawn (float x, float y) {
            Vector2 worldPosition = new Vector2(x, y);
            SpawnSquare.Spawn(worldPosition, newObj);
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
