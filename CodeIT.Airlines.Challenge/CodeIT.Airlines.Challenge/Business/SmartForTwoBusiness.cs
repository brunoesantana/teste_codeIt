using CodeIT.Airlines.Challenge.Business.Interfaces;
using CodeIT.Airlines.Challenge.Entities;
using CodeIT.Airlines.Challenge.Entities.Interfaces;
using System;

namespace CodeIT.Airlines.Challenge.Business
{
    public class SmartForTwoBusiness
    {
        private readonly IVeiculoTransporte _veiculoTransporte;
        private readonly IValidacaoTransporte _validacaoTransporte;

        public SmartForTwoBusiness(IVeiculoTransporte veiculoTransporte, IValidacaoTransporte validacaoTransporte)
        {
            _veiculoTransporte = veiculoTransporte;
            _validacaoTransporte = validacaoTransporte;
        }

        public SmartForTwoBusiness() : this(new SmartForTwo(), new ValidacaoSmartForTwo())
        {
        }

        public void EmbarcarTripulantes(ILocalidade localOrigem, ITripulante motorista, ITripulante passageiro)
        {
            _veiculoTransporte.EmbarcarOcupantes(motorista, passageiro);
            _validacaoTransporte
                .ValidarQuantidadeOcupantes(_veiculoTransporte)
                .ValidarMotorista(_veiculoTransporte)
                .ValidarOcupantes(_veiculoTransporte);

            Console.WriteLine(_veiculoTransporte.ToString());

            localOrigem.RemoverTripulante(motorista);
            localOrigem.RemoverTripulante(passageiro);
        }

        public void DesembarcarTripulantes(ILocalidade localDestino)
        {
            DesembarcarTripulantes(localDestino, false);
        }

        public void DesembarcarTripulantes(ILocalidade localDestino, bool ultimaViagem)
        {
            if (ultimaViagem)
                localDestino.AdicionarTripulante(_veiculoTransporte.Motorista);

            localDestino.AdicionarTripulante(_veiculoTransporte.Passageiro);
            _veiculoTransporte.DesembarcarOcupantes();
        }
    }
}