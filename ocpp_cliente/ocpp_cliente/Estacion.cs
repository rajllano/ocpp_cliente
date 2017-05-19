using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ocpp_cliente_control;
using System.Net;

namespace ocpp_cliente
{
    public partial class Estacion : Form
    {
        //public Conexion clienteWebSocket;
        public string IPSERVIDOR;
        public string PUERTOSERVIDOR;
        public string IPPUNTOCARGA;

        public Estacion()
        {
            InitializeComponent();
        }

        private void Estacion_Load(object sender, EventArgs e)
        {
            IPSERVIDOR = obtenerIp();
            PUERTOSERVIDOR = "90";
            IPPUNTOCARGA = obtenerIp();
            ocpp_cliente_control.Conexion.IniciarCliente(IPSERVIDOR,  IPPUNTOCARGA, PUERTOSERVIDOR);
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

        private void btConectar_Click(object sender, EventArgs e)
        {
            Json jReserva = new Json();
            jReserva.DeserializarReservas(txtNumeroSerie.Text);
        }
    }
}
