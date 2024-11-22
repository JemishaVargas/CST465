using System.ComponentModel.DataAnnotations;
namespace Midterm;

public class ShortAnswerQuestionModel : TestQuestionModel
{
    [Required]
    [StringLength(100)]
    public override string Answer{get;set;}
}