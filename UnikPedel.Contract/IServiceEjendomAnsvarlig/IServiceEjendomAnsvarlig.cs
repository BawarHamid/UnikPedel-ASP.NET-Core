﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Contract.IServiceEjendomAnsvarlig.EjendomAnsvarligDtos;

namespace UnikPedel.Contract.IServiceEjendomAnsvarlig
{
    public interface IServiceEjendomAnsvarlig
    {
        Task CreateEjendomAnsvarligAsync(EjendomAnsvarligDto ejendomAnsvarlig);
        Task EditEjendomAnsvarligAsync(EjendomAnsvarligDto ejendomAnsvarlig);
        Task DeleteEjendomAnsvarligAsync(EjendomAnsvarligDto ejendomAnsvarlig);
        Task<EjendomAnsvarligDto?> GetEjendomAnsvarligAsync(Guid Id);
        Task<IEnumerable<EjendomAnsvarligDto>> GetEjendomAnsvarligAsync();
    }
}
