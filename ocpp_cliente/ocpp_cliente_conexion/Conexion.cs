using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworksApi.TCP.CLIENT;
using System.Net;

namespace ocpp_cliente_conexion
{
    public class Conexion
    {
        Client objClient;

        public Conexion(string vIPServidor, string vPuertoServidor, string vIPPuntoCarga)
        {
            objClient = new Client();
            objClient.ClientName = vIPPuntoCarga;
            objClient.ServerIp = vIPServidor;
            objClient.ServerPort = vPuertoServidor;

            objClient.OnClientConnected += new OnClientConnectedDelegate(objCliente_OnClientConnected);
            objClient.OnClientConnecting += new OnClientConnectingDelegate(objCliente_OnClientConnecting);
            objClient.OnClientDisconnected += new OnClientDisconnectedDelegate(obCliente_OnClientDisconnected);
            objClient.OnClientError += new OnClientErrorDelegate(objCliente_OnClientError);            
            objClient.OnDataReceived += new OnClientReceivedDelegate(objCliente_OnDataReceived);

            objClient.Connect();
            Console.WriteLine("Cliente iniciado...");
        }

        private void objCliente_OnClientConnected(object Sender, ClientConnectedArguments R)
        {
            Console.WriteLine("Conectado: " + R.EventMessage);
        }

        //Si nos estamos conectando al servidor actualizará el log.
        private void objCliente_OnClientConnecting(object Sender, ClientConnectingArguments R)
        {
            Console.WriteLine("Conectando: " + R.EventMessage);
        }

        //Si desconectamos un cliente actualizará el log.
        private void obCliente_OnClientDisconnected(object Sender, ClientDisconnectedArguments R)
        {
            Console.WriteLine("Desconectado: " + R.EventMessage);
        }

        private void objCliente_OnClientError(object Sender, ClientErrorArguments R)
        {
            Console.WriteLine("Error: " + R.ErrorMessage);
        }

        private void objCliente_OnDataReceived(object Sender, ClientReceivedArguments R)
        {
            Console.WriteLine(R.ReceivedData);
        }

        public void desconectarCliente()
        {
            objClient.Disconnect();
        }

        public bool enviarMensajeServidor(string vMensajeCliente)
        {
            bool estado = false;
            Console.WriteLine("Se enviará mensaje desde cliente: " + estado);
            objClient.Send(vMensajeCliente);
            estado = true;
            Console.WriteLine("Estado conexion con servidor: " + estado);

            return estado;
        }
               
    }
}
