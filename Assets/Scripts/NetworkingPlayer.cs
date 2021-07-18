using System;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using UnityEngine;

using static WorldObjects;
using static SpawnSquare;

namespace Networking {

    public class NetworkingPlayer : NetworkBehaviour
    {

        public GameObject newObj;

        public NetworkVariableVector2 Position = new NetworkVariableVector2(new NetworkVariableSettings
        {
            WritePermission = NetworkVariablePermission.ServerOnly,
            ReadPermission = NetworkVariablePermission.Everyone
        });

        public override void NetworkStart()
        {
            SetWorldObjects();
        }


        public void SetWorldObjects()
        {
            if (NetworkManager.Singleton.IsServer)
            {
                var randomPosition = GetRandomPositionOnPlane();
                Debug.Log(randomPosition);
                transform.position = randomPosition;
                Position.Value = randomPosition;
            }
            else
            {
                SubmitSetWorldObjectsServerRpc();
            }
        }

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

        [ServerRpc]
        void SubmitSetWorldObjectsServerRpc(ServerRpcParams rpcParams = default)
        {
            Position.Value = GetRandomPositionOnPlane();
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
        }


        static Vector2 GetRandomPositionOnPlane()
        {
            return new Vector2(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-5, 5));
        }

        void Update()
        {
            transform.position = Position.Value;

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