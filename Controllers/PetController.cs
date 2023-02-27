using midterm_project.Models;
using midterm_project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace midterm_project.Controllers;

public class PetController : Controller
{

    private readonly ILogger<PetController> _logger;
    private readonly IPetRepository _petRepository;

    public PetController(ILogger<PetController> logger, IPetRepository repository)
    {
        _logger = logger;
        _petRepository = repository;
    }

    public IActionResult Index()
    {
        return RedirectToAction("List");
    }

    public IActionResult List()
    {
        return View(_petRepository.GetAllPets());
    }

    public IActionResult Edit(int id)
    {
        var pet = _petRepository.GetPetsById(id);
        if (pet == null)
        {
            return RedirectToAction("List");
        }
        return View(pet);
    }

    [HttpPost]
    public IActionResult Edit(Pets pets){
        if (!ModelState.IsValid)
        {
            return View();
        }
        _petRepository.UpdatePet(pets);
        return RedirectToAction("Detail", new { id = @pets.PetId });
    }

    [HttpGet]
    public IActionResult New()
    {
        return View();
    }

    [HttpPost]
    public IActionResult New(Pets pets)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _petRepository.CreatePet(pets);
        // return RedirectToAction("List");
        return RedirectToAction("Detail", "Pet", new { id = pets.PetId });
    }

    public IActionResult Delete(int id)
    {
        _petRepository.DeletePetById(id);
        return RedirectToAction("List");
    }

    public IActionResult Detail()
    {
        return View();
    }

[HttpGet]
    public IActionResult Detail(int id){
        var pet = _petRepository.GetPetsById(id);
        if (pet == null){
            return RedirectToAction("List");
        }
        return View(pet);
    }
}