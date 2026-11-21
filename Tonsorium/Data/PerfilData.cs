using System;
using System.Collections.Generic;
using System.Text;
using Tonsorium.Models;

namespace Tonsorium.Data
{
    public static class PerfilData
    {
        public static PerfilEstabelecimento StudioBlack { get; } = new()
        {
            Categoria = "BARBEARIA & ESTÉTICA",
            Nome = "Studio Black",
            Avaliacao = 4.9,
            TotalAvaliacoes = 128,
            Descricao = "Um espaço pensado para quem busca estilo, cuidado e excelência em cada detalhe. O Studio Black combina técnicas modernas, atendimento personalizado e um ambiente sofisticado para proporcionar uma experiência única.",
            LocalizacaoEndereco = "Av. Paulista, 1450",
            LocalizacaoCidade = "Bela Vista · São Paulo - SP",
            FuncionamentoDias = "Seg. a Sáb.",
            FuncionamentoHoras = "09:00 às 20:00",
            Especialidades = new[] { "Afro", "Degradê", "Clássico", "Cacheado", "Crespo" },
            SobreTitulo = "Estilo que combina com você.",
            SobreParagrafo1 = "O Studio Black nasceu com a proposta de transformar o cuidado pessoal em uma experiência diferenciada. Cada atendimento é pensado de acordo com o estilo, personalidade e preferência de cada cliente.",
            SobreParagrafo2 = "Nossa equipe trabalha com técnicas contemporâneas e atendimento personalizado, oferecendo desde cortes tradicionais até estilos modernos e personalizados.",
            Servicos = new[]
            {
            new Servico { Numero = "01", Nome = "Corte Masculino", Preco = "R$ 55", Duracao = "45 min",
                Descricao = "Corte personalizado de acordo com o formato do rosto e estilo desejado." },
            new Servico { Numero = "02", Nome = "Degradê", Preco = "R$ 45", Duracao = "40 min",
                Descricao = "Técnica de fade personalizada com acabamento preciso." },
            new Servico { Numero = "03", Nome = "Barba", Preco = "R$ 35", Duracao = "30 min",
                Descricao = "Modelagem, acabamento e cuidado completo para sua barba." },
            new Servico { Numero = "04", Nome = "Corte + Barba", Preco = "R$ 80", Duracao = "1h 15min",
                Descricao = "A combinação completa para renovar seu visual." },
            new Servico { Numero = "05", Nome = "Finalização", Preco = "R$ 40", Duracao = "30 min",
                Descricao = "Finalização personalizada para cabelos cacheados e crespos." },
            new Servico { Numero = "06", Nome = "Sobrancelha", Preco = "R$ 30", Duracao = "20 min",
                Descricao = "Design e acabamento para valorizar o formato do rosto." },
        },
            Equipe = new[]
            {
            new Profissional { Iniciais = "MS", Nome = "Matheus Silva", Cargo = "Barbeiro especialista", Tags = "Degradê · Corte masculino" },
            new Profissional { Iniciais = "RC", Nome = "Rafael Costa", Cargo = "Barbeiro especialista", Tags = "Barba · Clássico" },
            new Profissional { Iniciais = "GL", Nome = "Gabriel Lima", Cargo = "Especialista em cachos", Tags = "Cacheado · Crespo · Afro" },
        },
        };
    }

}