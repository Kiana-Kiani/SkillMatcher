//using OpenAI_API;
//using SkillMatcher.Dto.Questioner;
//using SkillMatcher.Service.Interfaces;

//namespace SkillMatcher.Service
//{
//    public class OpenAiService
//    {
//        private readonly IQuestionerService questionerService;

//        public OpenAiService(IQuestionerService questionerService)
//        {
//            this.questionerService = questionerService;
//        }


//        public string Key = "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";

//        public string CreatePrompt()
//        {
//            //QuestionsAnswersDto questionsAnswers = questionerService.GetQuestionsAnswers(questionerId);
//            //string prompt = "تو یک روانشناس هستی. طبق این سوال ها و جواب هایی که به آن هاداده شده است این فرد را تحلیل کن:" +

//            //  "سوالات :"+questionsAnswers.Questions +"جواب های سوالات قبل به ترتیب:"+ questionsAnswers.Answers;


//            // QuestionsAnswersDto questionsAnswers = questionerService.GetQuestionsAnswers(questionerId);

//            List<string> questions = new List<string>
//                {
//                    "ترجیح میدهید در نظر مردم چگونه باشید؟",
//                    "فکر می کنید کدامیک عیب بدتری به شمار می آید؟"
//                };


//            List<string> answers = new List<string>
//                    {
//                        "فردی خلاق و مبتکر",
//                        "غیرمنطقی و استدلال ناپذیر بودن"
//                    };
//                        string prompt = "تو یک روانشناس هستی. طبق این سوال ها و جواب هایی که به آن هاداده شده است این فرد را تحلیل کن:" +

//                          "سوالات :" + questions + "جواب های سوالات قبل به ترتیب:" + answers;


//            return prompt;
//        }



//        public async Task<string> AskQuestionAsync()
//        {


//            var openAi = new OpenAIAPI(Key);

//            var conversation = openAi.Chat.CreateConversation();

//            conversation.AppendUserInput(CreatePrompt());

//            var response = await conversation.GetResponseFromChatbotAsync();
//            Console.WriteLine(response);
//            return response;

//        }

//    }
//}
