using System;
using System.Threading.Tasks;
using JobberApp.Data.Models;
using JobberApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace JobberApp.SignalRHub
{
    public class CommsHub : Hub
    {
        private IGenericRepository _hubRepository;

        public CommsHub(IGenericRepository hubRepository)
        {
            _hubRepository = hubRepository ?? throw new ArgumentNullException(nameof(hubRepository));  
        }

        public async Task Send(Message message) 
        {     
            await _hubRepository.Create<Message>(message);

            await Clients.Group(message.JobGroup).SendAsync("Send", message);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("JoinGroup", groupName);
        
            var history = await _hubRepository.GetAsync<Message>(m => m.JobGroup == groupName);

            await Clients.Client(Context.ConnectionId).SendAsync("History", history);
        }

        public async Task LeaveGroup(string groupName)
        {
            await Clients.Group(groupName).SendAsync("LeaveGroup", groupName);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            Message[] history = null;

            await Clients.Client(Context.ConnectionId).SendAsync("History", history);
        }
    }
}