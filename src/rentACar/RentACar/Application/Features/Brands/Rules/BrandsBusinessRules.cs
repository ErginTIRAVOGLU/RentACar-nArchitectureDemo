using Application.Features.Brands.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConserns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules;

public class BrandsBusinessRules:BaseBusinessRules
{
    private readonly IBrandRepository _brandRepository;

    public BrandsBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task BrandNameCannotBeDuplicatedWhenInserted(string name)
    {
        Brand? result = await _brandRepository.GetAsync(predicate:b=>b.Name.ToLower()==name.ToLower());
        
        if (result != null) {
            throw new BusinessException(BrandsMessages.BrandNameExists);
        }
    }
}
