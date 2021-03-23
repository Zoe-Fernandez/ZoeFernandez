using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TarjetaDeCreditoMVC.Windows.Ninject;

namespace TarjetaDeCreditoMVC.Windows
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnCarteraConsumo_Click(object sender, EventArgs e)
        {
            FrmCarteraConsumo frm = DI.Create<FrmCarteraConsumo>();
            frm.ShowDialog(this);
        }

        private void btnProvincia_Click(object sender, EventArgs e)
        {
            FrmProvincia frm = DI.Create<FrmProvincia>();
            frm.ShowDialog(this);
        }

        private void btnTipoDocumento_Click(object sender, EventArgs e)
        {
            FrmTipoDocumento frm = DI.Create<FrmTipoDocumento>();
            frm.ShowDialog(this);
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
