using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wawishapp.Models.Behavior
{
    public interface IAssign<T>
    {
        void AssignMe(T entity);
    }
}
