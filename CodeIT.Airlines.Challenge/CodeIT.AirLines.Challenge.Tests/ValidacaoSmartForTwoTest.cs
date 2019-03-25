using CodeIT.Airlines.Challenge.Business;
using CodeIT.Airlines.Challenge.Business.Interfaces;
using CodeIT.Airlines.Challenge.Entities;
using CodeIT.Airlines.Challenge.Entities.Enums;
using CodeIT.Airlines.Challenge.Entities.Interfaces;
using CodeIT.Airlines.Challenge.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeIT.AirLines.Challenge.Tests
{
    [TestClass]
    public class ValidacaoSmartForTwoTest
    {
        private readonly IVeiculoTransporte _veiculoTransporte = new SmartForTwo();
        private readonly ITripulante _tripulante = new TripulanteBuilder().SetName("teste").SetTipo(TipoTripulante.Piloto).Create();
        private readonly IValidacaoTransporte _validacaoTransporte = new ValidacaoSmartForTwo();

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "Quantidade de ocupantes inválido! (Esperado: 2, Encontrado: 4)")]
        public void Deve_lancar_excessao_se_quantidade_de_ocupantes_do_veiculo_smartfortwo_for_invalida()
        {
            _veiculoTransporte.EmbarcarOcupantes(_tripulante, _tripulante);
            _veiculoTransporte.EmbarcarOcupantes(_tripulante, _tripulante);

            _validacaoTransporte.ValidarQuantidadeOcupantes(_veiculoTransporte);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "Veículo sem motorista!")]
        public void Deve_lancar_excessao_se_motorista_for_nulo()
        {
            _validacaoTransporte.ValidarMotorista(_veiculoTransporte);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O piloto não pode estar no mesmo transporte da comissaria!")]
        public void Deve_lancar_excessao_para_caso_de_piloto_e_commissaria()
        {
            var motorista = new TripulanteBuilder().SetName("teste 1").SetTipo(TipoTripulante.Piloto).Create();
            var passageiro = new TripulanteBuilder().SetName("teste 2").SetTipo(TipoTripulante.Comissaria).Create();

            _veiculoTransporte.EmbarcarOcupantes(motorista, passageiro);

            _validacaoTransporte.ValidarOcupantes(_veiculoTransporte);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O presidiário não pode estar sem a companhia do policial!")]
        public void Deve_lancar_excessao_para_caso_de_policial_e_presidiario()
        {
            var motorista = new TripulanteBuilder().SetName("teste 3").SetTipo(TipoTripulante.Piloto).Create();
            var passageiro = new TripulanteBuilder().SetName("teste 4").SetTipo(TipoTripulante.Presidiario).Create();

            _veiculoTransporte.EmbarcarOcupantes(motorista, passageiro);

            _validacaoTransporte.ValidarOcupantes(_veiculoTransporte);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O chefe de serviço não pode estar no mesmo transporte do oficial!")]
        public void Deve_lancar_excessao_para_caso_de_chefe_de_servico_e_oficial()
        {
            var motorista = new TripulanteBuilder().SetName("teste 5").SetTipo(TipoTripulante.ChefeServico).Create();
            var passageiro = new TripulanteBuilder().SetName("teste 6").SetTipo(TipoTripulante.Oficial).Create();

            _veiculoTransporte.EmbarcarOcupantes(motorista, passageiro);

            _validacaoTransporte.ValidarOcupantes(_veiculoTransporte);
        }
    }
}