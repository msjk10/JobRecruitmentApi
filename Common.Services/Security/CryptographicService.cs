﻿using Common.Domain.Entities.HelperModel;
using Common.Services.Interfaces.Security;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common.Services.Security
{
    public class CryptographicService: ICryptographicService
    {
        #region Member
        private byte[] _key = { };
        private readonly byte[] _iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        private readonly string[] _generateKey ={"HNJLXDBZ" ,"ALIFWEKF" ,"YD9CNDBZ","ALIKN6YR","VNYUCDBZ","ALIXQKUY","ENZBEDBZ","ALI2YFHP","RFCE3DBZ","ALIS3IQ8","YIJ0EDBZ","ALINDZEF","4JRNHDBZ","DBZOXZDT","JZALGDBZ","DBZSAKZT","M4Z2KDBZ","DBZFIYII","SPUWADBZ","DBZOSSUC",
                       "LPPEIDBZ" ,"ALIS3M1N","6GO1KDBZ","DBZCMWWZ", "3UCYJDBZ"};
        private AdvancedEncryptionStandardModel _encryptDecryptKey = new AdvancedEncryptionStandardModel();
        #endregion

        public string DecryptionProcess(string stringToDecrypt)
        {
            try
            {
                string sEncryptionKey = _generateKey[int.Parse(stringToDecrypt.Substring(stringToDecrypt.Length - 2, 2))];

                stringToDecrypt = stringToDecrypt.Remove(stringToDecrypt.Length - 2, 2);
                byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];

                _key = Encoding.UTF8.GetBytes(sEncryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms,
                  des.CreateDecryptor(_key, _iv), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string EncryptionProcess(string stringToEncrypt)
        {
            try
            {
                _encryptDecryptKey = GetEncryptKey();
                _key = Encoding.UTF8.GetBytes(_encryptDecryptKey.KeyValue);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms,
                  des.CreateEncryptor(_key, _iv), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray()) + _encryptDecryptKey.KeyIndex.ToString("00");
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private AdvancedEncryptionStandardModel GetEncryptKey()
        {
            AdvancedEncryptionStandardModel okey = new AdvancedEncryptionStandardModel();
            string encKey = "";
            Random random = new Random();
            int i = random.Next(25);
            encKey = _generateKey[i];
            okey.KeyIndex = i;
            okey.KeyValue = encKey;
            return okey;
        }
    }
}
