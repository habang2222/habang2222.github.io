# Test results

Date: 2026-07-15

## Release build

- Projects: 8/8 built
- Warnings: 0
- Errors: 0

## xUnit

- `EveRemote.Core.Tests`: 1 passed
- `EveRemote.Protocol.Tests`: 1 passed
- `EveRemote.Agent.Tests`: 1 passed
- Total: 3 passed, 0 failed, 0 skipped

## Dependency audit

- `dotnet list package --vulnerable --include-transitive`: 0 known vulnerable packages across all 8 projects.

## Runtime smoke test

- Agent listened on HTTP/2 port 5081.
- Controller connected to local Agent and displayed machine `LEE_JAE_WOO`, latency `1 ms`, and the current EVE window count.
- Observed working set after startup: Agent approximately 51 MB; Controller approximately 156 MB.
- Smoke-test processes were stopped after verification.
