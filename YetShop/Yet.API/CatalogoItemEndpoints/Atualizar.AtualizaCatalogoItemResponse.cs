﻿using System;
using Yet.API.TratamentoBase;
using Yet.Core.Dto.Catalogo;

namespace Yet.API.CatalogoItemEndpoints
{
    public class AtualizaCatalogoItemResponse : BaseResponse
    {
        #region Ctor
        public AtualizaCatalogoItemResponse(Guid correlacaoId) : base(correlacaoId) { }
        public AtualizaCatalogoItemResponse() { }
        #endregion

        #region Campos
        public CatalogoItemDto CatalogoItem { get; set; }
        #endregion
    }
}
