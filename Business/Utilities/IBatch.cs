using System.Data;
using Model;

namespace Business.Utilities
{
    public interface IBatch
    {
        int Batch_Delete(int batchId);
        DataTable Batch_GetAll(Model.Batch batch);
        int Batch_Save(Model.Batch batch);
    }
}