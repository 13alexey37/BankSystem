using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Server.Data;
using TransferDataClassLibrary.Net;
using TransferDataClassLibrary.Entities;

namespace Server.Engine
{
    class ServerEngine
    {
        private ServerEngineCore engineCore;
        private DBManager dbManager;

        public ServerEngine()
        {
            dbManager = DBManager.GetInstance();
            engineCore = new ServerEngineCore();
            Utils.Log("Server started");
        }

        public void Run()
        {
            while (true)
            {
                TcpClient client = engineCore.AcceptClient();
                Utils.Log($"Client from {client.Client.RemoteEndPoint} connected");
                Task.Factory.StartNew(() => ProcessClient(client));
            }
        }

        private void ProcessClient(TcpClient client)
        {
            while (true)
            {
                RequestWrapper request = null;
                try
                {
                    request = ServerEngineCore.GetRequestFromClient(client);
                }
                catch (Exception e)
                {
                    Utils.Log($"Error from {client.Client.RemoteEndPoint}");
                    Utils.Log($"Error message: {e}");
                    Utils.Log("This connection will be abort");
                    return;
                }

                Utils.Log($"Request from {client.Client.RemoteEndPoint} ");
                ResponseWrapper response = new ResponseWrapper();

                try
                {
                    switch (request.Command)
                    {
                        case RequestWrapper.CommandEnum.UsersCreateNew:
                        {
                            User userParamFromClient = JsonConvert.DeserializeObject<User>(request.Parameters);

                            if (dbManager.TableUsers.CheckLogin(userParamFromClient.Login))
                            {
                                response.Status = ResponseWrapper.StatusEnum.LogicError;
                            }
                            else
                            {
                                dbManager.TableUsers.Insert(userParamFromClient);
                                response.Status = ResponseWrapper.StatusEnum.Ok;
                            }
                        }
                            break;
                        case RequestWrapper.CommandEnum.UsersAuthByLoginAndPassword:
                        {
                            User userParamFromClient = JsonConvert.DeserializeObject<User>(request.Parameters);

                            User findedUser = dbManager.TableUsers.SelectByLoginAndPassword(userParamFromClient.Login,
                                userParamFromClient.Password);


                            if (findedUser != null)
                            {
                                response.Status = ResponseWrapper.StatusEnum.Ok;
                                response.Message = JsonConvert.SerializeObject(findedUser);
                            }
                            else
                            {
                                response.Status = ResponseWrapper.StatusEnum.LogicError;
                            }
                        }
                            break;
                        case RequestWrapper.CommandEnum.UsersGetAllWithoutMe:
                        {
                            int explitId = int.Parse(request.Parameters);

                            List<User> users = dbManager.TableUsers.GetAllUsersWithoutMe(explitId);

                            response.Status = ResponseWrapper.StatusEnum.Ok;
                            response.Message = JsonConvert.SerializeObject(users);
                        }
                            break;
                        case RequestWrapper.CommandEnum.UsersGetMyBalance:
                            {
                                int id = int.Parse(request.Parameters);

                                int balance = dbManager.TableUsers.GetMyBalance(id);

                                response.Status = ResponseWrapper.StatusEnum.Ok;
                                response.Message = balance.ToString();
                            }
                            break;
                        case RequestWrapper.CommandEnum.TransactionsUpMyBalance:
                            {
                                Transaction transaction = JsonConvert.DeserializeObject<Transaction>(request.Parameters);

                                transaction.Dt = DateTime.Now;
                                dbManager.TableTransactions.Insert(transaction);

                                dbManager.TableUsers.IncreaseBalance(transaction.UserTo.Id, transaction.Money);

                                response.Status = ResponseWrapper.StatusEnum.Ok;
                            }
                            break;
                        case RequestWrapper.CommandEnum.TransactionsMakeFromUserToUser:
                            {
                                Transaction transaction = JsonConvert.DeserializeObject<Transaction>(request.Parameters);

                                transaction.Dt = DateTime.Now;
                                dbManager.TableTransactions.Insert(transaction);

                                dbManager.TableUsers.IncreaseBalance(transaction.UserTo.Id, transaction.Money);
                                dbManager.TableUsers.DecreaseBalance(transaction.UserFrom.Id, transaction.Money);

                                response.Status = ResponseWrapper.StatusEnum.Ok;
                            }
                            break;
                        case RequestWrapper.CommandEnum.TransactionsGetMyHistory:
                            {
                                Transaction transaction = JsonConvert.DeserializeObject<Transaction>(request.Parameters);

                                int user1Id = transaction.UserFrom.Id;
                                int user2Id = transaction.UserTo.Id;

                                List<Transaction> transactions =
                                    dbManager.TableTransactions.GetAllTransactionBetweenUsers(user1Id, user2Id);

                                response.Status = ResponseWrapper.StatusEnum.Ok;
                                response.Message = JsonConvert.SerializeObject(transactions);
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception e)
                {
                    response.Status = ResponseWrapper.StatusEnum.SystemError;
                    response.Message = "Internal Server Error: " + e;
                }

                try
                {
                    ServerEngineCore.SendResponseToClient(response, client);
                    Utils.Log($"Response to {client.Client.RemoteEndPoint}: {response} ");
                }
                catch (Exception exception)
                {
                    Utils.Log($"Error from {client.Client.RemoteEndPoint}");
                    Utils.Log($"Error message: {exception}");
                    Utils.Log($"This connection will be abort");
                    return;
                }
            }
        }
    }
}
