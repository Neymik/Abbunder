using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuButton : MonoBehaviour
{
  public Text name;
  public Text ip;

  public void join () {
    IPManager.ip = ip.text;
    IPManager.name = name.text;
    IPManager.game = "join";
    Application.LoadLevel("SampleScene");

  }

  public void create () {
    IPManager.game = "host";
    Application.LoadLevel("SampleScene");
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