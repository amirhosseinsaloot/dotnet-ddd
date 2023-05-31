﻿namespace DomainDrivenDesign.Domain.Setting;

public sealed record class DatabaseSettings
{
    public string ConnectionString { get; init; } = null!;

    public string Schema { get; init; } = null!;
}
