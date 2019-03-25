using CodeIT.Airlines.Challenge.Entities.Interfaces;

namespace CodeIT.Airlines.Challenge.Business.Interfaces
{
    public interface IValidacaoTransporte : IValidacaoMotorista, IValidacaoOcupantes
    {
        IValidacaoMotorista ValidarQuantidadeOcupantes(IVeiculoTransporte veiculoTransporte);
    }
}
