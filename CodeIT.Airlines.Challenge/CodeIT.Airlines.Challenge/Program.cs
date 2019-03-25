using CodeIT.Airlines.Challenge.Business;
using CodeIT.Airlines.Challenge.Entities.Enums;
using System;

namespace CodeIT.Airlines.Challenge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var localidadeBuilder = new LocalidadeBuilder();
            var tripulanteBuilder = new TripulanteBuilder();
            var origem = localidadeBuilder.SetDescricao("Terminal").SetTipo(TipoLocalidade.TerminalEmbarque).Create();
            var destino = localidadeBuilder.SetDescricao("Aviao").SetTipo(TipoLocalidade.Aviao).Create();

            origem.AdicionarTripulante(tripulanteBuilder.SetName("Zinedine Zidane").SetTipo(TipoTripulante.Piloto).Create());
            origem.AdicionarTripulante(tripulanteBuilder.SetName("Ronaldinho Gaucho").SetTipo(TipoTripulante.Oficial).Create());
            origem.AdicionarTripulante(tripulanteBuilder.SetName("Ronaldo Fenomeno").SetTipo(TipoTripulante.Oficial).Create());
            origem.AdicionarTripulante(tripulanteBuilder.SetName("Cristiano Ronaldo").SetTipo(TipoTripulante.ChefeServico).Create());
            origem.AdicionarTripulante(tripulanteBuilder.SetName("Marta Vieira").SetTipo(TipoTripulante.Comissaria).Create());
            origem.AdicionarTripulante(tripulanteBuilder.SetName("Hope Solo").SetTipo(TipoTripulante.Comissaria).Create());
            origem.AdicionarTripulante(tripulanteBuilder.SetName("Lionel Messi").SetTipo(TipoTripulante.Policial).Create());
            origem.AdicionarTripulante(tripulanteBuilder.SetName("Neymar Junior").SetTipo(TipoTripulante.Presidiario).Create());

            try
            {
                new TransporteSmartForTwo().TransportarTripulacao(origem, destino);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}