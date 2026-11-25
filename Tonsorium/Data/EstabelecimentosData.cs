using System;
using System.Collections.Generic;
using System.Text;
using Tonsorium.Models;

namespace Tonsorium.Data
{
    public static class EstabelecimentosData
    {
        private static readonly Dictionary<string, PerfilEstabelecimento> Perfis =
            new[]
            {
            Criar("Studio Black", "BARBEARIA & ESTÉTICA", 4.9, 128,
                "Um espaço pensado para quem busca estilo, cuidado e excelência em cada detalhe.",
                "Av. Paulista, 1450", "Bela Vista · São Paulo - SP",
                "Seg. a Sáb.", "09:00 às 21:00",
                new[] { "Afro", "Degradê", "Clássico", "Cacheado", "Crespo" },
                "Estilo que combina com você.",
                "O Studio Black nasceu com a proposta de transformar o cuidado pessoal em uma experiência diferenciada.",
                "Nossa equipe trabalha com técnicas contemporâneas e atendimento personalizado.",
                new[]
                {
                    S("01", "Corte Masculino", "Corte personalizado de acordo com o formato do rosto.", "R$ 55", "45 min"),
                    S("02", "Degradê", "Técnica de fade personalizada com acabamento preciso.", "R$ 45", "40 min"),
                    S("03", "Barba", "Modelagem, acabamento e cuidado completo para sua barba.", "R$ 35", "30 min"),
                    S("04", "Corte + Barba", "A combinação completa para renovar seu visual.", "R$ 80", "1h 15min"),
                    S("05", "Finalização", "Finalização personalizada para cabelos cacheados e crespos.", "R$ 40", "30 min"),
                    S("06", "Sobrancelha", "Design e acabamento para valorizar o formato do rosto.", "R$ 30", "20 min"),
                },
                new[]
                {
                    P("MS", "Matheus Silva", "Barbeiro especialista", "Degradê · Corte masculino"),
                    P("RC", "Rafael Costa", "Barbeiro especialista", "Barba · Clássico"),
                    P("GL", "Gabriel Lima", "Especialista em cachos", "Cacheado · Crespo · Afro"),
                }),

            Criar("Casa dos Cachos", "CABELOS CACHEADOS", 4.8, 96,
                "Cuidados e finalizações para cabelos cacheados, com foco em hidratação e definição.",
                "Rua Augusta, 800", "Consolação · São Paulo - SP",
                "Ter. a Sáb.", "10:00 às 20:00",
                new[] { "Cacheado", "Hidratação", "Finalização" },
                "Cachos com cuidado de verdade.",
                "Trabalhamos com diagnóstico da curvatura e produtos adequados a cada padrão de cacho.",
                "Cada atendimento termina com orientação para a sua rotina em casa.",
                new[]
                {
                    S("01", "Finalização de Cachos", "Definição e acabamento para cachos.", "R$ 40", "40 min"),
                    S("02", "Hidratação Capilar", "Tratamento de hidratação profunda.", "R$ 60", "40 min"),
                },
                new[]
                {
                    P("LM", "Lúcia Mendes", "Especialista em cachos", "Cacheado · Hidratação"),
                    P("BR", "Bianca Rocha", "Cuidados capilares", "Finalização · Definição"),
                }),

            Criar("Urban Baber", "BARBEARIA", 4.7, 74,
                "Cortes masculinos e serviços de barba com atendimento rápido e objetivo.",
                "Rua Oscar Freire, 215", "Jardins · São Paulo - SP",
                "Seg. a Sáb.", "09:00 às 20:00",
                new[] { "Masculino", "Barba", "Degradê" },
                "Cortes masculinos com precisão.",
                "Atendimento rápido, com foco no acabamento e na identidade de cada cliente.",
                "Ideal para quem quer sair da cadeira com o visual pronto.",
                new[]
                {
                    S("01", "Corte Masculino", "Corte com acabamento preciso.", "R$ 50", "45 min"),
                    S("02", "Barba", "Modelagem e acabamento da barba.", "R$ 30", "30 min"),
                },
                new[]
                {
                    P("DA", "Diego Alves", "Barbeiro", "Degradê · Corte"),
                    P("TN", "Thiago Nunes", "Barbeiro", "Barba · Clássico"),
                }),

            Criar("Essência Hair", "BELEZA E TRATAMENTO", 4.7, 88,
                "Beleza, tratamento e cuidado dos cabelos crespos e cacheados.",
                "Av. Brigadeiro Faria Lima, 2000", "Itaim Bibi · São Paulo - SP",
                "Seg. a Sáb.", "10:00 às 20:00",
                new[] { "Crespo", "Tratamento", "Hidratação" },
                "Tratamento que respeita a textura.",
                "Protocolos de tratamento pensados para fios crespos e cacheados.",
                "Acompanhamento do resultado em cada visita.",
                new[]
                {
                    S("01", "Tratamento para Crespos", "Protocolo de hidratação e reconstrução.", "R$ 70", "60 min"),
                    S("02", "Finalização", "Definição e acabamento.", "R$ 40", "40 min"),
                },
                new[]
                {
                    P("PL", "Patrícia Lopes", "Especialista em crespos", "Crespo · Tratamento"),
                    P("CS", "Carla Souza", "Cuidados capilares", "Hidratação · Finalização"),
                }),

            Criar("Black Crown", "ESPECIALISTAS EM CRESPOS", 4.6, 61,
                "Especialistas em cabelos crespos, com cortes e finalizações personalizados.",
                "Rua da Consolação, 1200", "Consolação · São Paulo - SP",
                "Ter. a Sáb.", "09:00 às 20:00",
                new[] { "Crespo", "Afro", "Degradê" },
                "Crespo com identidade.",
                "Cortes e finalizações desenhados para a textura e o formato do rosto.",
                "Equipe treinada para valorizar cada tipo de crespo.",
                new[]
                {
                    S("01", "Corte Afro", "Corte com desenho e acabamento.", "R$ 55", "50 min"),
                    S("02", "Finalização", "Definição e acabamento.", "R$ 40", "40 min"),
                },
                new[]
                {
                    P("MD", "Marcos Dias", "Especialista em crespos", "Afro · Crespo"),
                    P("AB", "Ana Beatriz", "Cuidados capilares", "Crespo · Finalização"),
                }),

            Criar("Maison Prime", "EXPERIÊNCIA PREMIUM", 5.0, 42,
                "Experiência premium em beleza e cabelos, com atendimento exclusivo.",
                "Av. Rebouças, 500", "Pinheiros · São Paulo - SP",
                "Seg. a Sáb.", "10:00 às 21:00",
                new[] { "Cacheado", "Premium", "Finalização" },
                "Atendimento exclusivo.",
                "Um espaço reservado, com profissionais dedicados a cada cliente.",
                "Cada detalhe do atendimento é planejado com antecedência.",
                new[]
                {
                    S("01", "Corte Premium", "Corte personalizado com consultoria.", "R$ 120", "80 min"),
                    S("02", "Finalização Premium", "Finalização com produtos exclusivos.", "R$ 90", "40 min"),
                },
                new[]
                {
                    P("JP", "Juliana Prado", "Especialista premium", "Cacheado · Corte"),
                    P("HM", "Henrique Moura", "Cuidados premium", "Finalização · Cachos"),
                }),

            Criar("Studio Milano", "CORTES MODERNOS", 4.9, 110,
                "Cortes modernos e tratamentos capilares para cabelos lisos e alinhados.",
                "Rua Haddock Lobo, 360", "Cerqueira César · São Paulo - SP",
                "Seg. a Sáb.", "09:00 às 20:00",
                new[] { "Liso", "Corte moderno", "Tratamento" },
                "Linhas limpas e acabamento preciso.",
                "O Studio Milano une cortes atuais e tratamentos para manter os fios saudáveis.",
                "Consultoria rápida para escolher o corte ideal para o seu dia a dia.",
                new[]
                {
                    S("01", "Corte Moderno", "Corte com acabamento contemporâneo.", "R$ 60", "50 min"),
                    S("02", "Tratamento Capilar", "Tratamento para brilho e saúde dos fios.", "R$ 55", "45 min"),
                },
                new[]
                {
                    P("LF", "Lucas Ferreira", "Cortes modernos", "Liso · Corte"),
                    P("RD", "Renata Dias", "Tratamentos capilares", "Liso · Tratamento"),
                }),

            Criar("Black House", "BARBEARIA & ESTÉTICA", 4.9, 97,
                "Especialistas em diferentes texturas, do liso ao crespo.",
                "Rua Teodoro Sampaio, 900", "Pinheiros · São Paulo - SP",
                "Seg. a Sáb.", "09:00 às 20:00",
                new[] { "Crespo", "Cacheado", "Degradê" },
                "Uma casa para todas as texturas.",
                "Atendemos cada textura com técnicas específicas e atenção ao acabamento.",
                "Barba e cabelo no mesmo atendimento, com um só profissional.",
                new[]
                {
                    S("01", "Corte Texturizado", "Corte adaptado à textura do fio.", "R$ 60", "50 min"),
                    S("02", "Barba", "Modelagem e acabamento da barba.", "R$ 35", "30 min"),
                },
                new[]
                {
                    P("MV", "Marcelo Vieira", "Especialista em texturas", "Crespo · Cacheado"),
                    P("FA", "Felipe Araújo", "Barbeiro", "Barba · Degradê"),
                }),

            Criar("Studio Prime", "CORTES E TRATAMENTOS", 4.8, 79,
                "Cortes e tratamentos personalizados para cabelos ondulados.",
                "Av. Ipiranga, 1000", "República · São Paulo - SP",
                "Ter. a Sáb.", "09:00 às 20:00",
                new[] { "Ondulado", "Corte", "Tratamento" },
                "Ondas com definição.",
                "Tratamentos e cortes pensados para realçar o movimento natural dos fios.",
                "Orientação de finalização para manter as ondas em casa.",
                new[]
                {
                    S("01", "Corte Ondulado", "Corte que respeita o movimento natural.", "R$ 55", "50 min"),
                    S("02", "Hidratação", "Hidratação para controlar o frizz.", "R$ 50", "40 min"),
                },
                new[]
                {
                    P("CT", "Camila Torres", "Especialista em ondas", "Ondulado · Corte"),
                    P("PG", "Pedro Gomes", "Tratamentos", "Ondulado · Hidratação"),
                }),

            Criar("Urban Style", "ESTILO URBANO", 4.8, 68,
                "Estilo urbano e cortes contemporâneos para o dia a dia.",
                "Rua Augusta, 1500", "Consolação · São Paulo - SP",
                "Seg. a Sáb.", "10:00 às 21:00",
                new[] { "Liso", "Urbano", "Corte" },
                "Estilo para o dia a dia.",
                "Cortes contemporâneos com acabamento simples e durável.",
                "Atendimento ágil, ideal para quem tem pouco tempo.",
                new[]
                {
                    S("01", "Corte Urbano", "Corte contemporâneo com acabamento limpo.", "R$ 50", "45 min"),
                    S("02", "Barba Urbana", "Barba com acabamento contemporâneo.", "R$ 35", "30 min"),
                },
                new[]
                {
                    P("VM", "Vinícius Matos", "Cortes urbanos", "Liso · Degradê"),
                    P("GR", "Guilherme Reis", "Barbeiro", "Barba · Corte"),
                }),

            Criar("Studio Texture", "DIFERENTES TEXTURAS", 4.8, 83,
                "Especialista em diferentes texturas, com foco em cachos e crespos.",
                "Rua Bela Cintra, 300", "Consolação · São Paulo - SP",
                "Ter. a Sáb.", "10:00 às 20:00",
                new[] { "Cacheado", "Crespo", "Textura" },
                "Cada textura tem a sua técnica.",
                "Diagnóstico da textura antes de qualquer corte ou tratamento.",
                "Acompanhamento para manter o resultado entre as visitas.",
                new[]
                {
                    S("01", "Corte Cacheado", "Corte que valoriza a curvatura natural.", "R$ 70", "60 min"),
                    S("02", "Finalização", "Definição e acabamento.", "R$ 45", "40 min"),
                },
                new[]
                {
                    P("MC", "Mariana Costa", "Especialista em cachos", "Cacheado · Finalização"),
                    P("BL", "Bruno Lima", "Especialista em texturas", "Crespo · Textura"),
                }),

            Criar("Curly Lab", "CUIDADOS PARA CACHOS", 4.9, 104,
                "Cuidados especializados para cachos, do diagnóstico à finalização.",
                "Rua Fradique Coutinho, 700", "Vila Madalena · São Paulo - SP",
                "Seg. a Sáb.", "09:00 às 20:00",
                new[] { "Cacheado", "Hidratação", "Finalização" },
                "Laboratório de cachos.",
                "Cada cacho passa por um diagnóstico antes do tratamento.",
                "Protocolos personalizados para manter a definição por mais tempo.",
                new[]
                {
                    S("01", "Corte Cacheado", "Corte que respeita a forma do cacho.", "R$ 65", "60 min"),
                    S("02", "Hidratação Curly", "Hidratação específica para cachos.", "R$ 60", "50 min"),
                },
                new[]
                {
                    P("PM", "Priscila Melo", "Especialista em cachos", "Cacheado · Hidratação"),
                    P("RN", "Rodrigo Nascimento", "Cuidados capilares", "Cacheado · Finalização"),
                }),

            Criar("Afro Style", "CRESPOS E AFRO", 4.8, 72,
                "Especialistas em cabelos crespos e afro, com cortes e finalizações exclusivas.",
                "Rua Vergueiro, 2200", "Vila Mariana · São Paulo - SP",
                "Seg. a Sáb.", "09:00 às 20:00",
                new[] { "Afro", "Crespo", "Degradê" },
                "Afro com estilo.",
                "Cortes e finalizações exclusivos para cabelos crespos e afro.",
                "Profissionais especializados em crespos e black power.",
                new[]
                {
                    S("01", "Corte Afro", "Corte com desenho e volume.", "R$ 55", "50 min"),
                    S("02", "Degradê Afro", "Degradê adaptado ao crespo.", "R$ 50", "45 min"),
                },
                new[]
                {
                    P("JS", "Jorge Santos", "Especialista afro", "Afro · Crespo"),
                    P("TO", "Tatiane Oliveira", "Cuidados com crespos", "Crespo · Finalização"),
                }),

            Criar("Wave Studio", "ONDAS E TRATAMENTOS", 4.7, 65,
                "Tratamentos e cortes para cabelos ondulados, valorizando as ondas naturais.",
                "Rua Harmonia, 150", "Vila Madalena · São Paulo - SP",
                "Ter. a Sáb.", "10:00 às 20:00",
                new[] { "Ondulado", "Tratamento", "Corte" },
                "Valorize suas ondas.",
                "Cortes e tratamentos para ondas definidas e sem frizz.",
                "Acompanhamento para manter o movimento natural dos fios.",
                new[]
                {
                    S("01", "Corte Ondulado", "Corte que respeita o movimento natural.", "R$ 55", "50 min"),
                    S("02", "Tratamento", "Tratamento para ondas sem frizz.", "R$ 50", "45 min"),
                },
                new[]
                {
                    P("GF", "Gabriela Freitas", "Especialista em ondas", "Ondulado · Corte"),
                    P("AP", "Alexandre Pinto", "Tratamentos", "Ondulado · Tratamento"),
                }),

            Criar("Smooth Hair", "CORTES E CUIDADOS", 4.6, 58,
                "Cortes e cuidados para cabelos lisos, com acabamento preciso.",
                "Rua Pamplona, 800", "Jardim Paulista · São Paulo - SP",
                "Seg. a Sáb.", "10:00 às 20:00",
                new[] { "Liso", "Corte", "Cuidados" },
                "Liso com acabamento impecável.",
                "Cortes e escovas pensados para brilho e alinhamento.",
                "Cuidados para manter o liso saudável por mais tempo.",
                new[]
                {
                    S("01", "Corte Liso", "Corte com linhas retas e acabamento.", "R$ 50", "45 min"),
                    S("02", "Escova", "Escova para alinhamento e brilho.", "R$ 45", "40 min"),
                },
                new[]
                {
                    P("FL", "Fernanda Luz", "Cortes lisos", "Liso · Corte"),
                    P("AS", "André Souza", "Cuidados capilares", "Liso · Escova"),
                }),

            Criar("Nail Studio", "MANICURE E CUIDADOS DAS UNHAS", 4.8, 90,
                "Manicure, pedicure e cuidados com as unhas, com ambiente tranquilo e higiene rigorosa.",
                "Rua Augusta, 2000", "Cerqueira César · São Paulo - SP",
                "Seg. a Sáb.", "09:00 às 20:00",
                new[] { "Manicure", "Pedicure", "Esmaltação" },
                "Cuidado com as unhas.",
                "Ambiente tranquilo e protocolos rigorosos de higiene.",
                "Esmaltação e cutilagem feitas com calma e atenção.",
                new[]
                {
                    S("01", "Manicure", "Cuidado completo com as mãos e unhas.", "R$ 35", "40 min"),
                    S("02", "Pedicure", "Cuidado completo com os pés e unhas.", "R$ 45", "50 min"),
                },
                new[]
                {
                    P("AR", "Amanda Ribeiro", "Especialista em unhas", "Manicure · Esmaltação"),
                    P("LS", "Letícia Sousa", "Cuidados com as unhas", "Pedicure · Cutilagem"),
                }),
            }.ToDictionary(p => p.Nome, StringComparer.OrdinalIgnoreCase);

