using System;

namespace Yet.Core.Excecoes
{
    public class DuploCatalogoItemNomeException : Exception
    {
        public DuploCatalogoItemNomeException(string msg, int duploItemId) : base(msg)
        {
            DuploItemId = duploItemId;
        }

        public int DuploItemId { get; }
    }
}
