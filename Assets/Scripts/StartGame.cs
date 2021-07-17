using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Transports.UNET;

public class StartGame : MonoBehaviour
{
  public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
      NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = IPManager.ip;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
