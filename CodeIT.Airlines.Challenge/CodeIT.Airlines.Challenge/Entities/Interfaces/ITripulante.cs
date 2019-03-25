using CodeIT.Airlines.Challenge.Entities.Enums;

namespace CodeIT.Airlines.Challenge.Entities.Interfaces
{
    public interface ITripulante : IPessoa
    {
        TipoTripulante Tipo { get; }
        bool IsMotorista { get; }
        bool IsTransportado { get; set;  }
    }
}
