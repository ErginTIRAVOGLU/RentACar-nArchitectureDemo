using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Model:Entity<Guid>
{
    public string Name { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }

    public Model(Guid id, string name, decimal dailyPrice, string ımageUrl, Guid brandId, Guid fuelId, Guid transmissionId):this()
    {
        Id = id;
        Name = name;
        DailyPrice = dailyPrice;
        ImageUrl = ımageUrl;
        BrandId = brandId;
        FuelId = fuelId;
        TransmissionId = transmissionId;
    }

    public Guid BrandId { get; set; }
    public virtual Brand? Brand { get; set; }
    public Guid FuelId { get; set; }
    public virtual Fuel? Fuel { get; set; }
    public Guid TransmissionId { get; set; }
    public virtual Transmission? Transmission { get; set; }

    public virtual ICollection<Car> Cars { get; set; }

    public Model()
    {
        Cars = new HashSet<Car>();
    }

}
