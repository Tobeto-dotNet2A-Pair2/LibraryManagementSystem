using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialTypes.Queries.GetList.GetAll;
public class GetAllMaterialTypesDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public MaterialFormat MaterialFormat { get; set; }
}
