// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;

namespace Microsoft.Diagnostics.DataContractReader.Contracts;

public record struct StressLogData(
    uint LoggedFacilities,
    uint Level,
    uint MaxSizePerThread,
    uint MaxSizeTotal,
    int TotalChunks,
    ulong TickFrequency,
    ulong StartTimestamp,
    TargetPointer Logs);

public record struct ThreadStressLogData(
    TargetPointer NextPointer,
    ulong ThreadId,
    bool WriteHasWrapped,
    TargetPointer CurrentPointer,
    TargetPointer ChunkListHead,
    TargetPointer ChunkListTail,
    TargetPointer CurrentWriteChunk);

public record struct StressMsgData(
    uint Facility,
    TargetPointer FormatString,
    ulong Timestamp,
    IReadOnlyList<TargetPointer> Args);

public interface IStressLog : IContract
{
    static string IContract.Name { get; } = nameof(StressLog);
    bool HasStressLog() => throw new NotImplementedException();
    StressLogData GetStressLogData() => throw new NotImplementedException();
    StressLogData GetStressLogData(TargetPointer stressLog) => throw new NotImplementedException();
    IEnumerable<ThreadStressLogData> GetThreadStressLogs(TargetPointer Logs) => throw new NotImplementedException();
    IEnumerable<StressMsgData> GetStressMessages(ThreadStressLogData threadLog) => throw new NotImplementedException();
    bool IsPointerInStressLog(StressLogData stressLog, TargetPointer pointer) => throw new NotImplementedException();
}

public readonly struct StressLog : IStressLog
{
    // Everything throws NotImplementedException
}
