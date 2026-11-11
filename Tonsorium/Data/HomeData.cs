using System;
using System.Collections.Generic;
using System.Text;
using Tonsorium.Models;

namespace Tonsorium.Data
{
    public static class HomeData
    {
        public static string[] Chips { get; } =
            { "Cabelos Cacheados", "Cabelos Crespos", "Barba", "Manicure" };

        public static SecaoCarrossel[] Secoes { get; } =
        {
        new()
        {
            Titulo = "Recomendadas",
            Subtitulo = "Estabelecimentos selecionados para você",
            Itens = new List<Estabelecimento>
            {
                new() { Nome = "Studio Black", Avaliacao = 4.9, Descricao = "Especializado em cabelos cacheados e crespos.", Tag = "Cacheados" },
                new() { Nome = "Casa dos Cachos", Avaliacao = 4.8, Descricao = "Cuidados e finalizações para cabelos cacheados.", Tag = "Cacheados" },
                new() { Nome = "Urban Baber", Avaliacao = 4.7, Descricao = "Cortes masculinos e serviços de barba.", Tag = "Masculino" },
                new() { Nome = "Essência Hair", Avaliacao = 4.7, Descricao = "Beleza, tratamento e cuidado dos cabelos.", Tag = "Crespos" },
                new() { Nome = "Black Crown", Avaliacao = 4.6, Descricao = "Especialistas em cabelos crespos.", Tag = "Crespos" },
            }
        },
        new()
        {
            Titulo = "Mais Avaliadas",
            Subtitulo = "Os estabelecimentos mais bem avaliados",
            Itens = new List<Estabelecimento>
            {
                new() { Nome = "Maison Prime", Avaliacao = 5.0, Descricao = "Experiência premium em beleza e cabelos.", Tag = "Cacheados" },
                new() { Nome = "Studio Milano", Avaliacao = 4.9, Descricao = "Cortes modernos e tratamentos capilares.", Tag = "Lisos" },
                new() { Nome = "Black House", Avaliacao = 4.9, Descricao = "Especialistas em diferentes texturas.", Tag = "Crespos" },
                new() { Nome = "Studio Prime", Avaliacao = 4.8, Descricao = "Cortes e tratamentos personalizados.", Tag = "Ondulados" },
                new() { Nome = "Urban Style", Avaliacao = 4.8, Descricao = "Estilo urbano e cortes contemporâneos.", Tag = "Lisos" },
            }
        },
        new()
        {
            Titulo = "Todos os Tipos de Cabelo",
            Subtitulo = "Encontre o estabelecimento ideal para seu cabelo",
            Itens = new List<Estabelecimento>
            {
                new() { Nome = "Studio Texture", Avaliacao = 4.8, Descricao = "Especialista em diferentes texturas de cabelo.", Tag = "Cacheados" },
                new() { Nome = "Curly Lab", Avaliacao = 4.9, Descricao = "Cuidados especializados para cachos.", Tag = "Cacheados" },
                new() { Nome = "Afro Style", Avaliacao = 4.8, Descricao = "Especialistas em cabelos crespos e afro.", Tag = "Crespos" },
                new() { Nome = "Wave Studio", Avaliacao = 4.7, Descricao = "Tratamentos e cortes para cabelos ondulados.", Tag = "Ondulados" },
                new() { Nome = "Smooth Hair", Avaliacao = 4.6, Descricao = "Cortes e cuidados para cabelos lisos.", Tag = "Lisos" },
            }
        },
    };
    }
}
