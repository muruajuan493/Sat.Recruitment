using Sat.Recruitment.Core.Utils.Exceptions.Models;

namespace Sat.Recruitment.Core.Generics.Services
{
    public interface IBaseResult
    {
        DateTime Inicio { get; set; }
        void MarcarInicio() => Inicio = DateTime.Now;
        DateTime Fin { get; set; }
        void MarcarFin() => Fin = DateTime.Now;
        bool Exito { get; set; }
        string Mensaje { get; set; }
        bool TieneExcepciones { get; set; }
        List<AppException> Excepciones { get; set; }
    }

    public class BaseResult<T> : IBaseResult where T : BaseContext
    {
        public BaseResult(T context)
        {
            Contexto = context;
            MarcarInicio();
        }

        public T Contexto { get; set; }
        public DateTime Inicio { get; set; }
        private void MarcarInicio() => Inicio = DateTime.Now;
        public DateTime Fin { get; set; }
        public void MarcarFin() => Fin = DateTime.Now;
        public bool Exito { get; set; } = true;
        public string Mensaje { get; set; } = string.Empty;
        public bool TieneExcepciones { get; set; } = false;
        public List<AppException> Excepciones { get; set; } = new List<AppException>();
    }
}
