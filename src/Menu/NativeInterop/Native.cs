using System.Runtime.InteropServices;

namespace Menu.NativeInterop;

public static partial class Native
{
#if WINDOWS
    [LibraryImport("ucrtbase", EntryPoint = "system")]
    public static partial int System([MarshalAs(UnmanagedType.LPStr)] string command);
#elif LINUX || MAC
    [LibraryImport("libc", EntryPoint = "system")]
    public static partial int System([MarshalAs(UnmanagedType.LPStr)] string command);
#else
    internal static int System(string command) => throw new PlatformNotSupportedException();
#endif
}