        public static PerfilEstabelecimento Obter(string? nome)
        {
            if (nome is not null && Perfis.TryGetValue(nome.Trim(), out var perfil))
                return perfil;

            throw new KeyNotFoundException($"Perfil não cadastrado para '{nome}'.");
        }

        public static bool Existe(string? nome) =>
            nome is not null && Perfis.ContainsKey(nome.Trim());

        private static PerfilEstabelecimento Criar(
            string nome, string categoria, double avaliacao, int total, string descricao,
            string endereco, string cidade, string dias, string horas, string[] especialidades,
            string sobreTitulo, string paragrafo1, string paragrafo2,
            Servico[] servicos, Profissional[] equipe) => new()
            {
                Nome = nome,
                Categoria = categoria,
                Avaliacao = avaliacao,
                TotalAvaliacoes = total,
                Descricao = descricao,
                LocalizacaoEndereco = endereco,
                LocalizacaoCidade = cidade,
                FuncionamentoDias = dias,
                FuncionamentoHoras = horas,
                Especialidades = especialidades,
                SobreTitulo = sobreTitulo,
                SobreParagrafo1 = paragrafo1,
                SobreParagrafo2 = paragrafo2,
                Servicos = servicos,
                Equipe = equipe,
            };

        private static Servico S(string numero, string nome, string descricao, string preco, string duracao) => new()
        {
            Numero = numero,
            Nome = nome,
            Descricao = descricao,
            Preco = preco,
            Duracao = duracao,
        };

        private static Profissional P(string iniciais, string nome, string cargo, string tags) => new()
        {
            Iniciais = iniciais,
            Nome = nome,
            Cargo = cargo,
            Tags = tags,
        };
    }
}
