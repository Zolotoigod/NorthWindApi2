using System;
using System.Collections.Generic;

namespace NorthWindEFRepository
{
    public static class Defines
    {
        public readonly struct ErrorMesage
        {
            public const string ItemNotFoundTemplate = "{0} id-<{1}> not found!";
        }
    }
}
