﻿using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Assistants;

[Experimental("OPENAI001")]
public readonly partial struct MessageCollectionOrder : IEquatable<MessageCollectionOrder>
{
    public static MessageCollectionOrder Ascending { get; } = new MessageCollectionOrder("asc");

    public static MessageCollectionOrder Descending { get; } = new MessageCollectionOrder("desc");

    private readonly string _value;
    private const string AscValue = "asc";
    private const string DescValue = "desc";

    public MessageCollectionOrder(string value)
    {
        Argument.AssertNotNull(value, nameof(value));

        _value = value;
    }

    public static bool operator ==(MessageCollectionOrder left, MessageCollectionOrder right) => left.Equals(right);

    public static bool operator !=(MessageCollectionOrder left, MessageCollectionOrder right) => !left.Equals(right);

    public static implicit operator MessageCollectionOrder(string value) => new MessageCollectionOrder(value);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => obj is MessageCollectionOrder other && Equals(other);

    public bool Equals(MessageCollectionOrder other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

    public override string ToString() => _value;
}
