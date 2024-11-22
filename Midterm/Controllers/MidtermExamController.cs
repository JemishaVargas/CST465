using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
namespace Midterm;

[Route("")]
public class MidtermExamController : Controller
{
    private readonly MidtermExam _Exam;
    private readonly IConfiguration _Config;
    
    public MidtermExamController(IConfiguration conf, IOptions<MidtermExam> exam)
    {
        _Exam = exam.Value;
        _Config = conf;
    }
    [Route("")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [Route("TakeTest")]
    [HttpGet]
    public IActionResult TakeTest()
    {
        List<TestQuestionModel> questionModels = GetQuestionModels();
        return View(questionModels);
    }
    [Route("SubmitTest")]
    [HttpPost]
    public IActionResult TakeTest(List<TestQuestionModel> model)
    {
        List<TestQuestionModel> questionModels = GetQuestionModels();
        foreach(TestQuestionModel question in questionModels)
        {
            foreach(TestQuestionModel answer in model)
            {
                if(question.ID == answer.ID)
                {
                    question.Answer = answer.Answer;
                }
            }
        }
        if(!ModelState.IsValid)
        {
            return View(questionModels);  
        }       
        
        return View("DisplayResults", questionModels);
    }
    [Route("DisplayResults")]
    public IActionResult DisplayResults(List<TestQuestionModel> model)
    {
        return View(model);
    }
    private List<TestQuestionModel> GetQuestionModels()
    {
        List<TestQuestionModel> questionModels = new List<TestQuestionModel>();
        foreach(var question in _Exam.Questions)
        {
            if(question.QuestionType == "TrueFalseQuestion")
            {
                TrueFalseQuestionModel tfQuestion = new TrueFalseQuestionModel();
                tfQuestion.ID = question.ID;
                tfQuestion.Question = question.Question;
                questionModels.Add(tfQuestion);
            }
            else if(question.QuestionType == "MultipleChoiceQuestion")
            {
                MultipleChoiceQuestionModel tfQuestion = new MultipleChoiceQuestionModel();
                tfQuestion.ID = question.ID;
                tfQuestion.Question = question.Question;
                tfQuestion.Choices = question.Choices;
                questionModels.Add(tfQuestion);
            }
            else if(question.QuestionType == "LongAnswerQuestion")
            {
                LongAnswerQuestionModel tfQuestion = new LongAnswerQuestionModel();
                tfQuestion.ID = question.ID;
                tfQuestion.Question = question.Question;
                questionModels.Add(tfQuestion);
            }
            else if(question.QuestionType == "ShortAnswerQuestion")
            {
                ShortAnswerQuestionModel tfQuestion = new ShortAnswerQuestionModel();
                tfQuestion.ID = question.ID;
                tfQuestion.Question = question.Question;
                questionModels.Add(tfQuestion);
            }
        }
        return questionModels;
    }
}