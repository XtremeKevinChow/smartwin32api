using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace ZO.SmartCore.Interop.Windows
{
    /// <summary>
    /// Has suppress unmanaged code attribute. These methods are safe and can be 
    /// used fairly safely and the caller isn’t needed to do full security reviews 
    /// even though no stack walk will be performed.
    /// </summary>
    [SuppressUnmanagedCodeSecurity, HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
    internal static class SafeNativeMethods
    {

        /// <summary>
        /// retrieves the thread identifier of the calling thread.
        /// </summary>
        /// <returns>The return value is the thread identifier of the calling thread.</returns>
        /// <remarks>Until the thread terminates, the thread identifier uniquely identifies 
        /// the thread throughout the system.</remarks>
        [DllImport(Constants.Kernel32, CharSet = CharSet.Auto, ExactSpelling = true, EntryPoint="GetCurrentThreadId")]
        public static extern uint GetCurrentThreadID();

        /// <summary>
        /// defines a new window message that is guaranteed to be unique throughout the system. 
        /// The message value can be used when sending or posting messages.
        /// </summary>
        /// <param name="msg">Pointer to a null-terminated string that specifies the message
        /// to be registered.</param>
        /// <returns> the message is successfully registered, the return value is a message 
        /// identifier in the range 0xC000 through 0xFFFF.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int RegisterWindowMessage(string msg);

        /// <summary>
        /// Retrieves the process identifier of the calling process.
        /// </summary>
        /// <returns>The return value is the process identifier of the calling process.</returns>
        [DllImport(Constants.Kernel32, CharSet = CharSet.Auto, ExactSpelling = true, EntryPoint="GetCurrentProcessId")]
        public static extern uint GetCurrentProcessID();
 

    }
}
