using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
    public interface IHashService
    {
        string CreateHash(VposRequestHashModel request);
    }
}
