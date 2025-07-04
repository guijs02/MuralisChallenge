﻿namespace Muralis.Domain.Response
{
    public class RespostaPaginada<T> : Resposta<T> where T : class
    {
        public RespostaPaginada(T? dado, int numeroPagina = 1, int tamanhoPagina = 5, int totalPages = 10, string? mensagem = null, int codigoStatus = 200)
                            : base(dado, mensagem, codigoStatus)
        {
            NumeroPagina = numeroPagina;
            TamanhoPagina = tamanhoPagina;
            TotalPagina = totalPages;
        }

        public int NumeroPagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalPagina { get; set; }
    }
}
