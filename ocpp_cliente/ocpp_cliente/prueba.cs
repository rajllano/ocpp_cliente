using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ocpp_cliente_conexion;
using System.Net;

namespace ocpp_cliente
{
    public partial class prueba : Form
    {
        public Conexion clienteWebSocket;
        public string IPSERVIDOR;
        public string PUERTOSERVIDOR;
        public string IPPUNTOCARGA;

        public prueba()
        {
            InitializeComponent();
        }

        private void prueba_Load(object sender, EventArgs e)
        {
            IPSERVIDOR = obtenerIp();
            PUERTOSERVIDOR = "90";
            IPPUNTOCARGA = obtenerIp();
            clienteWebSocket = new Conexion(IPSERVIDOR, PUERTOSERVIDOR, IPPUNTOCARGA);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clienteWebSocket.enviarMensajeServidor("Envio de Mensaje de prueba cliente...");
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
