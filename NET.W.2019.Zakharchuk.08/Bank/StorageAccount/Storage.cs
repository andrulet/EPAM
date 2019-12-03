using System;
using System.Collections.Generic;
using System.IO;
using AccountInfo;

namespace StorageAccount
{
    public class Storage
    {
        /// <summary>
        /// Field include in path to storage.
        /// </summary>   
        private string _path = @"storage.bin";

        /// <summary>
        /// Base Constructor        
        /// </summary>        
        public Storage()
        {
        }

        /// <summary>
        /// Constructor Storage.
        /// </summary>
        /// <param name="path">Path in storage.</param>       
        public Storage(string path)
        {
            if (!File.Exists(_path))
            {
                throw new InvalidOperationException("Enter a correct filepath");
            }

            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            _path = path;
        }

        /// <summary>
        /// Read account from file.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Account> ReadAccountFromFile()
        {
            List<Account> accounts = new List<Account>();
            using (BinaryReader br = new BinaryReader(File.Open(_path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)))
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    var account = Reader(br);
                    accounts.Add(account);
                }
            }

            return accounts;
        }

        /// <summary>
        /// Write account to file
        /// </summary>
        /// <param name="account">Account that needed write</param>
        public void WriteAccountToFile(Account account)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(_path, FileMode.Append, FileAccess.Write, FileShare.None)))
            {
                Writer(bw, account);
            }
        }

        /// <summary>
        /// Overwrite file
        /// </summary>
        /// <param name="accounts">List of account that needed write</param>
        public void OverWriteFile(IEnumerable<Account> accounts)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(_path, FileMode.Create, FileAccess.Write, FileShare.None)))
            {
                foreach (var account in accounts)
                {
                    Writer(bw, account);
                }
            }
        }

        /// <summary>
        /// This Method writes types in to in thread.
        /// </summary>
        /// <param name="binary">Binary thread</param>
        /// <param name="account">Accound needed add in storage</param>
        private static void Writer(BinaryWriter binary, Account account)
        {
            binary.Write(account.Id);
            binary.Write(account.FirstName);
            binary.Write(account.Surname);
            binary.Write(account.Amount);
            binary.Write(account.Bonus);
            binary.Write(account.Status.ToString());
            binary.Write(account.Type.ToString());
        }

        /// <summary>
        /// This Method reads types in to in thread.
        /// </summary>
        /// <param name="binary">Binary thread</param>
        /// <param name="account">Accound needed read from storage</param>
        private static Account Reader(BinaryReader binary)
        {
            var id = binary.ReadInt32();
            var firstName = binary.ReadString();
            var surname = binary.ReadString();
            var amount = binary.ReadDecimal();
            var bonus = binary.ReadInt32();
            var status = binary.ReadString();
            var type = binary.ReadString();

            return new Account(id, firstName, surname, amount, bonus, (StatusAccount)Enum.Parse(typeof(StatusAccount), status), (TypeAccount)Enum.Parse(typeof(TypeAccount), type));
        }
    }
}
