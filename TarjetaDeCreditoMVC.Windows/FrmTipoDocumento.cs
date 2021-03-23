using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TarjetaDeCreditoMVC.Entidades.DTOs.TipoDocumento;
using TarjetaDeCreditoMVC.Servicios.Servicios;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;

namespace TarjetaDeCreditoMVC.Windows
{
    public partial class FrmTipoDocumento : Form
    {
        public FrmTipoDocumento(IServiciosTipoDocumento servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private IMapper _mapper;
        private IServiciosTipoDocumento _servicio;
        private List<TipoDocumentoListDto> _lista;

        private void FrmTipoDocumento_Load(object sender, EventArgs e)
        {
            try
            {
                _mapper = TarjetaDeCreditoMVC.Mapeador.Mapeador.CrearMapper();
                _lista = _servicio.GetLista();
                MostrarDatosEnGrilla();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var tipoDocumento in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipoDocumento);
                AgregarFila(r);

            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoDocumentoListDto tipoDocumento)
        {
            r.Cells[cmnDescripcion.Index].Value = tipoDocumento.Descripcion;

            r.Tag = tipoDocumento;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

