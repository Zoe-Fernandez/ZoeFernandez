using System.ComponentModel.DataAnnotations;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.TipoDocumento
{
    public class TipoDocumentoListViewModel
    {
        public int TipoDeDocumentoId { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
