using System;
using System.Runtime.InteropServices;

namespace Fougerite.Concurrent
{
    /// <summary>
    /// Our own implementation of LockCookie.
    /// This class resides in the mscorlib.dll, but LockQueue is internal, and we aren't going to patch that.
    /// </summary>
    [ComVisible(true)]
    public struct LockCookie
    {
        public int ThreadId;
        public int ReaderLocks;
        public int WriterLocks;

        public LockCookie(int threadID)
        {
            ThreadId = threadID;
            ReaderLocks = 0;
            WriterLocks = 0;
        }

        public LockCookie(int threadID, int readerLocks, int writerLocks)
        {
            ThreadId = threadID;
            ReaderLocks = readerLocks;
            WriterLocks = writerLocks;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(LockCookie obj)
        {
            return ThreadId == obj.ThreadId && ReaderLocks == obj.ReaderLocks && WriterLocks == obj.WriterLocks;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is LockCookie cookie))
            {
                return false;
            }

            return cookie.Equals(this);
        }

        public static bool operator ==(LockCookie a, LockCookie b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(LockCookie a, LockCookie b)
        {
            return !a.Equals(b);
        }
    }
}