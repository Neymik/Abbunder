using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Transports.UNET;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = IPManager.ip;
      if (IPManager.game == "join") {
        NetworkManager.Singleton.StartClient();
      } else if (IPManager.game == "host") {
        NetworkManager.Singleton.StartHost();
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
