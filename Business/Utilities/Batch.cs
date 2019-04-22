using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class Batch : IBatch
    {
        DataAccess.IBatch _Batch;

        public Batch(DataAccess.IBatch batch)
        {
            this._Batch = batch;
        }

        public int Batch_Save(Model.Batch batch)
        {
            return _Batch.Batch_Save(batch);

        }

        public DataTable Batch_GetAll(Model.Batch batch)
        {
            return _Batch.Batch_GetAll(batch);
        }

        public int Batch_Delete(int batchId)
        {
            return _Batch.Batch_Delete(batchId);
        }
    }
}
