using Google.Protobuf;
using Protobuf;
using RM;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MBTest : MonoBehaviour {

    ClientSocket socket;
    public void StartClient()
    {
        socket = new ClientSocket();
        socket.ConnectServer("127.0.0.1", 3000);
        Debug.LogWarning("StartClient...");
    }

    public void Send()
    {
        c_login p = new c_login();
        p.Username = "admin";
        p.Password = "123456";

        short code = 1001;

        byte[] intBytes3 = p.ToByteArray();
        short ss = (short)(intBytes3.Length + 2);

        byte[] intBytes1 = UtilByte.shortToBytes(ss);
        byte[] intBytes2 = UtilByte.shortToBytes(code);
        byte[] newArray  = new byte[2 + 2 + intBytes3.Length];
        
        Array.Copy(intBytes1, 0, newArray, 0, intBytes1.Length);
        Array.Copy(intBytes2, 0, newArray, intBytes1.Length, intBytes2.Length);
        Array.Copy(intBytes3, 0, newArray, intBytes1.Length + intBytes2.Length, intBytes3.Length);

        Debug.Log("ssssssssssssss="+ss+" lllll="+ intBytes1.Length);
        socket.SendMessage(newArray);
    }


    public GameObject goPanel;

    // Use this for initialization
    void Start () {

        var btnClient = goPanel.transform.Find("btnClient");
        var btnSend   = goPanel.transform.Find("btnSend");
        var cpClient = btnClient.GetComponent<Button>();
        var cpSend   = btnSend.GetComponent<Button>();
        
        cpClient.onClick.AddListener(StartClient);
        cpSend.onClick.AddListener(Send);

        var testGo = new GameObject();
        testGo.name = "testGo";
        testGo.AddComponent<NetTcpSock>();
        UnityEngine.Object.DontDestroyOnLoad(testGo);

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
