﻿namespace ErrorOr;

public readonly record struct Error
{
    private Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }
    public string Code { get; }
    public string Description { get; }
    public ErrorType Type { get; }
    public static Error Unexpected(string code = "General.Unexpected", string description = "An unexpected errors has occurred.") => new Error(code, description, ErrorType.Unexpected);
}