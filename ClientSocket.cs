using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

namespace RM
{
    class ClientSocket
    {
        private static byte[] result = new byte[1024];
        private static Socket clientSocket;
        public bool IsConnect = false;

        public ClientSocket()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }


        public void ConnectServer(string ip, int port)
        {
            IPAddress mIp = IPAddress.Parse(ip);
            IPEndPoint ipEndPoint = new IPEndPoint(mIp, port);

            try
            {
                clientSocket.Connect(ipEndPoint);
                IsConnect = true;
                Debug.Log("连接服务器成功");

            }
            catch (Exception)
            {
                IsConnect = false;
                Debug.Log("连接服务器失败");
                return;
            }
           
            Thread thread = new Thread(ClientConnectListen);
            thread.Start(clientSocket);
        }

        private static void ClientConnectListen(object clientSocket)
        {

            Debug.Log("connect succ");
            Socket mClientSocket = (Socket)clientSocket;
            //while (true)
            //{
                //try
                //{
                    int receiveLength = mClientSocket.Receive(result);
                    Debug.Log("receiveLength:" + receiveLength);

                //}
                //catch (Exception)
                //{
                //    Debug.Log("连接服务器失败2");
                //    return;
                //}
            //}
        }
        public void SendMessage(byte[] data)
        {
            clientSocket.Send(data);
        }

        private static byte[] WriteMessage(byte[] message)
        {
            return null;
        }
    }
}
