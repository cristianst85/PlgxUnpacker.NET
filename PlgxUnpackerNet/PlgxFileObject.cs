namespace PlgxUnpackerNet
{
    internal class PlgxFileObject
    {
        internal ushort Type { get; }

        internal byte[] Data { get; }

        internal PlgxFileObject(ushort type, byte[] data)
        {
            this.Type = type;
            this.Data = data;
        }
    }
}
