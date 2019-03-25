using CodeIT.Airlines.Challenge.Business.Interfaces;
using CodeIT.Airlines.Challenge.Entities.Enums;
using CodeIT.Airlines.Challenge.Entities.Interfaces;
using CodeIT.Airlines.Challenge.Exceptions;
using System;
using System.Linq;

namespace CodeIT.Airlines.Challenge.Business
{
    public class ValidacaoSmartForTwo : IValidacaoTransporte
    {
        private const int QUANTIDADE_OCUPANTES = 2;

        public IValidacaoOcupantes ValidarMotorista(IVeiculoTransporte veiculoTransporte)
        {
            Console.WriteLine("Validando motorista");
            if (veiculoTransporte.Motorista == null)
                throw new BusinessException("Veículo sem motorista!");

            return this;
        }

        public void ValidarOcupantes(IVeiculoTransporte veiculoTransporte)
        {
            Console.WriteLine("Validando ocupantes");
            if (veiculoTransporte.Passageiro.Tipo.Equals(TipoTripulante.Presidiario) && !veiculoTransporte.Motorista.Tipo.Equals(TipoTripulante.Policial))
                throw new BusinessException("O presidiário não pode estar sem a companhia do policial!");

            if (veiculoTransporte.ListaOcupantes.Count(t => t.Tipo.Equals(TipoTripulante.ChefeServico) || t.Tipo.Equals(TipoTripulante.Oficial)) > 1)
                throw new BusinessException("O chefe de serviço não pode estar no mesmo transporte do oficial!");

            if (veiculoTransporte.ListaOcupantes.Count(t => t.Tipo.Equals(TipoTripulante.Piloto) || t.Tipo.Equals(TipoTripulante.Comissaria)) > 1)
                throw new BusinessException("O piloto não pode estar no mesmo transporte da comissaria!");
        }

        public IValidacaoMotorista ValidarQuantidadeOcupantes(IVeiculoTransporte veiculoTransporte)
        {
            Console.WriteLine("Validando quantidade ocupantes");
            if (veiculoTransporte.ListaOcupantes.Any() && veiculoTransporte.ListaOcupantes.Count != QUANTIDADE_OCUPANTES)
                throw new BusinessException($"Quantidade de ocupantes inválida! (Esperado: {QUANTIDADE_OCUPANTES}, Encontrado: {veiculoTransporte.ListaOcupantes.Count})");

            return this;
        }
    }
}