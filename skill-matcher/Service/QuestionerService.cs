using MongoDB.Driver;
using SkillMatcher.DataModel;
using SkillMatcher.Dto.Questioner;
using SkillMatcher.Dto.QuestionOption;
using SkillMatcher.Repository.Interfaces;
using SkillMatcher.Service.Interfaces;

namespace SkillMatcher.Service
{
    public class QuestionerService : IQuestionerService
    {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<Test> TestCollection;
        private readonly IConfiguration configuration;

        IQuestionerRepository questionerRepository;

        public QuestionerService(IQuestionerRepository questionerRepository, IConfiguration configuration)
        {
            this.questionerRepository = questionerRepository;
            this.configuration = configuration;
            var connectionString = configuration.GetConnectionString("MongoDb");
            var client = new MongoClient(connectionString);
            db = client.GetDatabase("JobOffererTest");
            TestCollection = db.GetCollection<Test>("Tests");
        }
        public Guid InsertQuestionAnswer(QuestionAndAnswerFromUiDto questionAndAnswerFromUiDto)
        {
            QuestionAndAnswerDto questionAndAnswerDto = new QuestionAndAnswerDto();

            questionAndAnswerDto.Answers = questionAndAnswerFromUiDto.Answers;
            questionAndAnswerDto.UserId = questionAndAnswerFromUiDto.UserId;
            questionAndAnswerDto.Id = questionAndAnswerFromUiDto.Id;

            questionAndAnswerDto.Questions = questionAndAnswerFromUiDto.Questions;

            return questionerRepository.InsertQuestionAnswer(questionAndAnswerDto);
        }

        public Guid InsertUserId(Guid userId)
        {
            var questioner = new Questioner();

            questioner.UserId = userId;
            questioner.StartedDateTime = DateTime.Now;
            questioner.Chat = new List<QuestionerContent> { new QuestionerContent() };
            questioner.Result = new List<QuestionerResult> { new QuestionerResult() };
            questioner.Report = new List<QuestionerReport> { new QuestionerReport() };


            return questionerRepository.InsertUserId(questioner);
        }

