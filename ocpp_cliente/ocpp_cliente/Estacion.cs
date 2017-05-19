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
using ocpp_cliente_modelo;
using System.Threading;

namespace ocpp_cliente
{
    public partial class Estacion : Form
    {
        //public Conexion clienteWebSocket;
        public string IPSERVIDOR;
        public string PUERTOSERVIDOR;
        public string IPPUNTOCARGA;
        public ReservaJson data;
        
        public Estacion()
        {
            InitializeComponent();
        }

        private void Estacion_Load(object sender, EventArgs e)
        {
            IPSERVIDOR = obtenerIp();
            PUERTOSERVIDOR = "90";
            IPPUNTOCARGA = obtenerIp();
            Conexion.IniciarCliente(IPSERVIDOR,  IPPUNTOCARGA, PUERTOSERVIDOR);
            data = new ReservaJson();
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
            Conexion.enviarMensajeServidor("Dato" + txtNumeroSerie.Text);

            data = Conexion.listadoReserva2;

            this.dgReserva.Columns.Clear();
            this.dgReserva.Columns.Add("Id", "Id");
            this.dgReserva.Columns.Add("NumeroSerie", "NumeroSerie");
            this.dgReserva.Columns.Add("Marca", "Marca");
            this.dgReserva.Columns.Add("Modelo", "Modelo");
            this.dgReserva.Columns.Add("FechaHora", "FechaHora");
            this.dgReserva.Columns.Add("FechaRegistro", "FechaRegistro");
            this.dgReserva.Columns.Add("Tiempo", "Tiempo");
            this.dgReserva.Columns.Add("ValorRecarga", "ValorRecarga");
            this.dgReserva.Columns.Add("EnergiaRecarga", "EnergiaRecarga");

            this.dgReserva.Rows.Add(data.Id, data.NumeroSerie, data.Marca, data.Modelo, data.FechaHora, data.FechaRegistro, data.Tiempo, data.ValorRecarga, data.EnergiaRecarga);
            btCargar.Enabled = true;
        }

        private void btCargar_Click(object sender, EventArgs e)
        {
            lblValorCarga.Visible = true;

            for (int i = 0; i < 100; i++)
            {   
                lblValorCarga.Text = i.ToString() + " %";
                Thread.Sleep(10);
            }
        }
    }
}
