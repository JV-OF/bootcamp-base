using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Web.Models;

public class TarefaViewModel
{
    public int Id { get; set; }
    
    [Required]
    [MinLength(5, ErrorMessage = "O título deve ter no mínimo 5 caracteres")]
    [MaxLength(100, ErrorMessage ="O título deve conter no máximo 100 caracteres")]
    [DisplayName("Título")]    
    public string? Titulo { get; set; }        
    
    [Required(ErrorMessage="A descrição da tarefa deve ser preenchida")]
    [MinLength(5, ErrorMessage = "A descrição deve ter no mínimo 5 caracteres")]
    [MaxLength(100, ErrorMessage ="A descrição deve conter no máximo 100 caracteres")]
    [DisplayName("Descrição")]    
    public string? Descricao { get; set; }  

    [Required]
    [DisplayName("Concluída")]
    public bool Concluida { get; set; }
}