        public List<ReportText> CreateReport(Guid userId, Guid questionerId, ReportListFromUIDto reportListFromUIDto)
        {
            List<ReportText> repo = new List<ReportText>();
            var filter = Builders<Test>.Filter.Eq(q => q.Id, reportListFromUIDto.Questions[0].TestId);

            Test findTest = TestCollection.Find(filter).FirstOrDefault();

            if (findTest == null)
            {
                return null;
            }

            List<Rule> rule2 = new List<Rule>();
            List<Rule> rule1 = new List<Rule>();

            foreach (var item in findTest.Rule)
            {
                if (item.LevelQuestions == 2)
                    rule2.Add(item);
                if(item.LevelQuestions == 1)
                    rule1.Add(item);

            }


            var x = 0;
            if (reportListFromUIDto.Questions.Count == 16)
                x = 1;

            List<ReportText> reportText = new List<ReportText>();


            if(reportListFromUIDto.Questions.Count == 4 || x==1)
            {
                var questionCount = reportListFromUIDto.Questions.Count;

                int[,] labelDict = new int[rule1.Count(), 4];
                foreach (var item in rule1)
                {
                    for (int j = 0; j < rule1.Count(); j++)//tedad radif rule ha
                    {
                        for (int p = 0; p < 4; p++)//tedad option  ha
                        {
                            labelDict[j, p] = item.Items[p].OptionNo;
                        }
                        //   labelDict[j, p] = item.Items[p-1].
                    }
                }
                for (int j = 0; j < rule1.Count(); j++)//tedad radif rul ha ya hamun tedad radif labledict
                {

                    if (reportListFromUIDto.OptionNo[0] == labelDict[j, 0] &&
                        reportListFromUIDto.OptionNo[1] == labelDict[j, 1]
                        &&
                        reportListFromUIDto.OptionNo[2] == labelDict[j, 2] &&
                        reportListFromUIDto.OptionNo[3] == labelDict[j, 3]
                        )
                    {
                        repo.Add( rule1[j].Report);
                        break;

                    }
                }

                //if (x == 1)
                //    reportText.Add(repo[]);
                //else
             //   return repo;
            

        }
            //------------------------------------------------------
            //findetest.rule.count = ---- rule1.count
            //if (resultFromUIDto.Questions.Count == 4)//4
            //{

            //    var count = 0;
            //    for (int i = 0; i < 4; i = i)
            //    {
            //        if (count == 4)
            //            break;
            //        for (int j = 0; j < rule1.Count(); j = j)
            //        {
            //            if (count == 4)
            //                break;

            //            for (int k = 0; k < 4; k = k)
            //            {
            //                if (resultFromUIDto.Questions[i].Id == rule1[j].Items[k].Question[0].Id)//check if questions are equal
            //                {
            //                    if (resultFromUIDto.Answers[i] == rule1[j].Items[k].Option)//then check if option are equal
            //                    {
            //                        i++;
            //                        k = 0;
            //                        count++;
            //                        if (count == 4)// if 4 question and option from user was equal to rule return report
            //                        {
            //                            repo.English = findTest.Rule[j].Report.English;
            //                            repo.Persian = findTest.Rule[j].Report.Persian;
            //                            break;
            //                        }
            //                    }
            //                    else
            //                    {
            //                        j++;
            //                        break;
            //                    }

            //                }
            //                else
            //                {
            //                    k++;
            //                }
            //            }

            //        }
            //    }
            //---------------------------------------------------


            else if (reportListFromUIDto.Questions.Count == 12)//12
            {

                int[] optionNumber = reportListFromUIDto.OptionNo.ToArray();
                int n = reportListFromUIDto.Questions.Count;

                // Check if the length is divisible by 4
                //if (n % 3 != 0)
                //{
                //    throw new ArgumentException("The length of the data should be divisible by 4.");
                //}

                // Calculate the number of clusters
                int numClusters = n / 3;
                int[] labels = new int[numClusters];

                for (int i = 0; i < n; i += 3)
                {

                    // Count occurrences in the current cluster
                    int[] clusterCounts = new int[3];
                    Array.Copy(optionNumber, i, clusterCounts, 0, 3);

                    // Determine the label based on occurrences
                    int label = Array.FindAll(clusterCounts, count => count == 1).Length >= 2 ? 1 : 2;

                    // Append the label to the result
                    labels[i / 3] = label;
                }


                int[,] labelDict = new int[rule2.Count(), 4];
                foreach (var item in rule2)
                {
                    for (int j = 0; j < rule2.Count(); j++)//tedad radif rule ha
                    {
                        for (int p = 0; p < 4; p++)//tedad option  ha
                        {
                            labelDict[j, p] = item.Items[p].OptionNo;
                        }
                        //   labelDict[j, p] = item.Items[p-1].
                    }
                }
                //ReportText report = null;
                for (int j = 0; j < rule2.Count(); j++)
                {

                    if (labels[0] == labelDict[j, 0] &&
                        labels[1] == labelDict[j, 1]
                        &&
                        labels[2] == labelDict[j, 2] &&
                        labels[3] == labelDict[j, 3]
                        )
                    {
                        repo.Add( rule2[j].Report);
                        break;

                    }
                }
                //return report;


            }
            else if (reportListFromUIDto.Questions.Count == 16)
            {
                List<int> subList = reportListFromUIDto.OptionNo.GetRange(4, reportListFromUIDto.OptionNo.Count() - 4);

                int[] optionNumber = subList.ToArray();
                int n = reportListFromUIDto.Questions.Count;

                // Check if the length is divisible by 3
                //if (n % 3 != 0)
                //{
                //    throw new ArgumentException("The length of the data should be divisible by 4.");
                //}

                // Calculate the number of clusters
                int numClusters = n / 3;
                int[] labels = new int[numClusters];

                for (int i = 0; i < n; i += 3)
                {

                    // Count occurrences in the current cluster
                    int[] clusterCounts = new int[3];
                    Array.Copy(optionNumber, i, clusterCounts, 0, 3);

                    // Determine the label based on occurrences
                    int label = Array.FindAll(clusterCounts, count => count == 1).Length >= 2 ? 1 : 2;

                    // Append the label to the result
                    labels[i / 3] = label;
                }


                int[,] labelDict = new int[rule2.Count(),4];
                foreach (var item in rule2)
                {
                    for (int j = 0; j < rule2.Count(); j++)//tedad radif rule ha
                    {
                        for (int p = 0; p < 4; p++)//tedad option  ha
                        {
                            labelDict[j, p] = item.Items[p].OptionNo;
                        }
                    }
                }
             //   ReportText report = null;
                for (int j = 0; j < rule2.Count(); j++)
                {

                    if (labels[0] == labelDict[j, 0] &&
                        labels[1] == labelDict[j, 1]
                        &&
                        labels[2] == labelDict[j, 2] &&
                        labels[3] == labelDict[j, 3]
                        )
                    {
                        repo.Add(rule2[j].Report);
                        break;

                    }
                }

                   // reportText.Add(report);
            }
            else if (reportListFromUIDto.Questions.Count == 6)
            {
                //
                //List<int> subList = reportListFromUIDto.OptionNo.GetRange(4, reportListFromUIDto.OptionNo.Count() - 2);

                int[] optionNumber = reportListFromUIDto.OptionNo.ToArray();
                int n = reportListFromUIDto.Questions.Count;

                // Check if the length is divisible by 3
                //if (n % 3 != 0)
                //{
                //    throw new ArgumentException("The length of the data should be divisible by 4.");
                //}

                // Calculate the number of clusters
                int numClusters = n / 3;
                int[] labels = new int[numClusters];

                for (int i = 0; i < n; i += 3)
                {

                    // Count occurrences in the current cluster
                    int[] clusterCounts = new int[3];
                    Array.Copy(optionNumber, i, clusterCounts, 0, 3);

                    // Determine the label based on occurrences
                    int label = Array.FindAll(clusterCounts, count => count == 1).Length >= 2 ? 1 : 2;

                    // Append the label to the result
                    labels[i / 3] = label;
                }


                int[,] labelDict = new int[rule2.Count(), 2];
                foreach (var item in rule2)
                {
                    for (int j = 0; j < rule2.Count(); j++)//tedad radif rule ha
                    {
                        for (int p = 0; p < 2; p++)//tedad option  ha
                        {
                            labelDict[j, p] = item.Items[p].OptionNo;
                        }
                    }
                }
                //   ReportText report = null;
                for (int j = 0; j < rule2.Count(); j++)
                {

                    if (labels[0] == labelDict[j, 0] &&
                        labels[1] == labelDict[j, 1]
                        //&&
                        //labels[2] == labelDict[j, 2] &&
                        //labels[3] == labelDict[j, 3]
                        )
                    {
                        repo.Add(rule2[j].Report);
                        break;

                    }
                }

                // reportText.Add(report);
            }
            var value = questionerRepository.CreateReport(userId, questionerId, reportListFromUIDto, repo);
            if (value != null)
            {
                return repo;

            }
            else
                return null;


        }
        public QuestionsAnswersDto GetQuestionsAnswers(Guid questionerId)
        {
            QuestionsAnswersDto result = questionerRepository.GetQuestionsAnswers(questionerId);
            return result;
        }


    }
}
