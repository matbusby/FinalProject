﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using DBSystem.DAL;
using DBSystem.ENTITIES;

namespace DBSystem.BLL
{
    public class PositionController
    {
        public List<PositionEntity> List()
        {
            using (var context = new Context())
            {
                return context.PositionEntities.ToList();
            }
        }
    }
}
