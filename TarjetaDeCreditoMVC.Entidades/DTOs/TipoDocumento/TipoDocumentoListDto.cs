using System;

namespace TarjetaDeCreditoMVC.Entidades.DTOs.TipoDocumento
{
    public class TipoDocumentoListDto : ICloneable
    {
        public int TipoDeDocumentoId { get; set; }
        public string Descripcion { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
