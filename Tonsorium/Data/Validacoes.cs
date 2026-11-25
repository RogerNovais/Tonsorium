using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Tonsorium.Data
{
    public static class Validacoes
    {
        // E-mail: aceita qualquer domínio com TLD de 2+ letras (gmail.com, hotmail.com, cps.br...)
        private static readonly Regex RegexEmail = new(
            @"^[A-Za-z0-9._%+\-]+@[A-Za-z0-9\-]+(\.[A-Za-z0-9\-]+)*\.[A-Za-z]{2,}$",
            RegexOptions.Compiled);

        // Senha: 6+ caracteres, com maiúscula, minúscula, número e caractere especial
        private static readonly Regex RegexSenha = new(
            @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{6,}$",
            RegexOptions.Compiled);

        public static bool EmailValido(string? email) =>
            !string.IsNullOrWhiteSpace(email) && RegexEmail.IsMatch(email.Trim());

        public static bool SenhaValida(string? senha) =>
            !string.IsNullOrEmpty(senha) && RegexSenha.IsMatch(senha);

        // CPF: 11 dígitos, não todos iguais, com dígitos verificadores corretos
        public static bool CpfValido(string? cpf)
        {
            var d = Digitos(cpf);
            if (d.Length != 11 || d.Distinct().Count() == 1)
                return false;

            var n = d.Select(c => c - '0').ToArray();
            return CalcularDigito(n, 9) == n[9] && CalcularDigito(n, 10) == n[10];
        }

        private static int CalcularDigito(int[] n, int tamanho)
        {
            int soma = 0;
            for (int i = 0; i < tamanho; i++)
                soma += n[i] * (tamanho + 1 - i);

            int resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }

        // Data: dd/mm/aaaa, data real, não futura e com no máximo 120 anos
        public static bool DataValida(string? texto, out DateTime data)
        {
            bool formatoOk = DateTime.TryParseExact(texto, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out data);

            return formatoOk
                && data.Date <= DateTime.Today
                && data.Date >= DateTime.Today.AddYears(-120);
        }

        // Máscaras: formatam enquanto o usuário digita
        public static string MascaraCpf(string? texto)
        {
            var d = Digitos(texto);
            if (d.Length > 11) d = d[..11];

            var sb = new StringBuilder();
            for (int i = 0; i < d.Length; i++)
            {
                if (i == 3 || i == 6) sb.Append('.');
                if (i == 9) sb.Append('-');
                sb.Append(d[i]);
            }
            return sb.ToString();
        }

        public static string MascaraData(string? texto)
        {
            var d = Digitos(texto);
            if (d.Length > 8) d = d[..8];

            var sb = new StringBuilder();
            for (int i = 0; i < d.Length; i++)
            {
                if (i == 2 || i == 4) sb.Append('/');
                sb.Append(d[i]);
            }
            return sb.ToString();
        }

        private static string Digitos(string? texto) =>
            new string((texto ?? "").Where(char.IsDigit).ToArray());
    }
}
