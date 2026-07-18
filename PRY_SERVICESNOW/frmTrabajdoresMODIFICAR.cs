using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRY_SERVICESNOW
{
    public partial class frmTrabajdoresMODIFICAR : Form
    {
        private bool soloConsulta;

        public frmTrabajdoresMODIFICAR()
        {
            InitializeComponent();
        }
        public frmTrabajdoresMODIFICAR(bool soloConsulta)
        {
            InitializeComponent();
            this.soloConsulta = soloConsulta;
        }

        private void frmTrabajdoresMODIFICAR_Load(object sender, EventArgs e)
        {
            btnModificar.Visible = !soloConsulta;

            if (soloConsulta)
            {
                pcb_apoyo.Image = Properties.Resources.img_apoyo4;
            }
            else
            {
                pcb_apoyo.Image = Properties.Resources.img_apoyo;
            }
        }
    }
}
