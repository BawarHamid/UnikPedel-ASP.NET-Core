using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Application.Infrastructure;
using UnikPedel.Application.TidRegistreringContract;
using UnikPedel.Application.TidRegistreringContract.TidRegistreringDto;

namespace UnikPedel.Application.Implementation
{
    public class TidRegistreringCommand : ITidRegistreringCommand
    {
        private readonly ITidRegistreringRepositroy _repository;
        public TidRegistreringCommand(ITidRegistreringRepositroy repository)
        {
            _repository = repository;
        }
        async Task ITidRegistreringCommand.CreateTidRegistreringAsyc(TidRegistreringCommandDto tidRegistreringDto)
        {
            var tidRegistrering  = new UnikPedel.Domain.Entities.TidRegistering(tidRegistreringDto.AntalTimer,tidRegistreringDto.VicevaertId , tidRegistreringDto.RekvisitionId );
            await _repository.AddRegistreringAsync(tidRegistrering);
        }

        async Task ITidRegistreringCommand.DeleteRegistreringAsync(TidRegistreringCommandDto tidRegistreringDto)
        {
            await _repository.DeleteTidRegistreringAsync(tidRegistreringDto.Id);
            
        }

        async Task ITidRegistreringCommand.EditRegistreringAsync(TidRegistreringCommandDto tidRegistreringDto)
        {
            var tidRegistrering = await _repository.GetTidRegistreringAsync(tidRegistreringDto.Id);
            tidRegistrering.Update( tidRegistreringDto.RegisterDato,tidRegistreringDto.AntalTimer, tidRegistreringDto.VicevaertId, tidRegistreringDto.RekvisitionId);
            await _repository.SaveTidRegistreringAsync(tidRegistrering);
        }
    }
}
