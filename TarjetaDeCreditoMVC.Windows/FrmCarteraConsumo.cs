using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarteraConsumo;
using TarjetaDeCreditoMVC.Servicios.Servicios;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;

namespace TarjetaDeCreditoMVC.Windows
{
    public partial class FrmCarteraConsumo : Form
    {
        public FrmCarteraConsumo(IServiciosCarteraConsumo servicio)
        {
            InitializeComponent();
            _servicio=servicio;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private IMapper _mapper;
        private IServiciosCarteraConsumo _servicio;
        private List<CarteraConsumoListDto> _lista;
        private void FrmCarteraConsumo_Load(object sender, EventArgs e)
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
            foreach (var carteraConsumo in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, carteraConsumo);
                AgregarFila(r);

            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, CarteraConsumoListDto carteraConsumo)
        {
            r.Cells[cmnDescripcion.Index].Value = carteraConsumo.Descripcion;
            r.Cells[cmnLimite.Index].Value = carteraConsumo.LimiteDeCredito;
            r.Cells[cmnCosto.Index].Value = carteraConsumo.CostoDeRenovacion;

            r.Tag = carteraConsumo;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }
    }
}
