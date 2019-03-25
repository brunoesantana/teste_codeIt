using CodeIT.Airlines.Challenge.Entities.Enums;
using CodeIT.Airlines.Challenge.Entities.Interfaces;
using CodeIT.Airlines.Challenge.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeIT.Airlines.Challenge.Entities
{
    public class Localidade : ILocalidade
    {
        public string Descricao { get; private set; }
        public TipoLocalidade Tipo { get; private set; }
        public IList<ITripulante> ListaTripulacao { get; private set; }

        public Localidade(string descricao, TipoLocalidade tipoLocalidade)
        {
            Descricao = descricao;
            Tipo = tipoLocalidade;
            ListaTripulacao = new List<ITripulante>();
        }

        public ILocalidade AdicionarTripulante(ITripulante tripulante)
        {
            ListaTripulacao.Add(tripulante);
            ListaTripulacao = ListaTripulacao.ToList().Shuffle();
            return this;
        }

        public void RemoverTripulante(ITripulante tripulante)
        {
            tripulante.IsTransportado = true;
        }

        public void ListarTripulantes()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(ToString());
            Func<ITripulante, bool> funcListarTransportados = t => t.IsTransportado;
            Func<ITripulante, bool> funcListarPresentes = t => !t.IsTransportado;
            Func<ITripulante, bool> funcFiltroTripulantes =
                TipoLocalidade.TerminalEmbarque.Equals(Tipo)
                ? funcListarPresentes
                : funcListarTransportados;
            var listaTripulantes = ListaTripulacao.Where(funcFiltroTripulantes);
            if (!listaTripulantes.Any())
                Console.WriteLine("-- Nenhum tripulante encontrado --");

            foreach (var tripulante in ListaTripulacao.Where(funcFiltroTripulantes))
                Console.WriteLine(tripulante.ToString());

            Console.WriteLine("--------------------------------------");
        }

        public override string ToString()
        {
            return $"[{Tipo}] {Descricao}";
        }
    }
}