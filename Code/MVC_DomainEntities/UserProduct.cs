using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DomainEntities
{
    public class UserProduct
    {
        [Key]
        public int UserProductId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }

    }
}
