﻿using Awadh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awadh.AppCode.Interfaces
{
    interface ITeacher
    {
        Response ChangeStatus(string Status, string RegId);
        Response MaterialUploadDetail(MaterialUploadDetail param);
    }
}
