using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using UnityEngine;

public class OpentrackUdpReceiver : MonoBehaviour {
    private UdpClient udpClient;
    private IPEndPoint remoteEndPoint;
    private const int PORT = 4242;

    private double x = 0d;
    private double y = 0d;
    private double z = 0d;
    private double yaw = 0d;
    private double pitch = 0d;
    private double roll = 0d;

     void Start(){

        try{
            udpClient = new UdpClient(PORT);
            remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),PORT);

        }catch(Exception ex){
            Debug.Log($"UDP Error:{ex}");
        }

        udpClient.Client.ReceiveBufferSize = 64;

    }

    void Update(){

        if(udpClient == null || udpClient.Available <= 0){
            return;
        }

        byte[] data = udpClient.Receive(ref remoteEndPoint);

        if(data.Length >= 48){
            x = BitConverter.ToDouble(data, 0);
            y = BitConverter.ToDouble(data, 8);
            z = BitConverter.ToDouble(data, 16);
            yaw = BitConverter.ToDouble(data, 24);
            pitch = BitConverter.ToDouble(data, 32);
            roll = BitConverter.ToDouble(data, 40);
        }
    }

    void OnApplicationQuit(){
        udpClient.Close();
    }

    public float GetX(){
        return (float)x;
    }
    public float GetY(){
        return (float)y;
    }
    public float GetZ(){
        return (float)z;
    }

    public float GetYaw(){
        return (float)yaw;
    }
    public float GetPitch(){
        return (float)pitch;
    }
    public float GetRoll(){
        return (float)roll;
    }
}
