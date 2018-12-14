namespace RM
{
    class UtilByte
    {
        public static byte[] intToBytes(int value)
        {
            byte[] src = new byte[4];
            src[0] = (byte)((value >> 24) & 0xFF);
            src[1] = (byte)((value >> 16) & 0xFF);
            src[2] = (byte)((value >>  8) & 0xFF);
            src[3] = (byte)((value >>  0) & 0xFF);
            return src;
        }
        public static byte[] shortToBytes(int value)
        {
            byte[] src = new byte[2];
            src[0] = (byte)((value >> 8) & 0xFF);
            src[1] = (byte)((value >> 0) & 0xFF);
            return src;
        }

    }
}
