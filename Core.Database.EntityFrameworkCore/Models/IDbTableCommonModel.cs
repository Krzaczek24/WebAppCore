using System;

namespace Core.Database.Models
{
    public interface IDbTableCommonModel
    {
        public int Id { get; set; }

        public void SetModifLogin(string modifLogin);
        public void SetModifDate(DateTime modifDate);
    }
}
