using CodeIT.Airlines.Challenge.Entities.Interfaces;

namespace CodeIT.Airlines.Challenge.Business.Interfaces
{
    public interface IValidacaoOcupantes
    {
        void ValidarOcupantes(IVeiculoTransporte veiculoTransporte);
    }
}
