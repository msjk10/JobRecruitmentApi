using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entities.HelperModel
{
    public class AdvancedEncryptionStandardModel
    {
        private int _keyIndex;
        private string _keyValue;

        public int KeyIndex
        {
            get
            {
                return _keyIndex;
            }
            set
            {
                _keyIndex = value;
            }
        }

        public string KeyValue
        {
            get
            {
                return _keyValue;
            }
            set
            {
                _keyValue = value;
            }
        }
    }
}
