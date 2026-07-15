namespace EveRemote.Core.Models;

/// <summary>Supported direct user input event kinds. No automation event exists.</summary>
public enum RemoteInputType { MouseMove, MouseDown, MouseUp, MouseWheel, KeyDown, KeyUp }

/// <summary>A single physical user input addressed to exactly one selected client.</summary>
public sealed record RemoteInputEvent(Guid SessionId, string AgentId, string ClientId, RemoteInputType Type,
    double NormalizedX, double NormalizedY, int MouseButton, int VirtualKeyCode, int WheelDelta,
    long SequenceNumber, DateTimeOffset CreatedAtUtc);
