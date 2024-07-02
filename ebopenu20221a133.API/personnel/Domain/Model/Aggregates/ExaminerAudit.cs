using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace ebopenu20221a133.API.personnel.Domain.Model.Aggregates
{
    public partial class Examiner: IEntityWithCreatedUpdatedDate
    {   
        [Column("CreatedAt")]
        public DateTimeOffset? CreatedDate { get; set; }
        [Column("UpdatedAt")]
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}

