﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIdProject
{
    interface ISpecification<in TEntity> 
    {
        IEnumerable<string> ReasonsForDissatisfaction { get; }
        bool IsSatisfiedBy(TEntity entity);
    }
}
