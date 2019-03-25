using CodeIT.Airlines.Challenge.Entities.Interfaces;

namespace CodeIT.Airlines.Challenge.Business.Interfaces
{
    public interface IValidacaoMotorista
    {
        IValidacaoOcupantes ValidarMotorista(IVeiculoTransporte veiculoTransporte);
    }
}
