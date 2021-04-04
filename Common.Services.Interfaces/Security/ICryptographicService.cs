using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.Interfaces.Security
{
    public interface ICryptographicService
    {
        string DecryptionProcess(string stringToDecrypt);
        string EncryptionProcess(string stringToEncrypt);
    }
}
