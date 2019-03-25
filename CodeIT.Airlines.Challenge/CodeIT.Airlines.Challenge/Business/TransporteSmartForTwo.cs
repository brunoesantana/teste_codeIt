using CodeIT.Airlines.Challenge.Entities.Enums;
using CodeIT.Airlines.Challenge.Entities.Interfaces;
using CodeIT.Airlines.Challenge.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeIT.Airlines.Challenge.Business
{
    public class TransporteSmartForTwo
    {
        private readonly SmartForTwoBusiness _smartForTwoBusiness;

        public TransporteSmartForTwo(SmartForTwoBusiness smartForTwoBusiness)
        {
            _smartForTwoBusiness = smartForTwoBusiness;
        }

        public TransporteSmartForTwo() : this(new SmartForTwoBusiness())
        {
        }

        public void TransportarTripulacao(ILocalidade localOrigem, ILocalidade localDestino)
        {
            try
            {
                Console.WriteLine($"Inicio transporte {localOrigem.ToString()} => {localDestino.ToString()}");
                while (localOrigem.ListaTripulacao.Any(t => !t.IsTransportado))
                {
                    var listaTripulacao = localOrigem.ListaTripulacao.Where(t => !t.IsTransportado);
                    localOrigem.ListarTripulantes();

                    var motorista = TransportarTripulantes(localOrigem, localDestino, listaTripulacao);
                    if (motorista != null)
                        localOrigem.ListaTripulacao
                            .Where(t => t.Identificador == motorista.Identificador)
                            .ToList().ForEach(t => t.IsTransportado = false);

                    localDestino.ListarTripulantes();
                }

                Console.WriteLine($"Fim transporte {localOrigem.ToString()} => {localDestino.ToString()}");
                localOrigem.ListarTripulantes();
                localDestino.ListarTripulantes();
            }
            catch (BusinessException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private ITripulante TransportarTripulantes(ILocalidade localOrigem, ILocalidade localDestino, IEnumerable<ITripulante> listaTripulacao)
        {
            var listaOrdenada = listaTripulacao.OrderBy(o => o.Tipo);
            var passageiro = listaOrdenada.FirstOrDefault();
            ITripulante motorista = null;

            switch (passageiro.Tipo)
            {
                case TipoTripulante.Comissaria:
                    motorista = listaOrdenada
                        .FirstOrDefault(t => t.IsMotorista && t.Identificador != passageiro.Identificador && t.Tipo != TipoTripulante.Piloto && t.Tipo != TipoTripulante.Policial && t.Tipo != TipoTripulante.Presidiario);
                    break;

                case TipoTripulante.Oficial:
                    motorista = listaOrdenada
                        .FirstOrDefault(t => t.IsMotorista && t.Identificador != passageiro.Identificador && t.Tipo != TipoTripulante.ChefeServico && t.Tipo != TipoTripulante.Policial && t.Tipo != TipoTripulante.Presidiario);
                    break;

                default:
                    motorista = listaOrdenada
                        .FirstOrDefault(t => t.IsMotorista && t.Identificador != passageiro.Identificador);
                    break;
            }

            var ultimaViagem = passageiro.Tipo.Equals(TipoTripulante.Presidiario);

            _smartForTwoBusiness.EmbarcarTripulantes(localOrigem, motorista, passageiro);
            _smartForTwoBusiness.DesembarcarTripulantes(localDestino, ultimaViagem);

            return ultimaViagem ? null : motorista;
        }
    }
}