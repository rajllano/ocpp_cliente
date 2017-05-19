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
using ocpp_cliente_modelo;

namespace ocpp_cliente_control
{
    public static class Conexion
    {
        private static Client objClient = null;
        public static ReservaJson listadoReserva2 = null;

        public static void IniciarCliente(string vIPPuntoCarga, string vIPServidor, string vPuertoServidor)
        {
            listadoReserva2 = new ReservaJson();
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

        private static void objCliente_OnClientConnected(object Sender, ClientConnectedArguments R)
        {
            Console.WriteLine("Conectado: " + R.EventMessage);
        }

        //Si nos estamos conectando al servidor actualizará el log.
        private static void objCliente_OnClientConnecting(object Sender, ClientConnectingArguments R)
        {
            Console.WriteLine("Conectando: " + R.EventMessage);
        }

        //Si desconectamos un cliente actualizará el log.
        private static void obCliente_OnClientDisconnected(object Sender, ClientDisconnectedArguments R)
        {
            Console.WriteLine("Desconectado: " + R.EventMessage);
        }

        private static void objCliente_OnClientError(object Sender, ClientErrorArguments R)
        {
            Console.WriteLine("Error: " + R.ErrorMessage);
        }

        private static void objCliente_OnDataReceived(object Sender, ClientReceivedArguments R)
        {
            Console.WriteLine(R.ReceivedData);
            Console.WriteLine("recibio reserva");
            ReservaJson rev =  Json.DeserializarReservasMartillado(R.ReceivedData);
            listadoReserva2 = rev;
        }

        public static void desconectarCliente()
        {
            objClient.Disconnect();
        }

        public static bool enviarMensajeServidor(string vMensajeCliente)
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
