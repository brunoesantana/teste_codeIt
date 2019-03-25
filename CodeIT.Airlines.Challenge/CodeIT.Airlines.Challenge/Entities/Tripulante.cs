using CodeIT.Airlines.Challenge.Entities.Enums;
using CodeIT.Airlines.Challenge.Entities.Interfaces;
using System.Collections.Generic;
using System;

namespace CodeIT.Airlines.Challenge.Entities
{
    public class Tripulante : ITripulante
    {
        private readonly IDictionary<TipoTripulante, bool> _motoristaResolver;

        public string Nome { get; private set; }
        public TipoTripulante Tipo { get; private set; }
        public bool IsMotorista => _motoristaResolver[Tipo];
        public Guid Identificador { get; private set; }
        public bool IsTransportado { get; set; } = false;

        public Tripulante(string nomeTripulante, TipoTripulante tipoTripulante)
        {
            Nome = nomeTripulante;
            Tipo = tipoTripulante;
            Identificador = Guid.NewGuid();
            _motoristaResolver = new Dictionary<TipoTripulante, bool>
            {
                { TipoTripulante.Piloto, true },
                { TipoTripulante.ChefeServico, true },
                { TipoTripulante.Policial, true },
                { TipoTripulante.Comissaria, false },
                { TipoTripulante.Oficial, false },
                { TipoTripulante.Presidiario, false }
            };
        }

        public override string ToString()
        {
            return $"[{Tipo}] {Nome}";
        }
    }
}
