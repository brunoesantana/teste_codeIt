using System;

namespace CodeIT.Airlines.Challenge.Entities.Interfaces
{
    public interface IPessoa
    {
        string Nome { get; }
        Guid Identificador { get; }
    }
}
