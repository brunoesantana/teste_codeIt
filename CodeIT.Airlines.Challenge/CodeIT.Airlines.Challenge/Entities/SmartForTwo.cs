using CodeIT.Airlines.Challenge.Entities.Interfaces;
using System.Collections.Generic;

namespace CodeIT.Airlines.Challenge.Entities
{
    public class SmartForTwo : IVeiculoTransporte
    {
        public IList<ITripulante> ListaOcupantes { get; private set; } = new List<ITripulante>();

        public ITripulante Motorista { get; private set; }

        public ITripulante Passageiro { get; private set; }

        public void DesembarcarOcupantes()
        {
            ListaOcupantes.Clear();
        }

        public IVeiculoTransporte EmbarcarOcupantes(ITripulante motorista, ITripulante passageiro)
        {
            ListaOcupantes.Add(motorista);
            ListaOcupantes.Add(passageiro);
            Motorista = motorista;
            Passageiro = passageiro;
            return this;
        }

        public override string ToString()
        {
            return $"Motorista: {Motorista.ToString()}, Passageiro: {Passageiro.ToString()}";
        }
    }
}