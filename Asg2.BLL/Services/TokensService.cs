using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

using Asg2.DAL.Models;
using Asg2.DAL.Repositories.Contracts;
using Asg2.BLL.Services.Contracts;

namespace Asg2.BLL.Services
{
    public class TokensService : ITokensService
    {

        private readonly IGenericRepository<Token> _repository;
        public TokensService(IGenericRepository<Token> repository)
        {
            _repository = repository;
        }

        public string GenerateTokenData()
        {
            byte[] tokenData = new byte[128];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(tokenData);
            }
            return Convert.ToBase64String(tokenData);
        }
        public async Task<Token> AddToken()
        {
            //create new token
            Token tok = new Token { Token1 = GenerateTokenData()};//Random id la token??
            //add it to database

            try
            {
                return await _repository.AddToken(tok);
            }
            catch
            {
                throw;
            }
        }

        public bool ValidateToken(string inputToken)
        {
            //GetToken and compare
            var tk = _repository.GetTokenByValue(inputToken);

            if (tk == null)
            {
                Console.WriteLine("Nu s-a gasit tokenul");
                return false;
            }
            Console.WriteLine("Token found");
            return true;
        }

        public async Task DeleteToken(string str)
        {
            await _repository.DeleteToken(str);
        }
    }
}
