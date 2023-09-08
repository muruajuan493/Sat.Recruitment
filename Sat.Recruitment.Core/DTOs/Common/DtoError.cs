using Sat.Recruitment.Core.Utils.Exceptions.Models;

namespace Sat.Recruitment.Core.DTOs.Common
{
    public class DtoError
    {
        public string DES_ERROR { get; set; } = string.Empty;
        public string MENSAJE { get; set; } = string.Empty;
        public string NRO_ERROR { get; set; } = string.Empty;
        public string TIPO_ERROR { get; set; } = string.Empty;

        public DtoError() { }

        public DtoError(AppException appException)
        {
            DES_ERROR = appException.DescripcionDeError ?? "";
            MENSAJE = appException.MensajeDeError ?? "";
            NRO_ERROR = appException.NumeroDeError ?? "";
            TIPO_ERROR = appException.TipoDeError ?? "";
        }
    }
}
