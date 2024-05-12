using SistemaInventarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarios.DataAccess.Repository.IRepository
{
    public interface IBodegaRepository : IRepository<Bodega>
    {
        void Update(Bodega bodega);
    }
}
