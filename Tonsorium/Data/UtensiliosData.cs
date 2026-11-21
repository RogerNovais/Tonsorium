using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tonsorium.Models;

namespace Tonsorium.Data
{
    public static class UtensiliosData
    {
        // Método (não propriedade) para cada tela receber uma lista nova e independente
        public static List<Utensilio> Criar() => new()
    {
        new Utensilio { Numero = "01", Icone = "♒", Categoria = "FINALIZAÇÃO", Nome = "Pente Garfo",
            Descricao = "Ideal para dar volume e ajudar a modelar cabelos cacheados e crespos.",
            ParaQueServe = "Ajuda a levantar a raiz e aumentar o volume sem desfazer completamente a definição.",
            ComoUsar = "Com o cabelo seco, introduza o pente delicadamente próximo à raiz e faça movimentos para cima.",
            Dica = "Evite passar o pente por todo o comprimento se quiser preservar a definição dos cachos." },

        new Utensilio { Numero = "02", Icone = "≡", Categoria = "DESEMBARAÇO", Nome = "Pente de dentes largos",
            Descricao = "Uma opção indicada para desembaraçar os fios com maior cuidado.",
            ParaQueServe = "Ajuda a remover nós e distribuir produtos pelo cabelo sem exercer tanta tração.",
            ComoUsar = "Comece pelas pontas e vá subindo gradualmente até chegar à raiz.",
            Dica = "Em cabelos cacheados e crespos, pode ser utilizado com os fios úmidos e condicionados." },

        new Utensilio { Numero = "03", Icone = "◒", Categoria = "MODELAGEM", Nome = "Escova",
            Descricao = "Existem diferentes modelos de escovas, cada um com uma finalidade específica.",
            ParaQueServe = "Pode auxiliar no desembaraço, alinhamento, modelagem e preparação dos fios.",
            ComoUsar = "Escolha uma escova adequada ao seu objetivo e passe suavemente pelos fios.",
            Dica = "Para cabelos mais frágeis, evite puxar os fios com força para reduzir a quebra." },

        new Utensilio { Numero = "04", Icone = "◉", Categoria = "SECAGEM", Nome = "Difusor",
            Descricao = "Acessório utilizado junto ao secador para auxiliar na secagem e definição dos cabelos.",
            ParaQueServe = "Distribui o ar do secador de maneira mais uniforme e pode ajudar na definição dos cachos.",
            ComoUsar = "Utilize temperatura e velocidade moderadas, posicionando o difusor próximo aos fios.",
            Dica = "Evite manter o calor concentrado em uma única região durante muito tempo." },

        new Utensilio { Numero = "05", Icone = "◌", Categoria = "SECAGEM", Nome = "Secador",
            Descricao = "Equipamento utilizado para acelerar a secagem dos cabelos e auxiliar em diferentes finalizações.",
            ParaQueServe = "Remove a umidade dos fios e pode auxiliar na modelagem do cabelo.",
            ComoUsar = "Mantenha uma distância segura dos fios e movimente o secador constantemente.",
            Dica = "O uso de protetor térmico é recomendado antes de utilizar fontes de calor." },

        new Utensilio { Numero = "06", Icone = "≋", Categoria = "SECAGEM", Nome = "Toalha de microfibra",
            Descricao = "Alternativa mais delicada para retirar o excesso de água dos fios após a lavagem.",
            ParaQueServe = "Ajuda a retirar a umidade sem a necessidade de esfregar intensamente os cabelos.",
            ComoUsar = "Pressione suavemente a toalha contra os fios para absorver o excesso de água.",
            Dica = "Evite esfregar o cabelo vigorosamente, pois isso pode aumentar o frizz e a quebra." },

        new Utensilio { Numero = "07", Icone = "◇", Categoria = "PROTEÇÃO", Nome = "Touca de cetim",
            Descricao = "Utilizada durante o sono para ajudar a reduzir o atrito entre o cabelo e o tecido do travesseiro.",
            ParaQueServe = "Pode ajudar a preservar a finalização e diminuir o atrito durante a noite.",
            ComoUsar = "Coloque a touca envolvendo todo o cabelo antes de dormir.",
            Dica = "Mantenha a touca limpa e escolha um tamanho confortável para evitar apertar os fios." },

        new Utensilio { Numero = "08", Icone = "✦", Categoria = "FINALIZAÇÃO", Nome = "Presilhas",
            Descricao = "Acessórios simples que ajudam a separar partes do cabelo durante cuidados e finalizações.",
            ParaQueServe = "Facilita a divisão dos fios durante cortes, penteados e processos de finalização.",
            ComoUsar = "Divida o cabelo em partes e prenda cada seção para trabalhar uma região por vez.",
            Dica = "Prefira presilhas que não prendam ou puxem excessivamente os fios." },
    };

        public static readonly List<DicaUtensilio> Dicas = new()
    {
        new DicaUtensilio { Numero = "01", Titulo = "Desembarace com cuidado",
            Texto = "Comece pelas pontas e avance em direção à raiz." },
        new DicaUtensilio { Numero = "02", Titulo = "Evite excesso de calor",
            Texto = "Sempre que possível, utilize temperaturas moderadas e proteção térmica." },
        new DicaUtensilio { Numero = "03", Titulo = "Mantenha seus utensílios limpos",
            Texto = "A limpeza frequente ajuda a evitar o acúmulo de resíduos nos acessórios." },
        new DicaUtensilio { Numero = "04", Titulo = "Conheça seu cabelo",
            Texto = "O melhor utensílio depende da curvatura, comprimento e objetivo da sua finalização." },
    };
    }
}
