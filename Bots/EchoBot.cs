// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with EchoBot .NET Template version v4.17.1

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using AdaptiveCards.Templating;
using AdaptiveCards;
using System;
using NugetJObject;
using System.IO;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;

namespace EchoBot.Bots
{
    
      
    public class EchoBot : ActivityHandler
    {
          private readonly string card1 =Path.Combine(".",  "SolitaireCard.json");
        private static Attachment CreateAdaptiveCardAttachment(string filePath)
        {
            var adaptiveCardJson = File.ReadAllText(filePath);
            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            if (turnContext.Activity.Text.ToUpper()=="CLICKED") {var replyText = $"Great! Let me know, I'd love to have your feedback";
            await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);}
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {   
            
            var welcomeText = "Hi, welcome to Chiara World!!\n Follow the link below to find out some news about my EP coming out on September 26th. \n ";
            foreach (var member in membersAdded)
            {
                     {
                        var imagePath = Path.Combine(".",  "chiara.png");
                        var imageData = Convert.ToBase64String(File.ReadAllBytes(imagePath));

                        var _chiarapng= new Attachment
                            {
                                Name = @"chiara.png",
                                ContentType = "image/png",
                                ContentUrl = $"data:image/png;base64,{imageData}",
                            };
                        var imagePath1 = Path.Combine(".",  "SolitaireCard.json");
                         var cardAttachment2 = CreateAdaptiveCardAttachment(imagePath1);
                           await turnContext.SendActivityAsync(MessageFactory.Attachment(_chiarapng), cancellationToken);
                          await turnContext.SendActivityAsync(MessageFactory.Attachment(cardAttachment2), cancellationToken);
                       

                    }
                        //var cardAttachment = CreateAdaptiveCardAttachment(card1);
                      
            //turnContext.Activity.Attachments = new List<Attachment>() { cardAttachment };
               
            }
        }
        

            
    }
    
    
        
}

