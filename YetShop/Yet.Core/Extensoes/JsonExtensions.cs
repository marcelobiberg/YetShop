﻿using System.Text.Json;

namespace Yet.Core.Extensoes
{
    //:TODO: implementar o Refit
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public static T FromJson<T>(this string json) =>
            JsonSerializer.Deserialize<T>(json, _jsonOptions);

        public static string ToJson<T>(this T obj) =>
            JsonSerializer.Serialize<T>(obj, _jsonOptions);
    }
}
