namespace Yet.Core.Interfaces
{
    /// <summary>
    /// Esse tipo elimina a necessidade de depender diretamente dos tipos de log do ASP.NET Core.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAppLogger<T>
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
    }
}
