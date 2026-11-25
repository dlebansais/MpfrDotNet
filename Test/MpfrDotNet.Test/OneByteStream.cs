namespace Test;

using System;
using System.IO;

// A stream that returns at most one byte per read, like a pipe or a network stream that has received only part of the
// data: a StreamReader then reports no character with Peek until it reads again.
internal sealed class OneByteStream(byte[] content) : MemoryStream(content)
{
    public override int Read(byte[] buffer, int offset, int count)
        => base.Read(buffer, offset, Math.Min(count, 1));
}
