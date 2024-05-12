using SistemaInventarios.DataAccess.Data;
using SistemaInventarios.DataAccess.Repository.IRepository;
using SistemaInventarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarios.DataAccess.Repository
{
    internal class BodegaRepository : Repository<Bodega>, IBodegaRepository
    {
        private readonly ApplicationDbContext _context;

        public BodegaRepository(ApplicationDbContext _context) : base(_context)
        {
            this._context = _context;
        }

        public void Update(Bodega bodega)
        {
            var bodegaDB = this._context.Bodegas.FirstOrDefault(b => b.Id == bodega.Id);
            if (bodegaDB != null)
            {
                bodegaDB.Name = bodega.Name;
                bodegaDB.Description = bodega.Description;
                bodegaDB.State = bodega.State;
                _context.SaveChanges();
            }
        }
    }
}
