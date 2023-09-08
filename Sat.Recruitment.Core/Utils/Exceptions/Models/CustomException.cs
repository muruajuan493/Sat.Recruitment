namespace Sat.Recruitment.Core.Utils.Exceptions.Models
{
    public abstract class CustomException : Exception
    {
        public CustomException() : base() { }

        public string TipoDeError { get; set; } = string.Empty;
        public string NumeroDeError { get; set; } = string.Empty;
        public string DescripcionDeError { get; set; } = string.Empty;
        public string MensajeDeError { get; set; } = string.Empty;
    }
}
