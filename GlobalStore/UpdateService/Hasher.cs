using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace GlobalStore.UpdateService
{

    public enum HashType
    {
        MD5,
        SHA1, 
        SHA256,
        SHA384,
        SHA512
    }


    public class Hasher
    {
        private static StringBuilder stringBuilder = new StringBuilder();
        public static string HashFile(string IN_FILE, HashType algo)
        {
            byte[] hashBytes = null;
            switch (algo)
            {
                case HashType.MD5:
                    hashBytes = MD5.Create().ComputeHash(new FileStream(IN_FILE, FileMode.Open));
                    break;
                case HashType.SHA1:
                    hashBytes = SHA1.Create().ComputeHash(new FileStream(IN_FILE, FileMode.Open));
                    break;
                case HashType.SHA256:
                    hashBytes = SHA256.Create().ComputeHash(new FileStream(IN_FILE, FileMode.Open));
                    break;
                case HashType.SHA384:
                    hashBytes = SHA384.Create().ComputeHash(new FileStream(IN_FILE, FileMode.Open));
                    break;
                case HashType.SHA512:
                    hashBytes = SHA512.Create().ComputeHash(new FileStream(IN_FILE, FileMode.Open));
                    break;
            }
            return MakeHashString(hashBytes);
        }
        public static string HashString (string IN_STRING,HashType algo)
        {
            byte[] inStringBytes = null, hashBytes = null;
            inStringBytes = Encoding.ASCII.GetBytes(IN_STRING);
            switch (algo)
            {
                case HashType.MD5:
                    hashBytes = MD5.Create().ComputeHash(inStringBytes);
                    break;
                case HashType.SHA1:
                    hashBytes = SHA1.Create().ComputeHash(inStringBytes);
                    break;
                case HashType.SHA256:
                    hashBytes = SHA256.Create().ComputeHash(inStringBytes);
                    break;
                case HashType.SHA384:
                    hashBytes = SHA384.Create().ComputeHash(inStringBytes);
                    break;
                case HashType.SHA512:
                    hashBytes = SHA512.Create().ComputeHash(inStringBytes);
                    break;
            }
            return MakeHashString(hashBytes);

        }

        public static string MakeHashString(byte[] bytesHash)
        {
            stringBuilder.Clear();
            foreach (byte b in bytesHash)
            {
                stringBuilder.Append(b.ToString("x2").ToLower());
            }
            return stringBuilder.ToString(); 
        }
    }
}
