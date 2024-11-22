using System.ComponentModel.DataAnnotations;
namespace Midterm;

public class MultipleChoiceQuestionModel : TestQuestionModel
{
    [Required]
    public override string Answer{get;set;}
}