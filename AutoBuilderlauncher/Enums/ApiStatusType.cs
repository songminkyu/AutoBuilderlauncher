using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBuilderlauncher.Enums
{
    public enum ApiStatusType
    {
        ApiSendSuccess = 0,
        PostMessageError = 1,
        PutMessageError = 2,
        GetMessageError = 3,
        JsonParsingError = 4,
        DuplicatedUniqueID = 5,
        Blank = 0xFF,
    }
}
