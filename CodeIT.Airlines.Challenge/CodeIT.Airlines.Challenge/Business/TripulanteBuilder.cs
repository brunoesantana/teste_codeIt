using CodeIT.Airlines.Challenge.Entities;
using CodeIT.Airlines.Challenge.Entities.Enums;
using CodeIT.Airlines.Challenge.Entities.Interfaces;

namespace CodeIT.Airlines.Challenge.Business
{
    public class TripulanteBuilder
    {
        private string _nome;
        private TipoTripulante _tipoTripulante;

        public TripulanteBuilder SetName(string nome)
        {
            _nome = nome;
            return this;
        }

        public TripulanteBuilder SetTipo(TipoTripulante tipo)
        {
            _tipoTripulante = tipo;
            return this;
        }

        public ITripulante Create()
        {
            return new Tripulante(_nome, _tipoTripulante);
        }
    }
}
