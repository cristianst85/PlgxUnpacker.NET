namespace PlgxUnpacker
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
    }
}
