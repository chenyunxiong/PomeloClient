using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJson;
using Pomelo.DotNetClient;

public class PemoleManager : MonoBehaviour
{
    string host = "127.0.0.1";
    int port = 3010;
    string userName = "chenyunxiong";

    PomeloClient pomeloClient = new PomeloClient();

    void Start()
    {
        //listen on network state changed event
        pomeloClient.NetWorkStateChangedEvent += (state) =>
        {
            Debug.logger.Log("CurrentState is:" + state);
        };

        pomeloClient.initClient(host, port, () =>
        {
            //The user data is the handshake user params
            JsonObject user = new JsonObject();
            //user["uid"] = userName;
            pomeloClient.connect(user, data =>
            {
                //process handshake call back data
                JsonObject msg = new JsonObject();
                msg["uid"] = userName;
                pomeloClient.request("connector.entryHandler.entry", msg, OnQuery);
            });
        });
    }

    private void OnQuery(JsonObject data)
    {
        Debug.Log("data: " + data);
    }

    public void SendButtonOnClick()
    {
        Debug.Log("send button is clicked ..");

         JsonObject msg = new JsonObject();
         pomeloClient.request("connector.entryHandler.send", msg, SendFinish);
    }

    private void SendFinish(JsonObject data)
    {
        Debug.Log("recieve data: " + data);
    }
}
