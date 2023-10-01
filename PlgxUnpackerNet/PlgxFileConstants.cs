namespace PlgxUnpackerNet
{
    internal static class PlgxFileConstants
    {
        /// <summary>
        /// Magic number found at the start of PLGX file.
        /// </summary>
        internal const int Magic = 0x65d90719;

        /// <summary>
        /// Pattern after which the files can be found.
        /// </summary>
        internal const long FilesStartPattern = 0x0004000000000003;

        /// <summary>
        /// Flag marking the beginning of the content.
        /// </summary>
        internal const ushort BeginContent = 3;

        /// <summary>
        /// Optional flag marking the pre-build command.
        /// </summary>
        internal const ushort PreBuildCommand = 13;

        /// <summary>
        /// Optional flag marking the post-build command.
        /// </summary>
        internal const ushort PostBuildCommand = 14;
    }
}
