using CodeIT.Airlines.Challenge.Entities;
using CodeIT.Airlines.Challenge.Entities.Enums;
using CodeIT.Airlines.Challenge.Entities.Interfaces;

namespace CodeIT.Airlines.Challenge.Business
{
    public class LocalidadeBuilder
    {
        private string _descricao;
        private TipoLocalidade _tipoLocalidade;

        public LocalidadeBuilder SetDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public LocalidadeBuilder SetTipo(TipoLocalidade tipoLocalidade)
        {
            _tipoLocalidade = tipoLocalidade;
            return this;
        }

        public ILocalidade Create()
        {
            return new Localidade(_descricao, _tipoLocalidade);
        }
    }
}
