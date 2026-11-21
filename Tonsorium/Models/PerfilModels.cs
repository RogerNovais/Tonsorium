using System;
using System.Collections.Generic;
using System.Text;

namespace Tonsorium.Models
{
    public class Servico
    {
        public string Numero { get; set; } = "";
        public string Nome { get; set; } = "";
        public string Descricao { get; set; } = "";
        public string Preco { get; set; } = "";
        public string Duracao { get; set; } = "";
    }

    public class Profissional
    {
        public string Iniciais { get; set; } = "";
        public string Nome { get; set; } = "";
        public string Cargo { get; set; } = "";
        public string Tags { get; set; } = "";
    }

    public class PerfilEstabelecimento
    {
        public string Categoria { get; set; } = "";
        public string Nome { get; set; } = "";
        public double Avaliacao { get; set; }
        public int TotalAvaliacoes { get; set; }
        public string Estrelas => new('★', (int)Math.Round(Avaliacao));
        public string Descricao { get; set; } = "";
        public string LocalizacaoEndereco { get; set; } = "";
        public string LocalizacaoCidade { get; set; } = "";
        public string FuncionamentoDias { get; set; } = "";
        public string FuncionamentoHoras { get; set; } = "";
        public string[] Especialidades { get; set; } = Array.Empty<string>();
        public string SobreTitulo { get; set; } = "";
        public string SobreParagrafo1 { get; set; } = "";
        public string SobreParagrafo2 { get; set; } = "";
        public Servico[] Servicos { get; set; } = Array.Empty<Servico>();
        public Profissional[] Equipe { get; set; } = Array.Empty<Profissional>();
    }
}
