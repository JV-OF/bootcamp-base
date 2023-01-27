using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;
using AutoMapper;


namespace Tarefas.Web.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ITarefaDAO _tarefaDAO;

        public TarefaController(ITarefaDAO tarefaDAO)
        {
            _tarefaDAO=tarefaDAO;
        }

        private readonly IMapper _mapper;

        public TarefaController(IMapper mapper, ITarefaDAO tarefaDAO)
        {
            _tarefaDAO = tarefaDAO;
            _mapper=mapper;
        }

        public List<TarefaViewModel> listaDeTarefas { get; set; }
        
        public IActionResult Details(int id)
        { 
            var tarefaDTO = _tarefaDAO.Consultar(id);

            var tarefa = new TarefaViewModel()
            {
                Id = tarefaDTO.Id,
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                Concluida = tarefaDTO.Concluida
            };
                return View(tarefa);
        }
        
        public IActionResult Index()
        {
            var listaDeTarefasDTO = _tarefaDAO.Consultar();

            var listaDeTarefas= new List<TarefaViewModel>();

            foreach (var tarefaDTO in listaDeTarefasDTO)
            {
               listaDeTarefas.Add(_mapper.Map<TarefaViewModel>(tarefaDTO));
            };
    
            return View(listaDeTarefas);
        }

        public IActionResult Create()        
        {
           return View();
        }

        [HttpPost]
        public IActionResult Create(TarefaViewModel tarefa)
        {

            if(!ModelState.IsValid)
            {
                return View();
            }

            var tarefaDTO =_mapper.Map<TarefaDTO>(tarefa);

            _tarefaDAO.Criar(tarefaDTO);


            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Update(TarefaViewModel tarefa)
        {

            if(!ModelState.IsValid)
            {
                return View();
            }
            var tarefaDTO = _mapper.Map<TarefaDTO>(tarefa);

            _tarefaDAO.Atualizar(tarefaDTO);

            return RedirectToAction("Index");

        }

        public IActionResult Update(int id)
        {
            var tarefaDTO = _tarefaDAO.Consultar(id);

            var tarefa = _mapper.Map<TarefaViewModel>(tarefaDTO);

            return View(tarefa);
        }
        public IActionResult Delete(int id)
        {
            var tarefaDAO = new TarefaDAO();
            tarefaDAO.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}