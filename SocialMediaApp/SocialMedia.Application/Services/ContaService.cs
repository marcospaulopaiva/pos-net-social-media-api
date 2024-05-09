using SocialMedia.Application.Models;
using SocialMedia.Application.Models.Contas;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;
        public ContaService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public ResultViewModel<int> Insert(CreateContaInputModel model)
        {
            var conta = new Conta(
                model.NomeCompleto,
                model.Senha,
                model.Email,
                model.DataNascimento,
                model.Telefone
                );

            _contaRepository.Add(conta);

            return ResultViewModel<int>.Success(conta.Id);
        }

        public ResultViewModel Update(int id, UpdateContaInputModel model)
        {
            var conta = _contaRepository.GetById(id);

            if (conta is null)
            {
                return ResultViewModel.Error("Not faund");
            }

            conta.Update(model.NomeCompleto, model.DataNascimento);

            _contaRepository.Update(conta);

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var conta = _contaRepository.GetById(id);

            if (conta is null)
            {
                return ResultViewModel.Error("Not faund");
            }

            conta.SetAsDeleted();

            _contaRepository.Delete(conta);

            return ResultViewModel.Success();
        }

        public ResultViewModel<Conta?> GetById(int id)
        {
            var conta = _contaRepository.GetById(id);

            return conta is null ?
                ResultViewModel<Conta?>.Error("Not found") :
                ResultViewModel<Conta?>.Success(conta);
        }

    }
}
