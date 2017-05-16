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
        private string _IPPuntoCarga;
        private string _puertoPuntoCarga;
        private string _IPServidor;
        private string _puertoServidor;
        Client objClient;

        public string IP_PUNTO_CARGA
        {
            set
            {
                _IPPuntoCarga = value;
            }
            get
            {
                return this._IPPuntoCarga;
            }
        }

        public string PUERTO_PUNTO_CARGA
        {
            set
            {
                _puertoPuntoCarga = value;
            }
            get
            {
                return this._puertoPuntoCarga;
            }
        }

        private string IP_SERVIDOR
        {
            set
            {
                _IPServidor = value;
            }
            get
            {
                return this._IPServidor;
            }
        }

        private string PUERTO_SERVIDOR
        {
            set
            {
                _puertoServidor = value;
            }
            get
            {
                return this._puertoServidor;
            }
        }
        
        public Conexion()
        {
            this.IP_PUNTO_CARGA = obtenerIp();
            this.PUERTO_PUNTO_CARGA = "90";
            this.IP_SERVIDOR = obtenerIp();
            this.PUERTO_SERVIDOR = "90";

            objClient = new Client();
            objClient.ClientName = this.IP_PUNTO_CARGA;
            objClient.ServerIp = this.IP_PUNTO_CARGA;
            objClient.ServerPort = this.PUERTO_PUNTO_CARGA;            
            objClient.OnDataReceived += new OnClientReceivedDelegate(cliente_OnDataReceived);
            objClient.Connect();
        }

        private void cliente_OnDataReceived(object Sender, ClientReceivedArguments R)
        {
            Console.WriteLine(R.ReceivedData);
        }


        public bool enviarMensajeServidor(string vNombrePuntoCarga, string vMensaje)
        {
            bool estadoConexion;

            if (objClient.IsConnected)
            {
                try
                {                    
                    estadoConexion = true;
                    objClient.Send(vMensaje);
                    Console.WriteLine("Estado conexion con servidor: " + estadoConexion);
                }
                catch (Exception ex)
                {
                    estadoConexion = false;
                    Console.WriteLine("Error: " + ex.Message);
                    //.Mensaje += ex.Message;
                }
                finally
                {
                    objClient.Disconnect();
                    //ControlLog.Registrar(r);
                }                
            }
            else
            {
                Console.WriteLine("Servidor no conectado...");
                estadoConexion = false;
            }

            return estadoConexion;
        }



        public string obtenerIp()
        {
            string IPLocal = "0.0.0.0";
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    IPLocal = ip.ToString();
                }
            }

            return IPLocal;
        }

    }
}
