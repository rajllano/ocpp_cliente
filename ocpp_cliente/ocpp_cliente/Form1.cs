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
using System.Runtime.InteropServices;

namespace ocpp_cliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Json j = new ocpp_cliente_conexion.Json();
            Win32.AllocConsole();

            j.Serializar();
            j.DesSerializar();
        }

        public class Win32
        {
            [DllImport("kernel32.dll")]
            public static extern Boolean AllocConsole();
            [DllImport("kernel32.dll")]
            public static extern Boolean FreeConsole();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
