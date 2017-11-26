﻿using LearningSystem.Services.Contracts;
using System.Threading.Tasks;

namespace LearningSystem.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}