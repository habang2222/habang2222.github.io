namespace EveRemote.Core.Models;

/// <summary>Describes one visible EVE Online top-level window.</summary>
public sealed record EveClientInfo(string AgentId, string ClientId, int ProcessId, long WindowHandle,
    string WindowTitle, int ClientWidth, int ClientHeight, bool IsMinimized, DateTimeOffset ObservedAtUtc);
