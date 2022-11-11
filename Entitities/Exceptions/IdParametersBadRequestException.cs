using Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class IdParametersBadRequestException : BadRequestException
    {
        public IdParametersBadRequestException()
            :base("Parameters ids is null")
        {

        }
    }
}
