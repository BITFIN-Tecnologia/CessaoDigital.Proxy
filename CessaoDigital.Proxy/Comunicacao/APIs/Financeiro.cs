﻿// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

namespace CessaoDigital.Proxy.Comunicacao.APIs
{
    /// <summary>
    /// 
    /// </summary>
    public class Financeiro : API
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="proxy">Instância da classe <see cref="HttpClient"/> gerada pelo proxy.</param>
        public Financeiro(HttpClient proxy)
            : base(proxy) { }
    }
}