using System.Collections.Generic;

namespace CodeIT.Airlines.Challenge.Entities.Interfaces
{
    public interface IVeiculoTransporte
    {
        ITripulante Motorista { get; }
        ITripulante Passageiro { get; }
        IList<ITripulante> ListaOcupantes { get; }
        IVeiculoTransporte EmbarcarOcupantes(ITripulante motorista, ITripulante passageiro);
        void DesembarcarOcupantes();
    }
}
