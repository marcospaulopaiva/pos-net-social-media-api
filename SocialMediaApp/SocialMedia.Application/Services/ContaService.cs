﻿using SocialMedia.Application.Models;
using SocialMedia.Application.Models.Contas;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Repositories;
using static SocialMedia.Application.Models.Contas.ContaDetailsViewModel;

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

        public ResultViewModel<ContaViewModel?> GetById(int id)
        {
            var conta = _contaRepository.GetById(id);

            return conta is null ?
                ResultViewModel<ContaViewModel?>.Error("Not found") :
                ResultViewModel<ContaViewModel?>.Success(ContaViewModel.FromEntity(conta));
        }

        public ResultViewModel<ContaViewModel?> GetByEmail(string email)
        {
            var conta = _contaRepository.GetByEmail(email);

            return conta is null ?
                ResultViewModel<ContaViewModel?>.Error("Not found") :
                ResultViewModel<ContaViewModel?>.Success(ContaViewModel.FromEntity(conta));
        }

        public ResultViewModel MudarSenha(string email, UpdateSenhaContaInputModel model)
        {
            var conta = _contaRepository.GetByEmail(email);

            if ((conta != null) && (conta.Senha == model.Senha))
            {
                conta.MudarSenha(model.NovaSenha);

                _contaRepository.Update(conta);

                return ResultViewModel.Success();
            }

            return ResultViewModel.Error("Not found");
        }

    }
}
