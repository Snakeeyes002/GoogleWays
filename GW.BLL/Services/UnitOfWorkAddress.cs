using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using GW.BLL.Models;

namespace GW.BLL.Services
{
    public class UnitOfWorkAddress : IUnitOfWorkAddress
    {
        private bool disposed = false;
        public TransactionScope Transaction { get; set; }
        public IGenericService<AddressDTO> AddressService { get; set; }
        public IGenericService<StreetDTO> StreetService { get; set; }
        public IGenericService<SubdivisionDTO> SubdivisionService { get; set; }

        public UnitOfWorkAddress(TransactionScope transaction,
                                 IGenericService<AddressDTO> addressService,
                                 IGenericService<StreetDTO> streetService,
                                 IGenericService<SubdivisionDTO> subdivisionService)
        {
            this.Transaction = transaction;
            this.AddressService = addressService;
            this.StreetService = streetService;
            this.SubdivisionService = SubdivisionService;
        }
        public void Commit()
        {
            Transaction.Complete();
        }

        public void Rollback()
        {
            Transaction.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Transaction.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
