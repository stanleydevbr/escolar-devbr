using System.Collections.Generic;

namespace DevBr.Core.Dominio.Notificacoes
{
    public class Notificacao<T>
    {
        public bool Sucesso => DicionarioMensagens.Count == 0;
        public T Resultado { get; private set; }
        public Dictionary<string, List<string>> Mensagens => DicionarioMensagens;
        public List<string> Informacoes => DicionarioInformacoes;
        private Dictionary<string, List<string>> DicionarioMensagens { get; set; }
        private List<string> DicionarioInformacoes { get; set; }
        public Notificacao()
        {
            DicionarioMensagens = new Dictionary<string, List<string>>();
        }

        public Notificacao<T> AdicioneErro(string mensagem)
        {
            AdicioneMensagem("Erro", mensagem);
            return this;
        }
        public Notificacao<T> AdicioneErro(string key, string error)
        {
            if (DicionarioMensagens == null)
            {
                DicionarioMensagens = new Dictionary<string, List<string>>();
            }

            if (!DicionarioMensagens.TryGetValue(key, out var listaDeMesagens))
            {
                listaDeMesagens = new List<string>();
                DicionarioMensagens[key] = listaDeMesagens;
            }

            if (listaDeMesagens.Contains(error)) return this;

            listaDeMesagens.Add(error);
            return this;
        }
        public Notificacao<T> AdicionarErros(Dictionary<string, List<string>> errors)
        {
            foreach (var error in errors)
            {
                foreach (var value in error.Value)
                {
                    AdicioneErro(error.Key, value);
                }
            }
            return this;
        }
        public Notificacao<T> AdicioneInconsistencia(string mensagem)
        {
            AdicioneMensagem("", mensagem);
            return this;
        }
        public Notificacao<T> AdicioneInformacao(string info)
        {
            if (DicionarioInformacoes == null) DicionarioInformacoes = new List<string>();
            DicionarioInformacoes.Add(info);
            return this;
        }
        public Notificacao<T> AdicioneMensagem(string chave, string mensagem)
        {
            if (DicionarioMensagens == null)
                DicionarioMensagens = new Dictionary<string, List<string>>();

            if (!DicionarioMensagens.TryGetValue(chave, out var listaDeMesagens))
            {
                listaDeMesagens = new List<string>();
                DicionarioMensagens[chave] = listaDeMesagens;
            }

            if (listaDeMesagens.Contains(mensagem)) return this;

            listaDeMesagens.Add(mensagem);
            return this;
        }
        public Notificacao<T> TrateResultado(T resultado)
        {
            this.Resultado = resultado;
            return this;
        }
        public Notificacao<T> AdicioneResultadoValidacao(T resultado, Notificacao<bool> validacao)
        {
            this.Resultado = resultado;

            foreach (var mensagem in validacao.Mensagens)
                DicionarioMensagens[mensagem.Key] = mensagem.Value;

            return this;
        }

    }
}
