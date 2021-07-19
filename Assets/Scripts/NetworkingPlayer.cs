using System;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using UnityEngine;

namespace Networking {

    public class NetworkingPlayer : NetworkBehaviour
    {

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

        

        [ServerRpc]
        void SubmitSetWorldObjectsServerRpc(ServerRpcParams rpcParams = default)
        {
            Position.Value = GetRandomPositionOnPlane();
        }

        static Vector2 GetRandomPositionOnPlane()
        {
            return new Vector2(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-5, 5));
        }

        void Update()
        {

            if (IsLocalPlayer) {

                playerMove ();

            }

        }

        void playerMove () {

            if (Input.GetMouseButtonDown(0)) {

                Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

                worldPosition.x = (float)(Math.Round(worldPosition.x));
                worldPosition.y = (float)(Math.Round(worldPosition.y));

                transform.position = worldPosition;

            }

        }

    }
}