using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiWithAuth.Models;

public class Location
{
    /// <summary>
    /// Código de 7 digitos do IBGE
    /// </summary>
    /// <example>1234567</example>
    public string Id { get; set; }

    /// <summary>
    /// Sigla do Estado
    /// </summary>
    /// <example>SC</example>
    public string State { get; set; } = string.Empty;

    /// <summary>
    /// Nome da cidade
    /// </summary>
    /// <example>Florianópolis</example>
    public string City { get; set; } = string.Empty;
}