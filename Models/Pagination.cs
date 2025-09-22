namespace sigur_emulation.Models;

public class Pagination
{
    /// <summary>
    /// Количество возвращаемых сущностей.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Количество пропускаемых сущностей.
    /// </summary>
    public int? Offset { get; set; }

}