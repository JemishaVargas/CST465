using System.ComponentModel.DataAnnotations;
namespace Midterm;

public class TrueFalseQuestionModel : TestQuestionModel
{
    [Required]
    [RegularExpression("(True)+(False)")]
    public override string Answer{get;set;}
}