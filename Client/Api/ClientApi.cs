using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferDataClassLibrary.Net;
using TransferDataClassLibrary.Entities;
using Newtonsoft.Json;

namespace Client.Api
{
    class ClientApi
    {
        private static ClientApi instance;

        public static ClientApi GetInstance() => instance ?? (instance = new ClientApi());

        private ClientApiCore apiCore;

        private ClientApi()
        {
            apiCore = new ClientApiCore();
        }

        public User GetUserByLoginAndPassword(string login, string pass)
        {
            User user = new User()
            {
                Login = login,
                Password = pass
            };

            RequestWrapper request = new RequestWrapper()
            {
                Command = RequestWrapper.CommandEnum.UsersAuthByLoginAndPassword, Parameters = JsonConvert.SerializeObject(user)
            };

            apiCore.SendRequestToServer(request);

            ResponseWrapper response = apiCore.GetResponseFromServer();

            switch (response.Status)
            {
                case ResponseWrapper.StatusEnum.Ok:
                    return JsonConvert.DeserializeObject<User>(response.Message);
                    break;
                case ResponseWrapper.StatusEnum.LogicError:
                    return null;
                    break;
                case ResponseWrapper.StatusEnum.SystemError:
                    throw new Exception(response.Message);
                    break;
            }

            return null;
        }

        public Task<User> GetUserByLoginAndPasswordAsync(string login, string pass)
        {
            return Task<User>.Factory.StartNew(() => GetUserByLoginAndPassword(login, pass));
        }

        public bool RegisterUser(User user)
        {
            RequestWrapper request = new RequestWrapper()
            {
                Command = RequestWrapper.CommandEnum.UsersCreateNew,
                Parameters = JsonConvert.SerializeObject(user)
            };

            apiCore.SendRequestToServer(request);

            ResponseWrapper response = apiCore.GetResponseFromServer();

            switch (response.Status)
            {
                case ResponseWrapper.StatusEnum.Ok:
                    return true;
                    break;
                case ResponseWrapper.StatusEnum.LogicError:
                    return false;
                    break;
                case ResponseWrapper.StatusEnum.SystemError:
                    throw new Exception(response.Message);
                    break;
            }
            return false;
        }

        public Task<bool> RegisterUserAsync(User user)
        {
            return Task<bool>.Factory.StartNew(() => RegisterUser(user)); 
        }

        public List<User> GetAllUsersWithoutMe(int explitId)
        {
            RequestWrapper request = new RequestWrapper()
            {
                Command = RequestWrapper.CommandEnum.UsersGetAllWithoutMe,
                Parameters = explitId.ToString()
            };

            apiCore.SendRequestToServer(request);

            ResponseWrapper response = apiCore.GetResponseFromServer();

            switch (response.Status)
            {
                case ResponseWrapper.StatusEnum.Ok:
                    return JsonConvert.DeserializeObject<List<User>>(response.Message);
                    break;
                case ResponseWrapper.StatusEnum.LogicError:
                    return null;
                    break;
                case ResponseWrapper.StatusEnum.SystemError:
                    throw new Exception(response.Message);
                    break;
            }
            return null;
        }

        public Task<List<User>> GetAllUsersWithoutMeAsync(int explitId)
        {
            return Task<List<User>>.Factory.StartNew(() => GetAllUsersWithoutMe(explitId));
        }

        public int GetMyBalance(int id)
        {
            RequestWrapper request = new RequestWrapper()
            {
                Command = RequestWrapper.CommandEnum.UsersGetMyBalance,
                Parameters = id.ToString()
            };

            apiCore.SendRequestToServer(request);

            ResponseWrapper response = apiCore.GetResponseFromServer();

            switch (response.Status)
            {
                case ResponseWrapper.StatusEnum.Ok:
                    return int.Parse(response.Message);
                    break;
                case ResponseWrapper.StatusEnum.LogicError:
                    return 0;
                    break;
                case ResponseWrapper.StatusEnum.SystemError:
                    throw new Exception(response.Message);
                    break;
            }
            return 0;
        }

        public Task<int> GetMyBalanceAsync(int id)
        {
            return Task<int>.Factory.StartNew(() => GetMyBalance(id));
        }

        public bool UpMyBalance(Transaction transaction)
        {
            RequestWrapper request = new RequestWrapper()
            {
                Command = RequestWrapper.CommandEnum.TransactionsUpMyBalance,
                Parameters = JsonConvert.SerializeObject(transaction)
            };

            apiCore.SendRequestToServer(request);

            ResponseWrapper response = apiCore.GetResponseFromServer();

            switch (response.Status)
            {
                case ResponseWrapper.StatusEnum.Ok:
                    return true;
                    break;
                case ResponseWrapper.StatusEnum.LogicError:
                    return false;
                    break;
                case ResponseWrapper.StatusEnum.SystemError:
                    throw new Exception(response.Message);
                    break;
            }
            return false;
        }

        public Task<bool> UpMyBalanceAsync(Transaction transaction)
        {
            return Task<bool>.Factory.StartNew(() => UpMyBalance(transaction));
        }

        public bool MakeTransactionFromUserToUser(Transaction transaction)
        {
            RequestWrapper request = new RequestWrapper()
            {
                Command = RequestWrapper.CommandEnum.TransactionsMakeFromUserToUser,
                Parameters = JsonConvert.SerializeObject(transaction)
            };

            apiCore.SendRequestToServer(request);

            ResponseWrapper response = apiCore.GetResponseFromServer();

            switch (response.Status)
            {
                case ResponseWrapper.StatusEnum.Ok:
                    return true;
                    break;
                case ResponseWrapper.StatusEnum.LogicError:
                    return false;
                    break;
                case ResponseWrapper.StatusEnum.SystemError:
                    throw new Exception(response.Message);
                    break;
            }
            return false;
        }

        public Task<bool> MakeTransactionFromUserToUserAsync(Transaction transaction)
        {
            return Task<bool>.Factory.StartNew(() => MakeTransactionFromUserToUser(transaction));
        }

        public List<Transaction> GetMyTransactionsHistoryWithAnotherUser(int myId, int userId)
        {
            Transaction transaction = new Transaction()
            {
                UserFrom = new User() {Id = myId},
                UserTo = new User() {Id = userId},
            };

            RequestWrapper request = new RequestWrapper()
            {
                Command = RequestWrapper.CommandEnum.TransactionsGetMyHistory,
                Parameters = JsonConvert.SerializeObject(transaction)
            };

            apiCore.SendRequestToServer(request);

            ResponseWrapper response = apiCore.GetResponseFromServer();

            switch (response.Status)
            {
                case ResponseWrapper.StatusEnum.Ok:
                    return JsonConvert.DeserializeObject<List<Transaction>>(response.Message);
                    break;
                case ResponseWrapper.StatusEnum.LogicError:
                    return null;
                    break;
                case ResponseWrapper.StatusEnum.SystemError:
                    throw new Exception(response.Message);
                    break;
            }
            return null;
        }

        public Task<List<Transaction>> GetMyTransactionsHistoryWithAnotherUserAsync(int myId, int userId)
        {
            return Task<List<Transaction>>.Factory.StartNew(() => GetMyTransactionsHistoryWithAnotherUser(myId, userId));
        }
    }


}
