using CodeIT.Airlines.Challenge.Entities.Enums;
using System.Collections.Generic;

namespace CodeIT.Airlines.Challenge.Entities.Interfaces
{
    public interface ILocalidade
    {
        string Descricao { get; }
        TipoLocalidade Tipo { get; }
        IList<ITripulante> ListaTripulacao { get; }
        ILocalidade AdicionarTripulante(ITripulante tripulante);
        void RemoverTripulante(ITripulante tripulante);
        void ListarTripulantes();
    }
}
