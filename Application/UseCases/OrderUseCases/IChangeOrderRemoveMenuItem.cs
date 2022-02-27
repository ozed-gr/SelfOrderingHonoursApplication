using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.OrderUseCases
{
    public interface IChangeOrderRemoveMenuItem
    {
        Task Execute(int p_menuItem_id);
    }
}
